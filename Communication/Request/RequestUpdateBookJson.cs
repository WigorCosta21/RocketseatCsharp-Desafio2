namespace BookstoreApi.Communication.Request;

public class RequestUpdateBookJson
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public List<string> Gender {  get; set; } = new List<string>();
    public double Price { get; set; }
    public int Quantity { get; set; }
}
