using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

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

        public ContactHelper Modify(ContactData oldcontactData, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactEdit(oldcontactData.Id);
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

        public ContactHelper RemoveFromHomePage(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
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

        public ContactHelper RemoveFromEditPage(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitContactEdit(contact.Id);
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

        public ContactHelper InitContactEdit(int index)
        {
            //p++;
            //driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + p + "]/td[8]/a/img")).Click();
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactHelper InitContactEdit(String id)
        {
            //p++;
            //driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + p + "]/td[8]/a/img")).Click();
            driver.FindElement(By.XPath($"//input[@name='selected[]' and @value='{id}']//..//../td[8]/a")).Click();
            return this;
        }

        public ContactHelper InitContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();
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

        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath($"//input[@name='selected[]' and @value='{id}']")).Click();
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail

            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactEdit(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3

            };
            
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactData GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactDetails(index);
            string contactDetails = driver.FindElement(By.Id("content")).Text;


            return new ContactData()
            {
                ContactDetails = contactDetails
            };
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectIdContact(contact.Id);
            SelectGroupToAdd(group.Name);
            ConmmitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        internal void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupToDelete(group);
            SelectIdContact(contact.Id);
            ConmmitRemovingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void ConmmitRemovingContactToGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        private void ConmmitAddingContactToGroup()
        { 
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectGroupToDelete(GroupData groupFromDelete)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(groupFromDelete.Name);
        }

        private void SelectIdContact(string contactId)
        {
            //driver.FindElement(By.Id(contactId));
            driver.FindElement(By.XPath($"//input[@name='selected[]' and @value='{contactId}']")).Click();  
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        
    }
}

