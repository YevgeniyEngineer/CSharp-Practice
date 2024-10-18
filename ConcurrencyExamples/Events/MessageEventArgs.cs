using System;

namespace ConcurrencyExamples
{
    /// <summary>
    /// Contains the data associated with the message
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        public string Topic { get; }
        public string Message { get; }

        public MessageEventArgs(string topic, string message)
        {
            Topic = topic;
            Message = message;
        }
    }

    /// <summary>
    /// Delegate type for the event handler.
    /// </summary>
    public delegate void MessageReceivedEventHandler(object sender, MessageEventArgs e);
}
