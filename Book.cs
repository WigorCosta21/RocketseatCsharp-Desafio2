﻿namespace BookstoreApi
{
    public class Book(int id, string title, string author, List<string> gender, double price, int quantity)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;
        public List<string> Gender { get; set; } = gender;
        public double Price { get; set; } = price;
        public int Quantity { get; set; } = quantity;
    }
}
