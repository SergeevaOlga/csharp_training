using System;
using System.Collections.Generic;
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();


            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);    
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
