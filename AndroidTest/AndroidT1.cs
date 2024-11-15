using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace AndroidTest
{
    public class Tests1
    {
        string appPath = "@C:\\APK\\";
        private AndroidDriver <AndroidElement> driver;
        

        [SetUp]
        public void Setup()
        {
            AppiumOptions caps = new AppiumOptions();

            caps.AddAdditionalCapability("deviceName", "Nexus 6 API 34");
            caps.AddAdditionalCapability("version", "10.0");
            caps.AddAdditionalCapability("realDevice", true);
            caps.AddAdditionalCapability("platformName", "Android");
            caps.AddAdditionalCapability("app", "TruPickV23_02_51_ALPHA.apk");
           

        }
        [TearDown]
        public void TeadDown()
        {
            driver.Dispose();
        }
        
        [Test]
        public void Test1()
        {
            
        }
    }
}
    
