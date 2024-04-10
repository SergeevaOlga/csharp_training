using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitNewGroupCreation();
            GroupData group = new GroupData("gn");
            group.Header = "gh";
            group.Footer = "gf";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
            loginHelper.Logout();
        }
    }
}
