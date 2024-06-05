using System;

class Program
{
    static void Main(string[] args)
    {
        List<Videos> videos = new List<Videos>();

        Videos video1 = new Videos("Introduction to C#", "John Doe", 300);
        Comments comm1 = new Comments("Beatrice", "Great tutorial!");
        Comments comm2 = new Comments("Stone", "Very helpful.");
        Comments comm3 = new Comments("Rashford", "I learned a lot.");
        video1._commentList.Add(comm1);
        video1._commentList.Add(comm2);
        video1._commentList.Add(comm3);


        Videos video2 = new Videos("Object-Oriented Programming", "Jane Smith", 420);
        Comments comms1 = new Comments("Mark", "Clear explanation.");
        Comments comms2 = new Comments("Thomas", "Thanks for sharing.");
        Comments comms3 = new Comments("Henry", "This is not helpfull ");
        video2._commentList.Add(comms1);
        video2._commentList.Add(comms2);
        video2._commentList.Add(comms3);
        Videos video3 = new Videos("ASP.NET Web Development", "Michael Johnson", 600);
        Comments comment1 = new Comments("Elizabeth", "you have potientials");
        Comments comment2 = new Comments("Anthony", "Keep it up hope to see more.");
        Comments comment3 = new Comments("Felix", "I hate this tutorial.");
        video3._commentList.Add(comment1);
        video3._commentList.Add(comment2);
        video3._commentList.Add(comment3);
        Videos video4 = new Videos("How to make slider", "Clinton James", 300);
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Videos vid in videos)
        {
            vid.DisplayVideo();
            Console.WriteLine($"{vid._commentList.Count}");
            foreach (Comments item in vid._commentList)
            {

                item.DisplayComments();
            }
            Console.WriteLine("");
        }
    }
}