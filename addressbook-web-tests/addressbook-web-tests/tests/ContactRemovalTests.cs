using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        
        public void ContactRemovalHomePageTest()
        {
            ContactData oldData = new ContactData("Иван", "Иванов");
            //oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveFromHomePage(1);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }


        }

        [Test]
        public void ContactRemovalEditPageTest()
        {
            ContactData oldData = new ContactData("Иван", "Иванов");
            //oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.RemoveFromEditPage(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void ContactRemovalAllTest()
        {
            ContactData oldData = new ContactData("Иван", "Иванов");
            //oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }

             app.Contacts.RemoveAll();

            Assert.AreEqual(0, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            
            Assert.AreEqual(newContacts, "");
        }
    }
}
