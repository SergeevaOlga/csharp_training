using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("gn");
            group.Header = "gh";
            group.Footer = "gf";

            GroupData newData = new GroupData("new_gn");
            newData.Header = "new_gh";
            newData.Footer = "new_gf";

            if (app.Groups.IsGroupConsist() == false)
            {
                app.Groups.Create(group);
            }
            app.Groups.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}
