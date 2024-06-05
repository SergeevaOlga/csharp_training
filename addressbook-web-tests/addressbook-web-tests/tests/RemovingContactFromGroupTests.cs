using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]

        public void TestRemovingContactFromGroup()
        {
            ContactData oldData = new ContactData("name to add in group", "lastname to add in group");

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

            if (oldList.Count == 0)
            {
                ContactData contact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
                oldList = group.GetContacts();
            }

            ContactData contactInGroup = oldList[0];

            //actions
            app.Contacts.RemoveContactFromGroup(contactInGroup, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactInGroup);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }
    }
}
