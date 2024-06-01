﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
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


            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveAt(0);    
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groups in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }


        }
    }
}
