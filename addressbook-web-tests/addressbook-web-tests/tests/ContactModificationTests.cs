using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Петр");
            newData.Lastname = "Петров";

            ContactData oldData = new ContactData("Иван");
            oldData.Lastname = "Иванов";

            if (app.Contacts.IsContactConsist() == false)
            {
                app.Contacts.Create(oldData);
            }
            app.Contacts.Modify(1, newData);
        }
    }
}
