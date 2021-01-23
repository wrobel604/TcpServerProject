using LoginSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LoginSystem.Collections
{
    public class UserXmlListWithMessages : UserXmlList
    {
        string messageFileName;
        List<Message> messageList;
        public UserXmlListWithMessages(string usersFile, string messageFile) : base(usersFile)
        {
            messageFileName = messageFile;
            loadMessages();
        }
        public static void createMessageXMLFile(string filename, IEnumerable<Message> messages)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Message>), new XmlRootAttribute("Messages"));
            StreamWriter sw = new StreamWriter(filename);
            xmlSerializer.Serialize(sw, messages);
            sw.Close();
        }
        private void loadMessages()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Message>), new XmlRootAttribute("Messages"));
            StreamReader sr = new StreamReader(messageFileName);
            messageList = (List<Message>)xmlSerializer.Deserialize(sr);
            sr.Close();
        }
        public void saveMessages() { createMessageXMLFile(messageFileName, messageList); }

        public bool addMessage(Message message)
        {
            if (getUser(message.Sender) != null && getUser(message.Receiver) != null)
            {
                messageList.Add(message);
                return true;
            }
            return false;
        }
        public void deleteMessage(Message message)
        {
            if (messageList.Remove(message)) { saveMessages(); }
        }
        public List<Message> getMessages(string login)
        {
            return messageList.Where(x => x.Receiver == login).ToList();
        }
    }
}
