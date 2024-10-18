using System;

namespace ConcurrencyExamples
{
    public class Publisher
    {
        private readonly EventBus _eventBus;

        public Publisher(EventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public void SendMessage(string topic, string message)
        {
            Console.WriteLine($"Publisher: Sending message on topic '{topic}': {message}");
            _eventBus.Publish(topic, message);
        }
    }
}
