using System;
using System.Collections.Generic;
using System.Text;

namespace LoginSystem.Models
{
    public class Message
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }

        public Message() : this("", "", "") { }
        public Message(User sender, User receiver, string content)
        {
            Sender = sender.Login;
            Receiver = receiver.Login;
            Content = content;
            DateTime = DateTime.Now;
        }
        public Message(string sender, string receiver, string content)
        {
            Sender = sender;
            Receiver = receiver;
            Content = content;
            DateTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Sender};{Receiver};{DateTime};{Content}";
        }
    }
}
