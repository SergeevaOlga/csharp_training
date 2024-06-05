using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {
            string time = DateTime.Now.ToString();
            ContactData oldData = new ContactData("name to add in group", time);
            
            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }

            GroupData groupListEmpty = new GroupData("gn to add contact");
            groupListEmpty.Header = "gh to add contact";
            groupListEmpty.Footer = "gf to add contact";
            


            if (app.Groups.IsGroupConsist() == false)
            {
                app.Groups.Create(groupListEmpty);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> allContacts = ContactData.GetAll();
            oldList.Sort();
            allContacts.Sort();
            bool isEqual = Enumerable.SequenceEqual(oldList, allContacts);
            if (isEqual == true)
            {
                app.Contacts.Create(oldData);
            }
            ContactData contact = ContactData.GetAll().Except(oldList).First();


            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
