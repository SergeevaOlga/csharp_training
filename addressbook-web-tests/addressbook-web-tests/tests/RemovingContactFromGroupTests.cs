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
