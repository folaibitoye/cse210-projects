


class Comments
{
    public string authorName, commentText;



    public Comments(string _authorName, string _commentText)
    {
        authorName = _authorName;
        commentText = _commentText;
    }
    public void DisplayComments()
    {
        Console.WriteLine($"Name:{authorName}, Comments: {commentText}");
    }
}