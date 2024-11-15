//using Applitools.Commands;
//using NLog.Targets;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Appium.iOS;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Winium;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Windows.Forms;
//using System.Xml.Linq;
//using Winium.Cruciatus;
//using Winium.Elements.Desktop.Extensions;
//using ComboBox = Winium.Elements.Desktop.ComboBox;



//namespace Modules
//{
//    public class WDMethods
//    {
//        public static WiniumDriver driver { get; set; }
//        public static string Folderpath { get; set; }
//        public static int MaxWaitTime { get; private set; }
//        public Actions actionBuilder;        

//        public static void Start(string appPath, string winiumDriverDirectory)
//        {

//            if (winiumDriverDirectory == null || appPath == null)
//            {
//                throw new ArgumentException("winiumdriverPath, applicationPath nem lehet üres.");
//            }

//            else
//            {

//                // az app elérési útjának megadása
//                DesktopOptions options = new DesktopOptions();
//                options.ApplicationPath = appPath;
//                WiniumDriverService service = WiniumDriverService.CreateDesktopService(winiumDriverDirectory);                
//                service.Port = 9999;
//                service.SuppressInitialDiagnosticInformation = true;
//                service.EnableVerboseLogging = false;
//                service.Start();

//                try
//                {
//                    if (service != null || options != null)
//                    {
//                        driver = new WiniumDriver(service, options, TimeSpan.FromSeconds(10));
//                    }
//                    else
//                    {
//                        service.Dispose();
//                        throw new WebDriverException("Service vagy az application elérési út nincs megadva.");
//                    }
//                }
//                catch (WebDriverException ex)
//                {
//                    service.Dispose();
//                    Console.WriteLine("WebDriverException: " + ex.Message);
//                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
//                }
//                catch (Exception ex)
//                {
//                    service.Dispose();
//                    Console.WriteLine("Unexpected Exception: " + ex.Message);
//                    Console.WriteLine("Stack Trace: " + ex.StackTrace);
//                }
//            }
//        }
//        public static void Stop(string winiumDriverDirectory)
//        {
//            driver.Close();

//        }


//        public static void TakePrtsc(string FolderPath, string TestName)
//        {
//            Screenshot prtSc = ((ITakesScreenshot)driver).GetScreenshot();
//            string title = TestName;
//            string picName = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
//            string screenshotfilename = FolderPath + picName + ".png";
//            try
//            {
//                prtSc.SaveAsFile(screenshotfilename, OpenQA.Selenium.ScreenshotImageFormat.Png);
//                //WaitTime.Wait(1);
//            }
//            catch
//            {
//                throw new ArgumentException("A kép készítése nem teljesült.A kép készítéshez szükséges valamely paraméter nem került megadásra vagy nem áll rendelkezésre.(mappa)");
//            }
//        }

//        //összes metódus átírása annak az érdekében, hogy ne legyen szükséges megadni minden sornál Wait-t.
//        //megoldásként, minden egyes metódusnál megadható, hogy mennyi legyen a maximális várakozási idő a methodús végrehajtásához
//        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); Fromseconds értéke adja meg a maximális időt
//        //amennyiben nem kerül végrehajtásra, üzenet kerül megjelenítésre! Timed Out

//        public static void Click(string element, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

//            if (string.IsNullOrEmpty(element))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }

//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement searchelement = driver.FindElementById(element);
//                    // várakozás addig - 20 sec - amig a keresett element kattintható. Ezt követően, ha kattintható, akkor click. Ha nem, akkor hibára fut. TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    driver.FindElementById(element).Click();
//                    //searchelement.Click();
//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement searchelement = driver.FindElementByName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    driver.FindElementByName(element).Click();
//                    //searchelement.Click();
//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement searchelement = driver.FindElementByTagName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    driver.FindElementByTagName(element).Click();
//                    //searchelement.Click();
//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement searchelement = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    driver.FindElementByClassName(element).Click();
//                    //searchelement.Click();
//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement searchelement = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    driver.FindElementByXPath(element).Click();
//                    //searchelement.Click();
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);

//                }
//            }

//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A clickelés nem történt meg határidőn belül");
//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }

//        }

//        public static void Sendkeys(string element, string name, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(name))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }

//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement searchelement = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a keresett elementbe beírásra kerül a megadott szöveg, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.SendKeys(name);
//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement searchelement = driver.FindElementByName(element);                    
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.SendKeys(name);                    
//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement searchelement = driver.FindElementByTagName(element);                    
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.SendKeys(name);
//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement searchelement = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.SendKeys(name);
//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement searchelement = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.SendKeys(name);
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);
//                }

//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A szöveg beírása nem történt meg határidőn belül");
//            }
//            catch (ElementNotInteractableException exp)
//            {
//                throw exp;

//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }
//        }

//        public static void TextClear(string element, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement searchelement = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a keresett elementből törlésre kerül a szöveg, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.Clear();
//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement searchelement = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.Clear();
//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement searchelement = driver.FindElementByName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.Clear();
//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement searchelement = driver.FindElementByTagName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.Clear();
//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement searchelement = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    searchelement.Clear();
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);

//                }
//            }

//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A szöveg törlése nem történt meg határidőn belül");
//            }
//            catch (ElementNotInteractableException exp)
//            {
//                throw exp;

//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;                
//            }

//        }

//        public static void DoubleClick(string element, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

//            if (string.IsNullOrEmpty(element))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement elementW = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a keresett elementre való dupla kattintása elvégződik, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.DoubleClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement elementW = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.DoubleClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement elementW = driver.FindElementByName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.DoubleClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement elementW = driver.FindElementByTagName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.DoubleClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.DoubleClick(elementW).Perform();
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);

//                }
//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }
//            catch (ElementNotVisibleException ex)
//            {
//                throw ex;
//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A dupla kattintás nem történt meg határidőn belül");
//            }
//        }

//        public static void RightClick(string element, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(element))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement elementW = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a keresett elementre való jobb kattintás elvégződik, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.ContextClick(elementW).Perform();
//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement elementW = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.ContextClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement elementW = driver.FindElementByName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.ContextClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement elementW = driver.FindElementByTagName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.ContextClick(elementW).Perform();

//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    Actions action = new Actions(driver);
//                    action.ContextClick(elementW).Perform();
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);

//                }
//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }
//            catch (ElementNotVisibleException ex)
//            {
//                throw ex;
//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A jobb kattintás nem történt meg határidőn belül");
//            }
//        }

//        public static int ValueReadAndParse(string element, PropertyTypes elementtype, string value)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(value))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement location = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a keresett element keresése elvégződik, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(location));
//                    int message = Int32.Parse(location.GetAttribute(value));
//                    //kiolvasása a plusz adatoknak az összehasonlításhoz                                       
//                    string msg = "A vizsgált cikk értéke:" + message;
//                    string title = "Title";
//                    System.Windows.Forms.MessageBox.Show(msg, title);
//                    //táblába való beírás: cikk,testcase name, livedead,
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);

//                }
//            }

//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A keresés nem történt meg határidőn belül");
//            }
//            return 0;
//        }

//        public static void ElementCheck(string element, PropertyTypes elementtype, string value)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));


//            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(value))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    // várakozás addig - 5 sec - amig a keresett element keresése elvégződik, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    System.Windows.Forms.MessageBox.Show("Az element létezik és elérhető methodús számára.");

//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    System.Windows.Forms.MessageBox.Show("Az element létezik és elérhető methodús számára.");
//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    System.Windows.Forms.MessageBox.Show("Az element létezik és elérhető methodús számára.");

//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    System.Windows.Forms.MessageBox.Show("Az element létezik és elérhető methodús számára.");
//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement elementW = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
//                    System.Windows.Forms.MessageBox.Show("Az element létezik és elérhető methodús számára.");
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);
//                }

//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("A keresés nem történt meg határidőn belül");
//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }

//        }

//        public static void ScrollToElementAndClick(string element, PropertyTypes elementtype, string name)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(name))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement toElement = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a keresett element keresése elvégződik, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    ComboBox comboBox = new ComboBox(toElement);
//                    comboBox.Expand();
//                    comboBox.ScrollTo(By.Name(name));
//                    toElement.FindElement(By.Name(name)).Click();

//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement toElement = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    ComboBox comboBox = new ComboBox(toElement);
//                    comboBox.Expand();
//                    comboBox.ScrollTo(By.Name(name));
//                    toElement.FindElement(By.Name(name)).Click();

//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement toElement = driver.FindElementByName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    ComboBox comboBox = new ComboBox(toElement);
//                    comboBox.Expand();
//                    comboBox.ScrollTo(By.Name(name));
//                    toElement.FindElement(By.Name(name)).Click();

//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement toElement = driver.FindElementByTagName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    ComboBox comboBox = new ComboBox(toElement);
//                    comboBox.Expand();
//                    comboBox.ScrollTo(By.Name(name));
//                    toElement.FindElement(By.Name(name)).Click();

//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement toElement = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    ComboBox comboBox = new ComboBox(toElement);
//                    comboBox.Expand();
//                    comboBox.ScrollTo(By.Name(name));
//                    toElement.FindElement(By.Name(name)).Click();                    
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element,"nem található", true);
//                }

//            }
//            catch (NoSuchElementException exp)
//            {
//                throw exp;
//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("Az elementhez való scrollozás nem történt meg határidőn belül");
//            }

//        }

//        public static void MoveToElement(string element1, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(element1))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {

//                    IWebElement toElement = driver.FindElementById(element1);
//                    // várakozás addig - 5 sec - amig a keresett elementhez való move, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    Actions action = new Actions(driver);
//                    action.MoveToElement(toElement).Build().Perform();
//                }
//                if (elementtype == PropertyTypes.Name)
//                {

//                    IWebElement toElement = driver.FindElementByName(element1);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    Actions action = new Actions(driver);
//                    action.MoveToElement(toElement).Build().Perform();
//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {

//                    IWebElement toElement = driver.FindElementByClassName(element1);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    Actions action = new Actions(driver);
//                    action.MoveToElement(toElement).Build().Perform();
//                }
//                if (elementtype == PropertyTypes.TagName)
//                {

//                    IWebElement toElement = driver.FindElementByTagName(element1);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    Actions action = new Actions(driver);
//                    action.MoveToElement(toElement).Build().Perform();
//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {

//                    IWebElement toElement = driver.FindElementByXPath(element1);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
//                    Actions action = new Actions(driver);
//                    action.MoveToElement(toElement).Build().Perform();
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element1, "nem található", true);
//                }
//            }

//            catch (ElementClickInterceptedException exp)
//            {
//                throw exp;
//            }
//            catch (NoSuchElementException exc)
//            {
//                throw exc;
//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("Az elementhez való move nem történt meg határidőn belül");
//            }
//        }

//        public static string GetTextFromSelectedElement(string element, string element2, PropertyTypes elementtype)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(element2))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra");
//            }
//            try
//            {
//                if (elementtype == PropertyTypes.Id)
//                {
//                    IWebElement searchelement = driver.FindElementById(element);
//                    // várakozás addig - 5 sec - amig a kerése megtörténik az elementnek, ha nem => TIMEOUT
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    new SelectElement(searchelement).SelectByText(element2);
//                }
//                if (elementtype == PropertyTypes.Name)
//                {
//                    IWebElement searchelement = driver.FindElementByName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    new SelectElement(searchelement).SelectByText(element2);
//                }
//                if (elementtype == PropertyTypes.ClassName)
//                {
//                    IWebElement searchelement = driver.FindElementByClassName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    new SelectElement(searchelement).SelectByText(element2);
//                }
//                if (elementtype == PropertyTypes.TagName)
//                {
//                    IWebElement searchelement = driver.FindElementByTagName(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    new SelectElement(searchelement).SelectByText(element2);
//                }
//                if (elementtype == PropertyTypes.Xpath)
//                {
//                    IWebElement searchelement = driver.FindElementByXPath(element);
//                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
//                    new SelectElement(searchelement).SelectByText(element2);
//                }
//                else
//                {
//                    LogWriterT.Errorlog(element, "nem található", true);
//                }
//                return string.Empty;
//            }
//            catch (NoSuchElementException exc)
//            {
//                throw exc;
//            }
//            catch (TimeoutException)
//            {
//                new WebDriverException("A művelet timeout-ra futott.");
//                System.Windows.Forms.MessageBox.Show("Az elementhez való move nem történt meg határidőn belül");
//                return string.Empty;
//            }
//        }
//        public static void DragAndDrop(string parentelement, string childelement1, string childelement2)
//        {
//            //a várakozási idő megadása a wait-hez. Maximálisan ennyi ideig fog probálkozni a element keresésével és az akció végrehajtásával.
//            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

//            if (string.IsNullOrEmpty(parentelement) || string.IsNullOrEmpty(childelement1) || string.IsNullOrEmpty(childelement2))
//            {
//                throw new ArgumentException("Valamely paraméter nem került megadásra. Ellenőrizd a megadott elemeket.");
//            }
//            else
//            {
//                try
//                {
//                    //szülő element megtalálása, clickable!
//                    IWebElement parent = driver.FindElement(By.Id(parentelement));

//                    if (parent != null)
//                    {
//                        //gyerekelemek megkeresése
//                        IWebElement childElementfrom = parent.FindElement(By.Id(parentelement)).FindElement(By.Name(childelement1));
//                        // várakozás addig - 5 sec - amig a kerése megtörténik az keresése, ha nem => TIMEOUT
//                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(childElementfrom));
//                        // várakozás addig - 5 sec - amig a kerése megtörténik az element keresése, ha nem => TIMEOUT
//                        IWebElement childElementto = parent.FindElement(By.Id(parentelement)).FindElement(By.Name(childelement2));
//                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(childElementto));
//                        //gyerekelemek vizsgáalta
//                        if (childElementfrom != null || childElementto != null)
//                        {
//                            //draganddrop akció végrehajtása
//                            Actions action = new Actions(driver);
//                            //action.DragAndDrop(childElementfrom,childElementto);
//                            action.MoveToElement(childElementfrom)
//                                .ClickAndHold(childElementfrom)
//                                .MoveToElement(childElementto)
//                                .ClickAndHold(childElementto)
//                                .Release()
//                                .Build()
//                                .Perform();
//                        }
//                        else
//                        {
//                            throw new NoSuchElementException("Valamely gyermekelem nem található.");
//                        }
//                    }
//                }
//                catch (WebDriverException)
//                {
//                    throw new WebDriverException("A művelet timeout-ra futott.");
//                }
//                catch (TimeoutException)
//                {
//                    System.Windows.Forms.MessageBox.Show("Az elementhez való move nem történt meg határidőn belül");                    
//                }
//            }
//        }
//    }
//}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Winium;
using System.Windows.Forms;
using Winium.Elements.Desktop.Extensions;
using ComboBox = Winium.Elements.Desktop.ComboBox;

namespace Modules
{
    public class WDMethods
    {
        public static WiniumDriver driver { get; set; }
        public static string FolderPath { get; set; }
        public static int MaxWaitTime { get; private set; } = 20;
   

        public static void Start(string appPath, string winiumDriverDirectory)
        {
            if (string.IsNullOrEmpty(winiumDriverDirectory) || string.IsNullOrEmpty(appPath))
            {
                throw new ArgumentException("A winiumdriver vagy a tesztelendő program elérési útja nem került megadásra.");
            }

            var options = new DesktopOptions { ApplicationPath = appPath };
            var service = WiniumDriverService.CreateDesktopService(winiumDriverDirectory);
            service.Port = 9999;
            service.SuppressInitialDiagnosticInformation = true;
            service.EnableVerboseLogging = false;
            service.Start();

            try
            {
                driver = new WiniumDriver(service, options, TimeSpan.FromSeconds(10));
            }
            catch (Exception ex)
            {
                service.Dispose();
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        public static void Stop()
        {
            driver?.Close();
            driver?.Quit();
        }

        public static void TakePrtsc(string folderPath, string testName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var picName = $"{testName}_{DateTime.Now:yyyy-MM-dd-HH_mm_ss}.png";
            var screenshotFilename = $"{folderPath}{picName}";

            try
            {
                screenshot.SaveAsFile(screenshotFilename, ScreenshotImageFormat.Png);
            }
            catch
            {
                throw new ArgumentException("A képkészítés nem lehetséges. Győzdj meg arról, hogy megadásra került a szükséges elérési út.");
            }
        }

        private static IWebElement FindElementBy(string element, PropertyTypes elementType)
        {
            switch (elementType)
            {
                case PropertyTypes.Id:
                    return driver.FindElementById(element);
                case PropertyTypes.Name:
                    return driver.FindElementByName(element);
                case PropertyTypes.TagName:
                    return driver.FindElementByTagName(element);
                case PropertyTypes.ClassName:
                    return driver.FindElementByClassName(element);
                case PropertyTypes.Xpath:
                    return driver.FindElementByXPath(element);
                default:
                    throw new ArgumentException("A property típusa nem értelmezhető.");
            }
        }

        private static By GetByLocator(string element, PropertyTypes elementType)
        {
            switch (elementType)
            {
                case PropertyTypes.Id:
                    return By.Id(element);
                case PropertyTypes.Name:
                    return By.Name(element);
                case PropertyTypes.TagName:
                    return By.TagName(element);
                case PropertyTypes.ClassName:
                    return By.ClassName(element);
                case PropertyTypes.Xpath:
                    return By.XPath(element);
                default:
                    throw new ArgumentException("A property típusa nem értelmezhető.");
            }
        }

        public static void Click(string element, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MaxWaitTime));

            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Nem került megadásra element.");
            }

            try
            {
                var searchelement = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                searchelement.Click();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A klikk művelet time out-ra futott", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található", ex);
            }
        }

        public static void Sendkeys(string element, string text, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Nem került megadásra element.");
            }

            try
            {
                var searchelement = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                searchelement.SendKeys(text);
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A írás művelet time out-ra futott", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az elementen nem hajtható végre a művelet.", ex);
            }
        }

        public static void TextClear(string element, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            try
            {
                var searchelement = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchelement));
                searchelement.Clear();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A textclear művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található", ex);
            }
            catch (ElementNotInteractableException ex)
            {
                throw new WebDriverException("Az elementen nem hajtható végre a művelet.", ex);
            }
        }

        public static void DoubleClick(string element, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Az element nem került megadásra.");
            }

            try
            {
                var elementW = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
                new Actions(driver).DoubleClick(elementW).Perform();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A Doubleclick művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található", ex);
            }
            catch (ElementNotVisibleException ex)
            {
                throw new WebDriverException("Az elementen nem hajtható végre a művelet.", ex);
            }
        }

        public static void RightClick(string element, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Az element nem került megadásra.");
            }

            try
            {
                var elementW = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementW));
                new Actions(driver).ContextClick(elementW).Perform();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A Rightclick művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
            catch (ElementNotVisibleException ex)
            {
                throw new WebDriverException("Az elementen nem hajtható végre a művelet.", ex);
            }
        }

        public static int ValueReadAndParse(string element, PropertyTypes elementType, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Az Element nem került megadásra.");
            }

            try
            {
                var location = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(location));
                int message = int.Parse(location.GetAttribute(value));
                System.Windows.Forms.MessageBox.Show($"The inspected item's value is: {message}", "Title");
                return message;
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("Az érték kiolvasás és összehasonlítás művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
        }

        public static void ElementCheck(string element, PropertyTypes elementType, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Az element nem került megadásra.");
            }

            try
            {
                var searchelement = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(searchelement));
                System.Windows.Forms.MessageBox.Show($"Checked value: {searchelement.GetAttribute(value)}", "Title");
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("Az elementcheck művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
        }

        public static void DragAndDrop(string sourceElement, string targetElement, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (string.IsNullOrEmpty(sourceElement) || string.IsNullOrEmpty(targetElement))
            {
                throw new ArgumentException("A forrás vagy a cél element nem került megaásra.");
            }

            try
            {
                var fromElement = FindElementBy(sourceElement, elementType);
                var toElement = FindElementBy(targetElement, elementType);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(fromElement));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));

                new Actions(driver).DragAndDrop(fromElement, toElement).Perform();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("Az draganddrop művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
        }

        public static string GetTextFromSelectedElement(string element, PropertyTypes elementType, string value)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Az element vagy az érték nem került megadásra.");
            }

            try
            {
                var searchelement = FindElementBy(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(searchelement));
                return searchelement.GetAttribute(value);
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("Az GetTextFromSelectedElement művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
        }

        public static void MoveToElement(string element, PropertyTypes elementType)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            if (string.IsNullOrEmpty(element))
            {
                throw new ArgumentException("Az element nem került megadásra.");
            }

            try
            {
                By byElement = GetByLocator(element, elementType);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(byElement));
                var elementW = FindElementBy(element, elementType);
                new Actions(driver).MoveToElement(elementW).Perform();
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("Az movetoelement művelet time out-ra futott.", ex);
            }
            catch (NoSuchElementException ex)
            {
                throw new WebDriverException("Az element nem található.", ex);
            }
        }

        public static void ScrollToElementAndClick(string element, PropertyTypes elementType, string name)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            if (string.IsNullOrEmpty(element) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Valamely paraméter nem került megadásra");
            }

            try
            {
                IWebElement toElement;

                switch (elementType)
                {
                    case PropertyTypes.Id:
                        toElement = driver.FindElementById(element);
                        break;
                    case PropertyTypes.ClassName:
                        toElement = driver.FindElementByClassName(element);
                        break;
                    case PropertyTypes.Name:
                        toElement = driver.FindElementByName(element);
                        break;
                    case PropertyTypes.TagName:
                        toElement = driver.FindElementByTagName(element);
                        break;
                    case PropertyTypes.Xpath:
                        toElement = driver.FindElementByXPath(element);
                        break;
                    default:
                        throw new ArgumentException("Invalid property type.");
                }

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(toElement));
                ComboBox comboBox = new ComboBox(toElement);
                comboBox.Expand();
                comboBox.ScrollTo(By.Name(name));
                toElement.FindElement(By.Name(name)).Click();
            }
            catch (NoSuchElementException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw new WebDriverException("A művelet timeout-ra futott.", ex);
            }
            catch (Exception ex)
            {
                throw new WebDriverException("Hiba történt az elementhez való görgetés során.", ex);
            }
        }
    }
}
