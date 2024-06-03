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
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Петр", "Петров");
            //newData.Lastname = "Петров";

            ContactData oldData = new ContactData("Иван", "Иванов");
            //oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldcontactData = oldContacts[0];

            app.Contacts.Modify(oldcontactData, newData);

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;   
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldcontactData.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                }
            }
        }
    }
}
