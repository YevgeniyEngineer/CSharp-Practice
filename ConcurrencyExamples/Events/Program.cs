using System;

namespace ConcurrencyExamples
{
    public class Program
    {
        public static void Main()
        {
            var eventBus = new EventBus();

            using (Subscriber subscriber1 = new Subscriber(eventBus, "TopicA"))
            using (Subscriber subscriber2 = new Subscriber(eventBus, "TopicA"))
            using (Subscriber subscriber3 = new Subscriber(eventBus, "TopicB"))
            {
                Publisher publisher = new Publisher(eventBus);

                publisher.SendMessage("TopicA", "Hello, TopicA!");
                publisher.SendMessage("TopicB", "Hello, TopicB!");
                publisher.SendMessage("TopicA", "This will cause an error message.");
                publisher.SendMessage("TopicA", "Another message to TopicA.");

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }

            // Subscribers are disposed and unsubscribed here
            Console.WriteLine("Subscribers have been disposed.");
        }
    }
}
