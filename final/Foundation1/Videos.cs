
class Videos
{
    public string author;
    public string title ;
    public int length;
    public List<Comments> _commentList = new   List<Comments>();
    
    
    public Videos( string _title, string _author,  int _length )
    {
        author  = _author;
        length  = _length;
        title  =_title;
        List<Comments> commentList = _commentList;
    }

    public  void DisplayVideo()
    {
        Console.WriteLine($"Author: {author}, Title: {title}, Lenth: {length}secs");        
               
        



    }
     public void GetNumberOfComments()
    {
        Console.WriteLine($"{_commentList.Count}");
    }
   


}
