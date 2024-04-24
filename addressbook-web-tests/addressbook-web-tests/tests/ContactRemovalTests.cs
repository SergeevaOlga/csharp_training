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

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);


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

            app.Contacts.RemoveFromEditPage(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
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

            List<ContactData> newContacts = app.Contacts.GetContactList();
            
            Assert.AreEqual(newContacts, "");
        }
    }
}
