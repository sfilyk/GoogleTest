using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleTest
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _fieldSearch = By.Name("q");
        private readonly By _imageFieldSearch = By.XPath("//div[@class='hdtb-mitem']/a");
        private const string _searchText = "harmonyos";
       
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void SearchText()
        {
            var fieldSearch = driver.FindElement(_fieldSearch);
            fieldSearch.SendKeys(_searchText);
            fieldSearch.SendKeys(Keys.Enter);
            var imageFieldSearch = driver.FindElement(_imageFieldSearch);
            imageFieldSearch.Click();

            var desiredText = driver.FindElement(By.XPath("//a[@href=contains(text(),'harmonyos')]"));
            Assert.IsTrue(desiredText.Displayed, "eernemnrfe");
            //Assert.True(driver.FindElement(By.XPath("//a[@title=contains(text(),'harmonyos')]")).Text.Contains("harmonyos"));

            //var actualProduct = driver.FindElement(_productTitle).Text;
            //Assert.AreEqual(_expectedProduct, actualProduct, "щось поламалось і ви не увійшли під своїм логіном");

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}