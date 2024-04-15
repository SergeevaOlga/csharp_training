using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]

    public class TestSuiteFixture
    {
        public static ApplicationManager app;
        
        [TearDown]

        public void StopApplicationManager()
        {
            ApplicationManager.GetInstance().Stop();
        }
    }
}
