using System;

namespace ConcurrencyExamples
{
    public class Subscriber : IDisposable
    {
        private readonly EventBus _eventBus;
        private readonly string _topic;
        private bool _disposed;

        public Subscriber(EventBus eventBus, string topic)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _topic = topic ?? throw new ArgumentNullException(nameof(topic));

            // Subscribe to the event
            _eventBus.Subscribe(_topic, OnMessageReceived);
        }

        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"Subscriber received message on topic '{e.Topic}': {e.Message}");

            // Simulate an exception
            if (e.Message.Contains("error"))
            {
                throw new InvalidOperationException("An error occurred while processing the message.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Unsubscribe from the topic
                    _eventBus.Unsubscribe(_topic, OnMessageReceived);
                    Console.WriteLine($"Subscriber unsubscribed from topic '{_topic}'.");
                }

                _disposed = true;
            }
        }
    }
}
