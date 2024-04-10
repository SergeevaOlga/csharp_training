using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.InitNewContactCreation();
            ContactData contact = new ContactData("Ольга");
            contact.Lastname = "Лейнбаум";
            contactHelper.FillContactForm(contact);
            contactHelper.SubmitContactCreation();
            navigator.ReturnToHomePage();
            loginHelper.Logout();
        }
    }
}
