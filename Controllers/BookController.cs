﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    
    private static List<Book> books = new List<Book>();

    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] Book book)
    {
        bool isExistBookID = books.Any(b => b.Id == book.Id);
        bool isExistBookTitle = books.Any(b => b.Title == book.Title.Trim());

        if (isExistBookID) return BadRequest("The Id already exists");
        if (isExistBookTitle) return BadRequest("The Title already exists");
        if (book.Quantity < 0) return BadRequest("Stock quantity cannot be negative");
        if (book.Price <= 0) return BadRequest("Price cannot be zero or negative");

        books.Add(book);

        return Created(string.Empty, book);
    }
    

}
