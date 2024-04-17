using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("gn");
            group.Header = "gh";
            group.Footer = "gf";

            if (app.Groups.IsGroupConsist() == false)
            {
                app.Groups.Create(group);
            }
            app.Groups.Remove(1);
            app.Auth.Logout();
        }
    }
}
