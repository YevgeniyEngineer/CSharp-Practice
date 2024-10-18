using System;
using System.Collections.Generic;

namespace ConcurrencyExamples
{
    public class EventBus
    {
        private readonly Dictionary<string, List<MessageReceivedEventHandler>> _subscribers = new();

        private readonly object _lock = new object();

        public void Subscribe(string topic, MessageReceivedEventHandler handler)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException(nameof(topic));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            lock (_lock)
            {
                if (!_subscribers.ContainsKey(topic))
                {
                    _subscribers[topic] = new List<MessageReceivedEventHandler>();
                }

                _subscribers[topic].Add(handler);
            }
        }

        public void Unsubscribe(string topic, MessageReceivedEventHandler handler)
        {
            if (string.IsNullOrEmpty(topic))
            {
                throw new ArgumentNullException(nameof(topic));
            }

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            lock (_lock)
            {
                if (_subscribers.ContainsKey(topic))
                {
                    _subscribers[topic].Remove(handler);

                    if (_subscribers[topic].Count == 0)
                    {
                        _subscribers.Remove(topic);
                    }
                }
            }
        }

        public void Publish(string topic, string message)
        {
            List<MessageReceivedEventHandler> handlersCopy;

            lock (_lock)
            {
                if (!_subscribers.ContainsKey(topic))
                {
                    return;
                }

                // Make a copy to prevent modification during enumeration
                handlersCopy = new List<MessageReceivedEventHandler>(_subscribers[topic]);
            }

            var eventArgs = new MessageEventArgs(topic, message);

            foreach (var handler in handlersCopy)
            {
                try
                {
                    handler?.Invoke(this, eventArgs);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception in handler: {ex.Message}");
                }
            }
        }
    }
}
