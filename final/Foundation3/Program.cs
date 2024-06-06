using System;

class Program
{
    static void Main(string[] args)
    {
        Address eventAddress1 = new Address("123 Main St", "Cityville", "Stateville", "12345");
        Address eventAddress2 = new Address("456 Elm St", "Townville", "Stateville", "67890");
        Address eventAddress3 = new Address("789 Oak St", "Villageville", "Stateville", "54321");

        Lectures lectureEvent = new Lectures( "John Smith", "Explore the impact of AI on our lives", "AI in the Future",  DateTime.Now.AddDays(7), new TimeSpan(18, 30, 0), eventAddress1,  100);
        Reception receptionEvent = new Reception( "rsvp@example.com","Networking Mixer", "Connect with like-minded professionals", DateTime.Now.AddDays(14), new TimeSpan(19, 0, 0), eventAddress2 );
        Outdoor outdoorEvent = new Outdoor( "Sunny with a chance of clouds","Summer Picnic", "Enjoy a day of outdoor fun and games", DateTime.Now.AddDays(21), new TimeSpan(12, 0, 0), eventAddress3 );

        List<Event> eventList =  new List<Event>();
        eventList.Add(lectureEvent);
        eventList.Add(receptionEvent);
        eventList.Add(outdoorEvent);

        foreach (Event  item in eventList)
        {
            Console.WriteLine(item.GetFullDetails());
            Console.WriteLine(item.GetShortDescription());
            Console.WriteLine(item.GetStandardDetails());

        }
    }
}