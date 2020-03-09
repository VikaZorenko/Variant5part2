using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Variant5part2
{
    [TestClass]
    public class LoremIpsum_Test1
    {
        [TestMethod]
        public void Generate20Words_Equals()
        {
            GenerateNWords_Equals(20);
        }

        [TestMethod]
        public void GenerateMinus1Words_Equals()
        {
            GenerateNWords_Equals(-1);
        }

        [TestMethod]
        public void Generate0Words_Equals()
        {
            GenerateNWords_Equals(0);
        }

        [TestMethod]
        public void Generate15Words_Equals()
        {
            GenerateNWords_Equals(15);
        }

        [TestMethod]
        public void Generate50Words_Equals()
        {
            GenerateNWords_Equals(50);
        }

        private void GenerateNWords_Equals(int n)
        {
            // Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://lipsum.com/");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            // Act
            IWebElement wordsOptionRadio = driver.FindElement(By.XPath("//*[@id=\"words\"]"));
            wordsOptionRadio.Click();
            IWebElement generateAmountInput = driver.FindElement(By.XPath("//*[@id=\"amount\"]"));
            generateAmountInput.Clear();
            generateAmountInput.SendKeys(n.ToString());
            IWebElement generateBtn = driver.FindElement(By.XPath("//*[@id=\"generate\"]"));
            generateBtn.Click();

            string textBlockXPath = "//*[@id=\"lipsum\"]";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(textBlockXPath)));
            IWebElement textBlockElement = driver.FindElement(By.XPath(textBlockXPath));
            string textBlockText = textBlockElement.Text;

            // Assert
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            int wordsAmount = textBlockText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            Assert.AreEqual(n, wordsAmount);
        }
    }
    [TestClass]
    public class LoremIpsum_Test2
    {
        [TestMethod]
        public void Generate2Lists_Equals()
        {
            GenerateNLists_Equals(2);
        }

        [TestMethod]
        public void GenerateMinus1Lists_Equals()
        {
            GenerateNLists_Equals(-1);
        }

        [TestMethod]
        public void Generate0Lists_Equals()
        {
            GenerateNLists_Equals(0);
        }

        [TestMethod]
        public void Generate5Lists_Equals()
        {
            GenerateNLists_Equals(5);
        }

        private void GenerateNLists_Equals(int n)
        {

            // Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://lipsum.com/");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            // Act
            IWebElement listsOptionRadio = driver.FindElement(By.XPath("//*[@id=\"lists\"]"));
            listsOptionRadio.Click();
            IWebElement generateAmountInput = driver.FindElement(By.XPath("//*[@id=\"amount\"]"));
            generateAmountInput.Clear();
            generateAmountInput.SendKeys(n.ToString());
            IWebElement generateBtn = driver.FindElement(By.XPath("//*[@id=\"generate\"]"));
            generateBtn.Click();
            
            string listXPath = "//*[@id=\"lipsum\"]/ul";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(listXPath)));
            IList<IWebElement> listElements = driver.FindElements(By.XPath(listXPath));

            // Assert
            int listsAmount = listElements.Count;
            Assert.AreEqual(n, listsAmount);
        }
    }
}
