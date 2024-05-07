﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection;
using System.IO;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactEdit(p);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper RemoveFromHomePage(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            SubmitRemoveContact();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveAll()
        {
            manager.Navigator.GoToHomePage();
            SelectAllContacts();
            SubmitRemoveContact();
            contactCache = null;
            return this;
        }
        public ContactHelper RemoveFromEditPage(int p)
        {
            manager.Navigator.GoToHomePage();
            InitContactEdit(p);
            SubmitRemoveContact();
            contactCache = null;
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactEdit(int p)
        {
            p++;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + p + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int p)
        {
            p++;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + p + "]/td/input")).Click();
            
            return this;
        }

        public ContactHelper SubmitRemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper SelectAllContacts()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }
        public bool IsContactConsist()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img"));
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.FindElement(By.CssSelector("td:nth-child(3)")).Text, element.FindElement(By.CssSelector("td:nth-child(2)")).Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    }
                    );
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToHomePage();
            return driver.FindElements(By.Name("entry")).Count;
        }
    }
}

