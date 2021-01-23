using LoginSystem.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LoginSystem.Collections
{
    public class UserXmlList : UserDatabaseInterface
    {
        string userFileName;
        HashSet<User> userList = null;
        public UserXmlList(string filename)
        {
            userFileName = filename;
            loadUsers();
        }
        public static void createUserXMLFile(string filename, IEnumerable<User> users)
        {
            HashSet<User> list = new HashSet<User>(users);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("Users"));
            StreamWriter sw = new StreamWriter(filename);
            xmlSerializer.Serialize(sw, list.ToList());
            sw.Close();
        }
        private void loadUsers()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>), new XmlRootAttribute("Users"));
            StreamReader sr = new StreamReader(userFileName);
            userList = new HashSet<User>((List<User>)xmlSerializer.Deserialize(sr));
            sr.Close();
        }
        private void saveUsers()
        {
            createUserXMLFile(userFileName, userList);
        }
        public bool addUser(User user)
        {
            bool result = userList.Add(user);
            if (result) { saveUsers(); }
            return result;
        }

        public void deleteUser(User user)
        {
            int size = userList.Count;
            userList.Remove(user);
            if (size > userList.Count) { saveUsers(); }
        }

        public User getUser(string login)
        {
            var user = userList.Where(x => x.Login == login);
            return (user.Count() > 0) ? user.First() : null;
        }

        public void updateUser()
        {
            saveUsers();
        }
    }
}
