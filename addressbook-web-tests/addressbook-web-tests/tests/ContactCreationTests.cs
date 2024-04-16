﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            
            ContactData contact = new ContactData("Ольга");
            contact.Lastname = "Лейнбаум";
            app.Contacts.Create(contact);
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
