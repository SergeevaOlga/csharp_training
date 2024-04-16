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
            app.Contacts.RemoveFromHomePage(1);
        }

        [Test]
        public void ContactRemovalEditPageTest()
        {
            app.Contacts.RemoveFromEditPage(1);
        }

        [Test]
        public void ContactRemovalAllTest()
        {
            app.Contacts.RemoveAll();
        }
    }
}
