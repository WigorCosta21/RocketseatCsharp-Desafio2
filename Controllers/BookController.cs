using BookstoreApi.Communication.Request;
using BookstoreApi.Communication.Response;
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

        var response = new ResponseItemBookJson { id = book.Id };


        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public IActionResult GetAllBook()
    {
        if (books.Count == 0) return NoContent();

        return Ok(books);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetBookById([FromRoute] int id)
    {
        var isExistBook = books.FirstOrDefault(book => book.Id == id); 

        if(isExistBook == null) return NotFound("Book not found!");

        return Ok(isExistBook);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook([FromRoute]int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null) return NotFound("Book not found!");

        books.Remove(book);

        var response = new ResponseItemBookJson { id = book.Id };

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof (Book), StatusCodes.Status200OK)]
    public IActionResult UpdateBook(
        [FromRoute] int id,
        [FromBody] RequestUpdateBookJson request
        )
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null) return NotFound("Book not found!");

        switch(request)
        {
            case var _ when !string.IsNullOrWhiteSpace(request.Title):

                book.Title = request.Title;

                break;

            case var _ when !string.IsNullOrWhiteSpace(request.Author):

                book.Author = request.Author;

                break;

            case var _ when request.Gender.Any():

                book.Gender = request.Gender;

                break;

            case var _ when request.Price > 0:

                book.Price = request.Price;

                break;

            case var _ when request.Quantity >= 0:

                book.Quantity = request.Quantity;

                break;
        }

        var response = new ResponseItemBookJson { id = book.Id };

        return Ok(response);
    }

}
