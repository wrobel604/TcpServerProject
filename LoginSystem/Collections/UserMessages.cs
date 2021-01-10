using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LoginSystem.Models
{
    public class UserMessages
    {
        protected List<Message> messages;

        public UserMessages()
        {
            messages = new List<Message>();
        }
        public void addMessage(Message message)
        {
            messages.Add(message);
        }

        public List<Message> getMessagesBySender(User user)
        {
            return messages.Where(x => x.Sender == user.GetHashCode()).ToList();
        }
        public List<Message> getMessagesByReceiver(User user)
        {
            return messages.Where(x => x.Receiver == user.GetHashCode()).ToList();
        }

    }
}
