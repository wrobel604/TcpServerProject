using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSystem.Models
{
    public class Message
    {
        public int Sender { get; private set; }
        public int Receiver{ get; private set; }
        public string Content { get; private set; }

        public Message(User sender, User receiver, string content)
        {
            Sender = sender.GetHashCode();
            Receiver = receiver.GetHashCode();
            Content = content;
        }
        public Message(int sender_hash, int receiver_hash, string content)
        {
            Sender = sender_hash;
            Receiver = receiver_hash;
            Content = content;
        }
    }
}
