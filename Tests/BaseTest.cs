using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SeleniumInterviewTask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInterviewTask.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;


        [SetUp]
        public virtual void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();

        }

        [TearDown]
        public virtual void TearDown()
        {
            _driver.Quit();
        }
    }
}
