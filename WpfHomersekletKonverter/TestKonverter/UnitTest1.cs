using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace TestKonverter
{
    public class Tests
    {
        protected const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private const string Program = @"D:\rud-2\kodtarak_25-26\13c_asztali_2025-26\WpfHomersekletKonverter\WpfHomersekletKonverter\bin\Debug\net7.0-windows\WpfHomersekletKonverter.exe";
        private const string ProgramPath = @"D:\rud-2\kodtarak_25-26\13c_asztali_2025-26\WpfHomersekletKonverter\WpfHomersekletKonverter\bin\Debug\net7.0-windows";

        protected static WindowsDriver<WindowsElement> driver;

        [OneTimeSetUp]
        public void Setup()
        {
            if (driver==null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app",Program);
                appiumOptions.AddAdditionalCapability("devicename", "Win10");
                driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl),appiumOptions);
            }
        }

        [Test]
        [TestCase(85,29.444)]
        [TestCase(33,0.5555555)]
        public void FahrenheitToCelsius(double fahrenheit,double elvart)
        {
            var homerseklet = driver.FindElementByAccessibilityId("homersekletErtek");
            homerseklet.Clear();
            driver.FindElementByAccessibilityId("celsiusKivalaszt").Click();
            homerseklet.SendKeys(fahrenheit.ToString());
            driver.FindElementByAccessibilityId("buttonKonvertalas").Click();
            var eredmeny = driver.FindElementByAccessibilityId("konvertaltHomerseklet");
            Assert.AreEqual(elvart,Convert.ToDouble(eredmeny.Text),0.001);
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            driver.Close();
            driver.Quit();
        }
    }
}