using System;
using System.Collections.Generic;
using System.Linq;
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
            ContactData oldData = new ContactData("Иван");
            oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }
            app.Contacts.RemoveFromHomePage(1);
        }

        [Test]
        public void ContactRemovalEditPageTest()
        {
            ContactData oldData = new ContactData("Иван");
            oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }
            app.Contacts.RemoveFromEditPage(1);
        }

        [Test]
        public void ContactRemovalAllTest()
        {
            ContactData oldData = new ContactData("Иван");
            oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }
            app.Contacts.RemoveAll();
        }
    }
}
