using NUnit.Framework;
using Modules;
using Winium;
using System;
using OpenQA.Selenium.Winium;
using System.Windows.Forms;
using OpenQA.Selenium;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Applitools;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TruMES_Test
{
    public class ReleaseTest
    {
        public static WiniumDriver driver { get; set; }
        private const string WiniumDriverDirectory = @"C:\Winiumdriver\";

        string testname = "releasetest240726";

        string folderpath = "C:\\WorkSpace\\240726\\";

        string database = "KONZ TESZT(PROXMOX)";
        string felhasznalo = "dmsdba";
        string password = "gum1cukor";

        string cikkszam = "AUTITEM356B";        /*csak nagybet�vel!!!*/
        /*csak nagybet�vel!!!*/
        string cikkmegnevezes = "AUTITEM356B";    /*csak nagybet�vel!!!*/
        string cikkcsopcode = "31";
        string vevoilistaAr = "651";
        string vevoilistaArMargin = "10";
        string partner = "AUTCOMPY356B";   /*csak nagybet�vel!!!*/
        string providnev = "AT356B";       /*csak nagybet�vel!!!*/
        string szamlazasiAddress = "Pont az �t 23";
        string levelezesiAddress = "Pont Nem az utca 22";
        string partnermail = "company356b@mail.hu";  /*csak kisbet�vel!!!*/
        string taxcode = "11111111-3-48";
        string partnernote = "megjegyz�s partner240131";

        string cikkszam2 = "MEGRENDCIKK15B";
        string cikkmegnevezes2 = "CMMEGRENDCIKK15B";
        string cikkcsopcode2 = "8";

        string partner2 = "AUTCBSZ7B";   /*csak nagybet�vel!!!*/
        string providnev2 = "AB7B";       /*csak nagybet�vel!!!*/
        string szamlazasiAddress2 = "Pont az �t 23";
        string levelezesiAddress2 = "Pont Nem az utca 22";
        string partnermail2 = "atb7b@mail.hu";  /*csak kisbet�vel!!!*/
        string taxcode2 = "11111111-3-47";

        string projektmegnkulsocode = "releasetest240131";

        string megrendelesmennyiseg = "10";

        string megrendelesegysegar = "1011";

        string szallito = "CSERNYIK �KOS";
        string koltseghely = "Test";

        string szallitolevel = "szlev000029";
        string szamlaszam = "szlsz�m000029";
        string szallitolevel2 = "bszlev000029";
        string szamlaszam2 = "bszlsz�m000029";

        string today = DateTime.Today.ToString("yyyy/MM/dd.");
        string muszakrend = "d�lel�tt";
        string munkat�rs = "G�PKEZEL� ZOLT�N";
        string reszleg = "R009 - MEGMUNK�L�";
        string appPath = "T:\\dms\\bin\\k2dfactory\\RunK2DFactoryApplication.exe";

        // master - "T:\\dms\\bin\\k2dfactory\\RunK2DFactoryApplication.exe";
        // tesztveri� - lev�lben szerepl� el�r�si �t!

        [SetUp]
        public void Setup()
        {
            WDMethods.Start(appPath, WiniumDriverDirectory);
            WaitTime.Wait(4);
            LogWriterT.LogDirFileCreate(folderpath, testname);
            WaitTime.Wait(1);
        }

        [Test]
        public void Releasetest()
        {
            // Bejelentkez�s

            WDMethods.TextClear("tbFelhasznalo", PropertyTypes.Id);
            WDMethods.Sendkeys("tbFelhasznalo", felhasznalo, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "felhaszn�l� be�rva");

            WDMethods.Sendkeys("tbJelszo", password, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "pw be�rva");

            WDMethods.Click("cbAdatbazisok", PropertyTypes.Id);
            SendKeys.SendWait("{F4}");
            WDMethods.ScrollToElementAndClick("cbAdatbazisok", PropertyTypes.Id, database);
            LogWriterT.WriteLog(folderpath, testname, "db kiv�lasztva");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("Bejelentkez�s", PropertyTypes.Name);

            LogWriterT.WriteLog(folderpath, testname, "bejelentkez�s elind�tva");


            //    WDMethods.Click("SETTINGS_TAB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "be�ll�t�sok tab katt");

            //    WDMethods.Click("MAINTENANCE_ORDINARY", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "t�rzsek katt");

            //    WDMethods.WDSendkeys("Keres�s...", "cikkek", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkek be�rva");

            //    WDMethods.Click("MAINTENANCE_PARTS", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkekre katt");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /*profil bet�lt�se cikkek*/

            //    WDMethods.RightClick("PART_DropDownButton", PropertyTypes.Id);
            //    WDMethods.RightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.Click("Releasetest", PropertyTypes.Name);
            //    WDMethods.Click("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.Click("PARTS_ADD_BUTTON", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "�j cikkek hozz�ad�s");

            //    WDMethods.Click("RadRibbonButton", PropertyTypes.ClassName);
            //    LogWriterT.WriteLog(folderpath, testname, "�j cikkek katt");

            //    WDMethods.Sendkeys("CodeTextBox", cikkszam, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkeksz�m be�r�s");

            //    WDMethods.Sendkeys("PartNational", cikkmegnevezes, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "cikkmegnevez�s be�r�s");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.Click("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkcsoport v�laszt� katt");

            //    WDMethods.Sendkeys("FilterTextBoxEditor_0", cikkcsopcode, PropertyTypes.Id);
            //    WDMethods.driver.FindElement(By.Id("FilterTextBoxEditor_0")).Submit();
            //    LogWriterT.WriteLog(folderpath, testname, "cikkcsoport be�r�s");

            //    //WDMethods.Click("PART_DropDownButton", PropertyTypes.Id); 
            //    //LogWriterT.WriteLog(folderpath, testname, "cikkcsoport PART_DropDownButton katt");

            //    WDMethods.Click(cikkcsopcode, PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkcsoport katt");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.Click("SelectCommand", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "OK katt");

            //    WDMethods.Sendkeys("PartBarCode", cikkmegnevezes, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk vonalk�d be�r�s");
            ;
            //    WDMethods.Sendkeys("PartExtCode", cikkmegnevezes, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk vonalk�d be�r�s");

            //    WDMethods.Sendkeys("CustomerListPrice", vevoilistaAr, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk vev�i lista�r be�r�s");

            //    WDMethods.Sendkeys("MarginNtb", vevoilistaArMargin, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk margin be�r�s");

            //    WDMethods.Sendkeys("PartUnitWeight", "21", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk nett� s�ly be�r�s");
            //    WaitTime.Wait(1);

            //    WDMethods.Sendkeys("PartBruttoWeight", "25", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk brutt� s�ly be�r�s");

            //    WDMethods.ScrollToElementAndClick("PartBruttoWeightUnitType", PropertyTypes.Id, "GR");
            //    LogWriterT.WriteLog(folderpath, testname, "bruttos�ly t�pus katt");;

            //    WDMethods.Click("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "ment�s");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk t�rzs karbantart� ablak bez�r�s");

            //    /* Cikk 2 */

            //    WDMethods.Click("PARTS_ADD_BUTTON", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "�j cikkek hozz�ad�s");

            //    WDMethods.Click("RadRibbonButton", PropertyTypes.ClassName);
            //    LogWriterT.WriteLog(folderpath, testname, "�j cikkek katt");

            //    WDMethods.Sendkeys("CodeTextBox", cikkszam2, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkeksz�m be�r�s");

            //    WDMethods.Sendkeys("PartNational", cikkmegnevezes2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "cikkmegnevez�s be�r�s");

            //    WDMethods.Click("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkcsoport v�laszt� katt");

            //    WDMethods.Sendkeys("FilterTextBoxEditor_0", cikkcsopcode2, PropertyTypes.Id);
            //    WDMethods.driver.FindElement(By.Id("FilterTextBoxEditor_0")).Submit();
            //    LogWriterT.WriteLog(folderpath, testname, "cikkcsoport be�r�s");

            //    //WDMethods.WDClick("PART_DropDownButton", PropertyTypes.Id); 
            //    //LogWriterT.WriteLog(folderpath, testname, "cikkcsoport PART_DropDownButton katt");

            //    WDMethods.WDClick(cikkcsopcode2, PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "cikkcsoport katt");

            //    WDMethods.WDClick("SelectCommand", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "OK katt");

            //    WDMethods.WDSendkeys("CustomerListPrice", vevoilistaAr, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk vev�i lista�r be�r�s");

            //    WDMethods.WDSendkeys("MarginNtb", vevoilistaArMargin, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk margin be�r�s");

            //    WDMethods.WDSendkeys("PartUnitWeight", "21", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk nett� s�ly be�r�s");

            //    WDMethods.WDSendkeys("PartBruttoWeight", "25", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk brutt� s�ly be�r�s");

            //    WDMethods.WDScrollToElementAndClick("PartBruttoWeightUnitType", PropertyTypes.Id, "GR");
            //    LogWriterT.WriteLog(folderpath, testname, "bruttos�ly t�pus katt");

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "ment�s");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk t�rzs karbantart� ablak bez�r�s");


            //    /*-------------------be�ll�t�sok partnerek-------------------*/

            //    WDMethods.TextClear("Keres�s...", PropertyTypes.Name);
            //    WDMethods.Sendkeys("Keres�s...", "partnerek", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "partnerek be�rva");

            //    WDMethods.Click("MAINTENANCE_PARTNERS", PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "partnerek katt");

            //    /*profil bet�lt�sse partnerek*/

            //    WDMethods.RightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WDMethods.RightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.Click("Releasetest", PropertyTypes.Name);
            //    WDMethods.Click("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /* vev� r�gz�t�se */

            //    WDMethods.Click("addPartner_btn", PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "hozz�ad�s katt");

            //    WDMethods.Sendkeys("PartnerName", partner, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "partner n�v be�rva");

            //    WDMethods.Sendkeys("PartnerNickName", providnev, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "partner r�vidn�v be�rva");

            //    WDMethods.Sendkeys("Keres�s...", "Szolnok 5000", PropertyTypes.Name); ;
            //    LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");
            //    SendKeys.SendWait("{Enter}");

            //    //WDMethods.Click("Szolnok 5000", PropertyTypes.Name); ;
            //    //LogWriterT.WriteLog(folderpath, testname, "v�ros n�v katt");

            //    WDMethods.Sendkeys("PartnerInvAddress", szamlazasiAddress, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");

            //    WDMethods.Click("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            //    WDMethods.Click("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "c�m m�sol�s be-kikapcsol�s katt");

            //    WDMethods.TextClear("PartnerCorAddress", PropertyTypes.Id);
            //    WDMethods.Sendkeys("PartnerCorAddress", levelezesiAddress, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "levelez�si c�m be�rva");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.Sendkeys("PartnerEmail", partnermail, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "email be�rva");

            //    WDMethods.ScrollToElementAndClick("PartnerType", PropertyTypes.Id, "T�rsas v�llalkoz�s");
            //    LogWriterT.WriteLog(folderpath, testname, "partner type kiv�laszt�s");

            //    WDMethods.ScrollToElementAndClick("PartnerCompanyForm", PropertyTypes.Id, "KFT.");
            //    LogWriterT.WriteLog(folderpath, testname, "partner form kiv�laszt�s");

            //    WDMethods.ScrollToElementAndClick("PartnerDepartmentType", PropertyTypes.Id, "Ipar, �p�t�ipar");
            //    LogWriterT.WriteLog(folderpath, testname, "�gazat kiv�laszt�sa");

            //    WDMethods.ScrollToElementAndClick("PartnerPayClass", PropertyTypes.Id, "J�l fizet�");
            //    LogWriterT.WriteLog(folderpath, testname, "fizet�si min�s�t�s katt");

            //    WDMethods.ScrollToElementAndClick("DefaultCurrency", PropertyTypes.Id, "HUF");
            //    LogWriterT.WriteLog(folderpath, testname, "alap�rtelmezett p�nznem kiv.");

            //    WDMethods.Sendkeys("PartnerTaxaccount", taxcode, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "tax be�rva");

            //    WDMethods.Sendkeys("PartnerEuTaxaccount", taxcode, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "taxeu be�rva");

            //    WDMethods.Sendkeys("PartnerNote", partnernote, PropertyTypes.Id); 
            //    LogWriterT.WriteLog(folderpath, testname, "partner megjegyz�s be�rva");

            //    WDMethods.Click("SaveBtn", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ment�s katt");

            //    WDMethods.Click("Partnerrel�ci� kiv�laszt�sa", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�laszt�sa katt");

            //    WDMethods.Click("CellElement_3_0", PropertyTypes.Id);
            //    WDMethods.Click("CellElement_5_0", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�lasztva ");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.Click("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "rel�ci� ment�s");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.Click("btClose", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "bez�r�s katt");

            //    /* besz�ll�t� r�gz�t�se */

            //    WDMethods.WDClick("addPartner_btn", PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "hozz�ad�s katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerName", partner2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "partner n�v be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerNickName", providnev2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "partner r�vidn�v be�rva");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);


            //    WDMethods.WDSendkeys("Keres�s...", "Szolnok 5000", PropertyTypes.Name); ;
            //    LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");
            //    WaitTime.Wait(1);
            //    SendKeys.SendWait("{Enter}");

            //    //WDMethods.WDClick("Szolnok 5000", PropertyTypes.Name); ;
            //    //LogWriterT.WriteLog(folderpath, testname, "v�ros n�v katt");
            //    //WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerInvAddress", szamlazasiAddress2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            //    WDMethods.WDClick("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "c�m m�sol�s be-kikapcsol�s katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.WDTextClear("PartnerCorAddress", PropertyTypes.Id);
            //    WDMethods.WDSendkeys("PartnerCorAddress", levelezesiAddress2, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "levelez�si c�m be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerEmail", partnermail2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "email be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("PartnerType", PropertyTypes.Id, "T�rsas v�llalkoz�s");
            //    LogWriterT.WriteLog(folderpath, testname, "partner type kiv�laszt�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("PartnerCompanyForm", PropertyTypes.Id, "KFT.");
            //    LogWriterT.WriteLog(folderpath, testname, "partner form kiv�laszt�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("PartnerDepartmentType", PropertyTypes.Id, "Ipar, �p�t�ipar");
            //    LogWriterT.WriteLog(folderpath, testname, "�gazat kiv�laszt�sa");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("PartnerPayClass", PropertyTypes.Id, "J�l fizet�");
            //    LogWriterT.WriteLog(folderpath, testname, "fizet�si min�s�t�s katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("DefaultCurrency", PropertyTypes.Id, "HUF");
            //    LogWriterT.WriteLog(folderpath, testname, "alap�rtelmezett p�nznem kiv.");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerTaxaccount", taxcode2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "tax be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerEuTaxaccount", taxcode2, PropertyTypes.Id); ;
            //    LogWriterT.WriteLog(folderpath, testname, "taxeu be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("PartnerNote", partnernote, PropertyTypes.Id); ;

            //    LogWriterT.WriteLog(folderpath, testname, "megjegyz�s be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("SaveBtn", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ment�s katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Partnerrel�ci� kiv�laszt�sa", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�laszt�sa katt");
            //    WaitTime.Wait(3);

            //    WDMethods.WDClick("CellElement_3_0", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�lasztva ");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "rel�ci� ment�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Alkatr�sz besz�ll�t�", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("CheckBox", PropertyTypes.ClassName);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("Ment�s", PropertyTypes.Name);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("PART_CloseButton", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Sz�ll�t�", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("CellElement_1_0", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("Ment�s", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("PART_CloseButton", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "bez�r�s katt");
            //    WaitTime.Wait(1);

            //    /*-------------------projekt r�gz�t�se-------------------*/

            //    WDMethods.WDClick("Friss�t�s", PropertyTypes.Name);
            //    WDMethods.WDClick("Le�ll�t�s", PropertyTypes.Name);

            //    WDMethods.WDClick("MAIN_HOME_TAB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "f�oldal katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("PROJECT_BROWSER", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "b�ng�sz� katt");
            //    WaitTime.Wait(3);
            //    WDMethods.WDClick("Friss�t�s", PropertyTypes.Name);
            //    WaitTime.Wait(3);
            //    WDMethods.WDClick("Nem", PropertyTypes.Name);
            //    WaitTime.Wait(5);

            //    /*profil bet�lt�se f�oldal/b�ng�sz�*/

            //    WDMethods.WDRightClick("Partner", PropertyTypes.Id);
            //    WaitTime.Wait(3);
            //    WDMethods.WDClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("PART_ExpanderIcon", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("PROJECT_BROWSER_ADDPROJ", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "projekt hozz�ad�s katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "projekt hozz�ad�s katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("FilterInputTexBox", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("FilterInputTexBox", partner, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "partner be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� ind�t�s katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Ok gomb");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("ProductTypeRCB", PropertyTypes.Id, "Projekt alap� gy�rt�s");
            //    LogWriterT.WriteLog(folderpath, testname, "gy�rt�s t�pus katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("ProjectType", PropertyTypes.Id, "VEV�I GENER�L�SSAL");
            //    LogWriterT.WriteLog(folderpath, testname, "projekt t�pus kiv�lasztva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("ProjectNationalTB", projektmegnkulsocode, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "projekt megnevez�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("ContractNumTB", projektmegnkulsocode, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "szerz�d�s sz�m");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("Code", projektmegnkulsocode, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "k�ls� k�d");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("ProjectCodeRefreshBT", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "code gen");
            //    WaitTime.Wait(1);



            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Ok gomb");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ablak bez�r�s");
            //    WaitTime.Wait(1);


            //    /*-------------------l�trehozott projekt megnyit�sa-------------------*/


            //    WDMethods.WDSendkeys("ProjectNameTb", projektmegnkulsocode, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "projekt megnevez�s be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Friss�t�s", PropertyTypes.Name);

            //    WDMethods.WDDoubleClick(projektmegnkulsocode, PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "projekt katt");
            //    WaitTime.Wait(2);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /*-------------------megrendele�s r�gz�t�se projekt tab alatt------------------*/


            //    WDMethods.WDClick("MAIN_HOME_TAB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "MAIN_HOME_TAB katt");
            //    WaitTime.Wait(1); ;

            //    WDMethods.WDClick("projectTab", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "projectTab projekt megnyit�sa");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("PROJECT_ORDER", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "PROJECT_ORDER megrendel�s katt");
            //    WaitTime.Wait(3);

            //    WDMethods.WDClick("ORDER_ADDPO", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ORDER_ADDPO megrendel�s hozz�ad�s katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDTextClear("PoNumberTB", PropertyTypes.Id);
            //    WDMethods.WDSendkeys("PoNumberTB", projektmegnkulsocode, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrend sz�m be�r�sa");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("ORDER_SAVEPO", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ment�s katt");
            //    WaitTime.Wait(3);

            //    WDMethods.WDClick("ItemEditBtn", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ItemEditBtn katt");
            //    WaitTime.Wait(3);

            //    WDMethods.WDClick("PART_HeaderRow", PropertyTypes.Id);
            //    WDMethods.WDRightClick("PART_DropDownButton", PropertyTypes.Id);
            //    WDMethods.WDRightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(2);

            //    /*cikk hozz�ad�sa 1*/


            //    WDMethods.WDClick("ORDER_NEWPOITEM", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ORDER_NEWPOITEM katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("Cell_0_3", "APF�T", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk be�rva");
            //    WaitTime.Wait(1);
            //    SendKeys.SendWait("{Enter}");
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("APF�T 0404", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk kiv�lasztva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("CellElement_0_11", "2", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk mennyis�g be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("CellElement_0_12", "358", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk egys�g�r be�rva");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /*cikk hozz�ad�sa 2*/

            //    WDMethods.WDClick("ORDER_NEWPOITEM", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ORDER_NEWPOITEM katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("Cell_1_3", cikkszam, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk be�rva");
            //    WaitTime.Wait(1);
            //    /*enteres kiv�laszt�s cikksz�m*/
            //    SendKeys.SendWait("{Enter}");
            //    LogWriterT.WriteLog(folderpath, testname, "cikk kiv�lasztva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("CellElement_1_11", megrendelesmennyiseg, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk mennyis�g be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("CellElement_1_12", megrendelesegysegar, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk egys�g�r be�rva");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    //WDMethods.WDClick("CellElement_0_1", PropertyTypes.Id);
            //    //LogWriterT.WriteLog(folderpath, testname, "cikkszam2 checkbox katt");
            //    //WaitTime.Wait(1);

            //    WDMethods.WDClick("ORDER_NEWPOITEMS", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDSendkeys("textSource", "megrendcikk", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("CellElement_0_1", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("CellElement_1_1", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("CellElement_2_1", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WaitTime.Wait(3);

            //    WDMethods.WDSendkeys("CellElement_2_11", "9", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk mennyis�g be�rva");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDSendkeys("CellElement_3_11", "11", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk mennyis�g be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("CellElement_4_11", "10", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk mennyis�g be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.WDSendkeys("CellElement_4_12", "358", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk egys�g�r be�rva");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);


            //    WDMethods.WDClick("OrderDataTBI", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrendel�s adataira katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("ORDER_SAVEPO", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ORDER_SAVEPO megendel�s ment�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("ORDER_READYPO", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "ORDER_READYPO feldolgozva katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "btYes");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Ok gomb");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "btYes");
            //    WaitTime.Wait(2);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);
            //    WDMethods.TakePrtsc(folderpath, testname);


            //    /*-------------------sorzatgy�rt�s/megrendel�sek/ belt�lt�s------------------*/


            //    WDMethods.WDClick("ProductionRadRibbonTab", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "logisztika tabra katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("SERIE_ORDER", PropertyTypes.Id);
            //    WaitTime.Wait(3);

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WDMethods.WDRightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("ORDER_REFRESH", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "frisst�s megt�rt�nt");
            //    WaitTime.Wait(13);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /*-------------------megrendel�s anyagig�nyb�l------------------*/

            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.WDClick("TRANSPORTMAINTENANCETAB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "logisztika tabra katt");
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("ORDERS_OFFERS_MATERIAL", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrendel�sek, aj�nlatok altab");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("3", PropertyTypes.Id); //�rdekes ID!!!
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�nye tab");
            //    WaitTime.Wait(7);

            //    /*profil bet�lt�se anyagig�nyek*/

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(3);

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("GridView sz�r� v�lt�s", PropertyTypes.Name);
            //    WaitTime.Wait(1);

            //    //WDMethods.WDRightClick("PART_DropDownButton", PropertyTypes.Id);
            //    //WDMethods.WDClick("�sszes sz�r� t�rl�se", PropertyTypes.Name);
            //    //WDMethods.WDRightClick("PART_DropDownButton", PropertyTypes.Id);
            //    //WDMethods.WDClick("GridView sz�r� v�lt�s", PropertyTypes.Name);


            //    WDMethods.WDSendkeys("FilterStringEditor_11", projektmegnkulsocode, PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�r�be �r�s");
            //    WaitTime.Wait(1);
            //    SendKeys.SendWait("{ENTER}");
            //    WaitTime.Wait(10);
            //    WDMethods.WDClick("CellElement_0_3", PropertyTypes.Id);
            //    WDMethods.WDClick("CellElement_1_3", PropertyTypes.Id);
            //    WDMethods.WDClick("CellElement_2_3", PropertyTypes.Id);
            //    WDMethods.WDClick("CellElement_3_3", PropertyTypes.Id);


            //    WDMethods.WDClick("OPEN_BRUTTO_SHEET_NEW_ORDER", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "rendel�s ind�t�sa katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�ll�t� keres� katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("FilterInputTexBox", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("FilterInputTexBox", szallito, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "partner be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� ind�t�s katt");
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Ok gomb");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("AccountInvoiceGroupSelector", PropertyTypes.Id, koltseghely);
            //    LogWriterT.WriteLog(folderpath, testname, "k�lts�ghely kiv�laszt�sa");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WDMethods.WDClick("Rendel�s lez�r�sa", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "rendel�s lez�r�sa");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "rendel�s lez�rva");
            //    WaitTime.Wait(2);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);

            //    /*-------------------�j anyagig�ny r�gz�t�se-------------------*/


            //    WDMethods.WDClick("NEW_OPEN_BRUTTO_SHEET_PARTS", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�ny szerk. katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "projekt hozz�ad�s katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDSendkeys("textSource", cikkszam, PropertyTypes.Id);
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� ind�t�s katt");
            //    WaitTime.Wait(5);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.WDDoubleClick("Ok", PropertyTypes.Name);

            //    WDMethods.WDSendkeys("DispQuantityNTB", megrendelesmennyiseg, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "mennyis�g be�r�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("searchBox", projektmegnkulsocode, PropertyTypes.Id);
            //    WaitTime.Wait(3);
            //    SendKeys.SendWait("{Enter}");

            //    WDMethods.WDScrollToElementAndClick("SORCB", PropertyTypes.Id, cikkszam);
            //    WDMethods.WDScrollToElementAndClick("DepotSelector", PropertyTypes.Id, "IRODA");
            //    WDMethods.WDScrollToElementAndClick("StoreSelector", PropertyTypes.Id, "AALOGRAKJH");
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�ny ment�s el�tt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("Ment�s �s bez�r", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�ny ment�s");
            //    WaitTime.Wait(4);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /* anyag ig�ny 2*/

            //    WDMethods.WDClick("NEW_OPEN_BRUTTO_SHEET_PARTS", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�ny szerk. katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "cikk hozz�ad�s katt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDSendkeys("textSource", cikkszam2, PropertyTypes.Id);
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� ind�t�s katt");
            //    WaitTime.Wait(5);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.WDDoubleClick("Ok", PropertyTypes.Name);

            //    WDMethods.WDSendkeys("DispQuantityNTB", megrendelesmennyiseg, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "mennyis�g be�r�s");
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("DepotSelector", PropertyTypes.Id, "IRODA");
            //    WDMethods.WDScrollToElementAndClick("StoreSelector", PropertyTypes.Id, "AALOGRAKJH");
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�ny ment�s el�tt");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("Ment�s �s bez�r", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "anyagig�ny ment�s");
            //    WaitTime.Wait(4);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    /* megrendel�s 2 ind�t�sa */

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("�sszes sz�r� t�rl�se", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDSendkeys("FilterStringEditor_7", cikkszam2, PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�r�be �r�s");
            //    WaitTime.Wait(1);
            //    SendKeys.SendWait("{ENTER}");
            //    WaitTime.Wait(10);
            //    WDMethods.WDClick("CellElement_0_3", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("OPEN_BRUTTO_SHEET_NEW_ORDER", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "rendel�s ind�t�sa katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�ll�t� keres� katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("FilterInputTexBox", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� katt");
            //    WaitTime.Wait(1);

            //    WDMethods.WDSendkeys("FilterInputTexBox", partner2, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "partner be�rva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "keres� ind�t�s katt");
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "Ok gomb");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    WDMethods.WDScrollToElementAndClick("AccountInvoiceGroupSelector", PropertyTypes.Id, koltseghely);
            //    LogWriterT.WriteLog(folderpath, testname, "k�lts�ghely kiv�laszt�sa");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WDMethods.WDClick("Rendel�s lez�r�sa", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "rendel�s lez�r�sa");
            //    WaitTime.Wait(1);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "rendel�s lez�rva");
            //    WaitTime.Wait(2);
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);


            //    /* megrendel�s r�gz�t�se/

            //    //WDMethods.WDClick("ORDERS_BROWSER_ADDPO", PropertyTypes.Id);
            //    //WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    //WDMethods.WDSendkeys("textSource", szallito, PropertyTypes.Id);
            //    //WDMethods.WDClick("AttributeIcon", PropertyTypes.Id); 
            //    //WDMethods.WDClick("Ok", PropertyTypes.Name); 
            //    //WDMethods.WDClick("btNo", PropertyTypes.Id);
            //    //WDMethods.WDScrollToElementAndClick("StoreSelector", PropertyTypes.Id, "AALOGRAKJH");
            //    //WDMethods.WDScrollToElementAndClick("AccountInvoiceGroupSelector", PropertyTypes.Id, "Test");
            //    //WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    //WDMethods.WDClick("",PropertyTypes.Name);


            //    /*-------------------bet�rol�s megrendel�s alapj�n-------------------*/


            //    WDMethods.WDClick("TRANSPORTMAINTENANCETAB", PropertyTypes.Id);
            //    WDMethods.WDClick("MATERIAL_STORE_IN", PropertyTypes.Id);
            //    WaitTime.Wait(2);

            //    /*profil bet�lt�se bet�rol�s*/

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(1);


            //    WDMethods.WDClick("PART_ExpanderIcon", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(1);

            //    SendKeys.SendWait("{PGDN}");

            //    WDMethods.WDMoveToElement("MATERIAL_STORE_IN_ADD", PropertyTypes.Id);

            //    WDMethods.WDClick("MATERIAL_STORE_IN_ADD", PropertyTypes.Id);
            //    WaitTime.Wait(3);

            //    //WDMethods.WDSendkeys("AutoComplete", szallito, PropertyTypes.Id);
            //    //SendKeys.SendWait("{ENTER}");
            //    //PrtSc.TakePrtsc(folderpath, testname);
            //    //LogWriterT.WriteLog(folderpath, testname, "sz�ll�t� kiv�lasztva");
            //    //WaitTime.Wait(1);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDSendkeys("textSource", szallito, PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "partner kiv�lasztva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);

            //    WDMethods.WDSendkeys("CertifNoTB", szallitolevel, PropertyTypes.Id);
            //    WDMethods.WDSendkeys("DelivInvNoTB", szamlaszam, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�ll�t�lev�l, sz�mlasz�m be�rva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Ment�s", PropertyTypes.Name);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Megrendel�sek", PropertyTypes.Name);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("allSelectCB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrendel�s t�tel kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WaitTime.Wait(1);

            //    if (WDMethods.driver.FindElement(By.Name("Figyelem")).Displayed && WDMethods.driver.FindElement(By.Name("Figyelem")).Enabled)
            //    {
            //        EgysegarmodBetar();
            //    }

            //    WDMethods.WDClick("storein_btn", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    LogWriterT.WriteLog(folderpath, testname, "bet�rol�s ind�tva");
            //    WDMethods.TakePrtsc(folderpath, testname);

            //    void EgysegarmodBetar()
            //    {
            //        while (true)
            //        {
            //            try
            //            {
            //                IWebElement figyelemElement = WDMethods.driver.FindElement(By.Name("Figyelem"));

            //                if (figyelemElement.Displayed)
            //                {
            //                    try
            //                    {
            //                        figyelemElement.Click();
            //                        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //                        figyelemElement = WDMethods.driver.FindElement(By.Name("Figyelem"));

            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        LogWriterT.WriteLog(folderpath, testname, $"Nem hajthat� v�gre a gomb megnyom�sa: {ex.Message}");
            //                        //Log - exception!
            //                        break;
            //                    }
            //                }
            //                else
            //                {
            //                    //Ha az element nem ker�l megjelen�t�sre
            //                    break; // Kil�p�s a ciklusb�l
            //                }
            //            }
            //            catch (NoSuchElementException)
            //            {
            //                //Ha nem tal�lhat� az element
            //                LogWriterT.WriteLog(folderpath, testname, "Element nem tal�lhat�");
            //                break; // Kil�p�s a ciklusb�l
            //            }
            //        }
            //    }


            //    WaitTime.Wait(2);

            //    /* bet�rol�s 2 */

            //    WDMethods.WDMoveToElement("MATERIAL_STORE_IN_ADD", PropertyTypes.Id);

            //    WDMethods.WDClick("MATERIAL_STORE_IN_ADD", PropertyTypes.Id);
            //    WaitTime.Wait(3);

            //    WDMethods.WDSendkeys("AutoComplete", szallito, PropertyTypes.Id);
            //    SendKeys.SendWait("{ENTER}");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�ll�t� kiv�lasztva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDSendkeys("textSource", partner2, PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("AttributeIcon", PropertyTypes.Id);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "partner kiv�lasztva");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("btYes", PropertyTypes.Id);

            //    WDMethods.WDSendkeys("CertifNoTB", szallitolevel2, PropertyTypes.Id);
            //    WDMethods.WDSendkeys("DelivInvNoTB", szamlaszam2, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�ll�t�lev�l, sz�mlasz�m be�rva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Ment�s", PropertyTypes.Name);
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Megrendel�sek", PropertyTypes.Name);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("allSelectCB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrendel�s t�tel kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WaitTime.Wait(1);


            //    if (WDMethods.driver.FindElement(By.Name("Figyelem")).Displayed && WDMethods.driver.FindElement(By.Name("Figyelem")).Enabled)
            //    {
            //        EgysegarmodBetar();
            //    }


            //    WDMethods.WDClick("save_btn", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("storein_btn", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    LogWriterT.WriteLog(folderpath, testname, "bet�rol�s ind�tva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(2);

            //    /* sztorn� */
            //    WDMethods.WDSendkeys("FilterStringEditor_0", partner2, PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    SendKeys.SendWait("{ENTER}");
            //    WaitTime.Wait(2);
            //    WDMethods.WDDoubleClick(partner2, PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.Click("NEWSTOREINHEADSTORNO",PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.Click("btYes", PropertyTypes.Id);
            //    WaitTime.Wait(2);            
            //    LogWriterT.WriteLog(folderpath, testname, "bet�rol�s sztorno");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.Click("btClose", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    /*-------------------Megnrendel�s megnyit�sa-------------*/

            //    /*megrendel�s profil bet�lt�s*/

            //    WDMethods.WDClick("TRANSPORTMAINTENANCETAB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "logisztika tabra katt");
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("ORDERS_OFFERS_MATERIAL", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrendel�sek, aj�nlatok altab");
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("OrdersTab", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "megrendel�sek, aj�nlatok/megrendel�sek ");
            //    WaitTime.Wait(2);

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WDMethods.WDRightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WaitTime.Wait(1);

            //    /*megrendel�s megnyit�sa*/

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick("GridView sz�r� v�lt�s", PropertyTypes.Name);
            //    WaitTime.Wait(1);


            //    WDMethods.WDSendkeys("FilterStringEditor_2", partner2, PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "sz�r�be �r�s");
            //    WaitTime.Wait(1);
            //    SendKeys.SendWait("{ENTER}");
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("CellElement_0_2", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("btMaximize", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("CellElement_0_0", PropertyTypes.Id);
            //    WaitTime.Wait(1);
            //    WDMethods.WDClick("btClose", PropertyTypes.Id);
            //    WaitTime.Wait(1);

            //    /*-------------------vev�i �rt�kes�t�s-------------------*/

            //    WDMethods.WDClick("TRANSPORTMAINTENANCETAB", PropertyTypes.Id);
            //    WDMethods.WDClick("CUST_ORDER", PropertyTypes.Id);
            //    WaitTime.Wait(4);

            //    /*profil bet�lt�se vev�i �rt�kes�t�s*/

            //    WDMethods.WDRightClick("PART_HeaderRow", PropertyTypes.Id);
            //    WDMethods.WDClick("GridView profil bet�lt�se", PropertyTypes.Name);
            //    WDMethods.WDClick("Releasetest", PropertyTypes.Name);
            //    WDMethods.WDClick("OkButton", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("CUST_ORDER_REFRESH", PropertyTypes.Id);
            //    WaitTime.Wait(4);

            //    WDMethods.WDSendkeys("FilterStringEditor_4", partner, PropertyTypes.Id);
            //    SendKeys.SendWait("{ENTER}");
            //    WaitTime.Wait(2);
            //    WDMethods.WDClick(partner, PropertyTypes.Name);
            //    WaitTime.Wait(4);
            //    WDMethods.WDClick(partner, PropertyTypes.Name);

            //    WDMethods.WDClick("CUST_ORDER_EDIT", PropertyTypes.Id);
            //    WaitTime.Wait(3);
            //    WDMethods.WDClick("Ment�s", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "vev�i �rt�kes�t�s megnyitva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(3);


            //    WDMethods.WDClick("Kit�rol�s", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDMoveToElement("Popup", PropertyTypes.ClassName);
            //    WDMethods.WDClick("RadRibbonButton", PropertyTypes.ClassName);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("allSelectCB", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "kit�rol�s t�tel/t�telek kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(1);


            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WaitTime.Wait(3);
            //    LogWriterT.WriteLog(folderpath, testname, "kit�rol�s ind�tva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(4);

            //    /*g�ngy�leg!*/
            //    //if (WDMethods.driver.FindElement(WiniumBy.Id("btClose").Displayed)
            //    //{
            //    //    WDMethods.WDClick("btClose", PropertyTypes.Id);
            //    //    WaitTime.Wait(2);
            //    //}

            //    if (WDMethods.driver.FindElement(By.Name("Figyelmeztet�s")).Displayed && WDMethods.driver.FindElement(By.Name("Figyelmeztet�s")).Enabled)
            //    {
            //        StimulSoftPrint();
            //    }
            //    else
            //    {
            //        CrystalPrint();

            //    }

            //    void StimulSoftPrint()
            //    {
            //        //WaitTime.FluentWait();
            //        LogWriterT.WriteLog(folderpath, testname, "nem crystalriport nyomtat�s t�rt�nt");
            //        WDMethods.WDClick("Figyelmeztet�s", PropertyTypes.Name);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WaitTime.Wait(3);
            //        LogWriterT.WriteLog(folderpath, testname, "sz�ll�t�lev�l nyomtatva");
            //        WaitTime.Wait(1);
            //        WDMethods.WDClick("scrollViewer", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WDMethods.WDClick("TitleBar", PropertyTypes.Id);
            //        WDMethods.WDClick("Close", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //    }

            //    void CrystalPrint()
            //    {
            //        LogWriterT.WriteLog(folderpath, testname, "nem stimulsoft nyomtat�s t�rt�nt");
            //        WDMethods.WDClick("TitleBar", PropertyTypes.Id);
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WDMethods.WDClick("Close", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //    }


            //    /*-------------------sz�ml�z�s-------------------*/

            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WDMethods.WDClick("Sz�ml�z�s", PropertyTypes.Name);
            //    WaitTime.Wait(1);
            //    WDMethods.WDMoveToElement("Popup", PropertyTypes.ClassName);
            //    WDMethods.WDClick("RadRibbonButton", PropertyTypes.ClassName);
            //    WaitTime.Wait(1);

            //    WDMethods.WDClick("Kit�rolt", PropertyTypes.Name);
            //    WDMethods.WDClick("Sz�mla k�sz�t�se", PropertyTypes.Name);
            //    LogWriterT.WriteLog(folderpath, testname, "v�gsz�mla k�sz�t�s");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(2);

            //    if (WDMethods.driver.FindElement(By.Name("K�rd�s")).Displayed && WDMethods.driver.FindElement(By.Name("K�rd�s")).Enabled)
            //    {
            //        Egysegarmod2();
            //    }

            //    void Egysegarmod2()
            //    {
            //        while (WDMethods.driver.FindElement(By.Name("K�rd�s")).Displayed && WDMethods.driver.FindElement(By.Name("K�rd�s")).Enabled)
            //        {
            //            WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        }
            //    }

            //    WaitTime.Wait(2);

            //    if (WDMethods.driver.FindElement(By.Name("Figyelmeztet�s")).Displayed && WDMethods.driver.FindElement(By.Name("Figyelmeztet�s")).Enabled)
            //    {
            //        Sz�ml�z�sMethodStimulsoft();
            //        LogWriterT.WriteLog(folderpath, testname, "nem crystalriport nyomtat�s t�rt�nt");
            //    }
            //    else
            //    {
            //        Sz�ml�z�sMethodCrystal();
            //        LogWriterT.WriteLog(folderpath, testname, "nem stimulsoft nyomtat�s t�rt�nt");
            //    }


            //    void Sz�ml�z�sMethodStimulsoft()
            //    {

            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "riport kiv�laszt�s");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("CellElement_0_0", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "banksz�mla kiv�laszt�s");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDClick("SelectCommand", PropertyTypes.Id);
            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("btOK", PropertyTypes.Id);
            //        WaitTime.Wait(3);

            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "kiv�laszt�s");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WaitTime.Wait(5);
            //        LogWriterT.WriteLog(folderpath, testname, "sz�mla nyomtatva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDClick("Figyelmeztet�s", PropertyTypes.Name);
            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "kiv�laszt�s");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("scrollViewer", PropertyTypes.Id);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("TitleBar", PropertyTypes.Id);
            //        WDMethods.WDClick("Close", PropertyTypes.Id);
            //        WaitTime.Wait(1);

            //    }

            //    void Sz�ml�z�sMethodCrystal()
            //    {
            //        WDMethods.WDClick("toggleButton", PropertyTypes.Id);
            //        WaitTime.Wait(2);
            //        WDMethods.WDClick("CellElement_0_0", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "banksz�mla kiv�laszt�s");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDClick("SelectCommand", PropertyTypes.Id);
            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WDMethods.WDClick("btOK", PropertyTypes.Id);
            //        WaitTime.Wait(3);

            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "kiv�laszt�s");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WDMethods.WDClick("Win32", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "sz�mla nyomtatva");
            //        WaitTime.Wait(1);
            //        WDMethods.WDClick("2", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //    }

            //    WDMethods.WDClick("btClose", PropertyTypes.Id);

            //    /*-------------------munkakioszt�s-------------------*/


            //    /*napimunkarend meghat�roz�sa*/
            //    WDMethods.WDClick("ProductionRadRibbonTab", PropertyTypes.Id);
            //    WDMethods.WDClick("SERIE_RESOURCE", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "nap m�szakrend kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);

            //    WDMethods.WDScrollToElementAndClick("SectionsComboBox", PropertyTypes.Id, reszleg);
            //    LogWriterT.WriteLog(folderpath, testname, "r�szleg kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);

            //    WDMethods.WDClick("CAPACITY_GENERATE", PropertyTypes.Id);
            //    WaitTime.Wait(2);

            //    WDMethods.WDClick("PART_DropDownButton", PropertyTypes.Id);
            //    WDMethods.WDSendkeys("Filter0TextBoxEditor", munkat�rs, PropertyTypes.Id);
            //    WDMethods.WDClick("PART_ApplyFilterButton", PropertyTypes.Id);
            //    WDMethods.WDClick("allSelectCB", PropertyTypes.Id);
            //    WDMethods.WDDoubleClick("PART_RadComboBox", PropertyTypes.Id);
            //    WDMethods.WDSendkeys("TextBox", muszakrend, PropertyTypes.ClassName);

            //    /*minden felhaszn�l�ra val� gener�l�s, gond lehet ezzel, ha van keresztez� m�szakrend!!!*/
            //    //WDMethods.WDClick("allSelectCB", PropertyTypes.Id);
            //    //LogWriterT.WriteLog(folderpath, testname, "dolgoz�k kiv�lasztva");
            //    //PrtSc.TakePrtsc(folderpath, testname);
            //    //WaitTime.Wait(5);
            //    //WDMethods.WDDoubleClick("CellElement_0_6", PropertyTypes.Id);
            //    //WDMethods.WDClick("CellElement_0_6", PropertyTypes.Id);            
            //    //WDMethods.WDSendkeys("TextBox", muszakrend, PropertyTypes.ClassName);
            //    //SendKeys.SendWait("{ENTER}");
            //    //LogWriterT.WriteLog(folderpath, testname, "m�szakrend kiv�lasztva");
            //    //PrtSc.TakePrtsc(folderpath, testname);
            //    //WaitTime.Wait(5);

            //    WDMethods.WDClick("Ok", PropertyTypes.Name);
            //    WDMethods.WDClick("CAPACITY_SAVE", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "m�szakrend mentve");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);



            //    /*munkakioszt�s*/
            //    WDMethods.WDClick("ProductionRadRibbonTab", PropertyTypes.Id);
            //    WDMethods.WDClick("SERIEPROD_WORKALLOC", PropertyTypes.Id);
            //    WDMethods.WDClick("WORK_ALLOCATION", PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "gy�rt�s, manu�lis munkakioszt�s");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);

            //    WDMethods.WDClick("Gy�rt�s munkakioszt�s", PropertyTypes.Name);
            //    WDMethods.WDSendkeys("PART_DateTimeInput", today, PropertyTypes.Id);
            //    LogWriterT.WriteLog(folderpath, testname, "d�tum be�r�sa");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);
            //    WDMethods.WDScrollToElementAndClick("ShiftRCB", PropertyTypes.Id, muszakrend);
            //    LogWriterT.WriteLog(folderpath, testname, "m�szakrend kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);
            //    WDMethods.WDScrollToElementAndClick("SectionRCB", PropertyTypes.Id, reszleg);
            //    LogWriterT.WriteLog(folderpath, testname, "r�szleg kiv�lasztva");
            //    WDMethods.TakePrtsc(folderpath, testname);
            //    WaitTime.Wait(5);

            //    if (!(!WDMethods.driver.FindElement(By.Name("WORKALLOC_ADD")).Displayed || !WDMethods.driver.FindElement(By.Name("WORKALLOC_ADD")).Enabled))
            //    {
            //        Method1Munkakioszt�s();
            //    }
            //    else
            //    {
            //        if (WDMethods.driver.FindElement(By.Name("WORKALLOC_MODIFY")).Displayed && WDMethods.driver.FindElement(By.Name("WORKALLOC_MODIFY")).Enabled)
            //        {
            //            Method2Munkakioszt�s();
            //        }
            //        else
            //        {
            //            Method3Munkakioszt�s();
            //        }
            //    }

            //    void Method1Munkakioszt�s()
            //    {
            //        /*ha nincs akt�v munkakioszt�s �s akt�v a workalloc_add akkor ide fut bele*/
            //        WDMethods.WDClick("WORKALLOC_ADD", PropertyTypes.Id);
            //        WDMethods.WDClick("WORKALLOC_ITEMADD", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s ind�t�sa");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDSendkeys("Keres�s...", "APF�T 0404", PropertyTypes.Name);
            //        SendKeys.SendWait("{ENTER}");
            //        LogWriterT.WriteLog(folderpath, testname, "cikksz�m kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDScrollToElementAndClick("OrderItemRCB", PropertyTypes.Id, projektmegnkulsocode);
            //        LogWriterT.WriteLog(folderpath, testname, "megrendel�s kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(3);

            //        WDMethods.WDClick("OperationRCB", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //        WDMethods.WDClick("MAR�S - 1", PropertyTypes.Name);
            //        LogWriterT.WriteLog(folderpath, testname, "m�velet kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        //WDMethods.WDScrollToElementAndClick("OperationRCB", PropertyTypes.Id, "MAR�S - 1");
            //        //WDMethods.WDScrollToElementAndClick("StationRCB", PropertyTypes.Id, "Mar� III.");

            //        WDMethods.WDClick("StationRCB", PropertyTypes.Id);
            //        WDMethods.WDClick("Mar� G�P 1", PropertyTypes.Name);
            //        LogWriterT.WriteLog(folderpath, testname, "munka�llom�s kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDRightClick("Beoszt�s", PropertyTypes.Name);
            //        WDMethods.WDClick("Hozz�ad�s", PropertyTypes.Name);
            //        WDMethods.WDClick("CellElement_0_0", PropertyTypes.Id);
            //        WDMethods.WDClick("WorkAllocUserPopUpOKBtn", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkat�rs kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("WorkAllocOKBTn", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s ment�se");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("WORKALLOC_ACTIVATE", PropertyTypes.Id);
            //        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s aktiv�l�sa");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);
            //    }
            //    void Method2Munkakioszt�s()
            //    {
            //        /*ha m�r van akt�v munkakioszt�s akkor ebbe fut bele*/
            //        WDMethods.WDClick("WORKALLOC_MODIFY", PropertyTypes.Id);
            //        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //        WDMethods.WDClick("Ok", PropertyTypes.Name);
            //        WDMethods.WDClick("WORKALLOC_ITEMADD", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s ind�t�sa");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDSendkeys("Keres�s...", "APF�T 0404", PropertyTypes.Name);
            //        SendKeys.SendWait("{ENTER}");
            //        LogWriterT.WriteLog(folderpath, testname, "cikk kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDScrollToElementAndClick("OrderItemRCB", PropertyTypes.Id, projektmegnkulsocode);
            //        LogWriterT.WriteLog(folderpath, testname, "megrendel�s kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(3); ;

            //        WDMethods.WDClick("OperationRCB", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //        WDMethods.WDClick("MAR�S - 1", PropertyTypes.Name);
            //        LogWriterT.WriteLog(folderpath, testname, "m�velet kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        //WDMethods.WDScrollToElementAndClick("OperationRCB", PropertyTypes.Id, "MAR�S - 1");
            //        //WDMethods.WDScrollToElementAndClick("StationRCB", PropertyTypes.Id, "Mar� III.");

            //        WDMethods.WDClick("StationRCB", PropertyTypes.Id);
            //        WDMethods.WDClick("Mar� G�P 1", PropertyTypes.Name);
            //        LogWriterT.WriteLog(folderpath, testname, "munka�llom�s kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDRightClick("Beoszt�s", PropertyTypes.Name);
            //        WDMethods.WDClick("Hozz�ad�s", PropertyTypes.Name);
            //        WDMethods.WDClick("CellElement_0_0", PropertyTypes.Id);
            //        WDMethods.WDClick("WorkAllocUserPopUpOKBtn", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkat�rs kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("WorkAllocOKBTn", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s ment�se");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("WORKALLOC_ACTIVATE", PropertyTypes.Id);
            //        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //        WDMethods.WDClick("btOK", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s aktiv�l�sa");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);
            //    }
            //    void Method3Munkakioszt�s()
            //    {
            //        /*ha nem akt�v a workalloc_add ide fut bele*/
            //        WDMethods.WDClick("WORKALLOC_ITEMADD", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s ind�t�sa");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDSendkeys("Keres�s...", "APF�T 0404", PropertyTypes.Name);
            //        SendKeys.SendWait("{ENTER}");
            //        LogWriterT.WriteLog(folderpath, testname, "cikk kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(2);

            //        WDMethods.WDScrollToElementAndClick("OrderItemRCB", PropertyTypes.Id, projektmegnkulsocode);
            //        LogWriterT.WriteLog(folderpath, testname, "megrendel�s kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(3);

            //        WDMethods.WDClick("OperationRCB", PropertyTypes.Id);
            //        WaitTime.Wait(1);
            //        WDMethods.WDClick("MAR�S - 1", PropertyTypes.Name);
            //        LogWriterT.WriteLog(folderpath, testname, "m�velet kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("StationRCB", PropertyTypes.Id);
            //        WDMethods.WDClick("Mar� G�P 1", PropertyTypes.Name);
            //        LogWriterT.WriteLog(folderpath, testname, "munka�llom�s kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        //WDMethods.WDScrollToElementAndClick("OperationRCB", PropertyTypes.Id, "MAR�S - 1");
            //        //WDMethods.WDScrollToElementAndClick("StationRCB", PropertyTypes.Id, "Mar� III.");                               

            //        WDMethods.WDRightClick("Beoszt�s", PropertyTypes.Name);
            //        WDMethods.WDClick("Hozz�ad�s", PropertyTypes.Name);
            //        WDMethods.WDClick("CellElement_0_0", PropertyTypes.Id);
            //        WDMethods.WDClick("WorkAllocUserPopUpOKBtn", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkat�rs kiv�lasztva");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("WorkAllocOKBTn", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s ment�se");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);

            //        WDMethods.WDClick("WORKALLOC_ACTIVATE", PropertyTypes.Id);
            //        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //        WDMethods.WDClick("btNo", PropertyTypes.Id);
            //        WDMethods.WDClick("btYes", PropertyTypes.Id);
            //        WDMethods.WDClick("btOK", PropertyTypes.Id);
            //        LogWriterT.WriteLog(folderpath, testname, "munkakioszt�s aktiv�l�sa");
            //        WDMethods.TakePrtsc(folderpath, testname);
            //        WaitTime.Wait(1);



            //        //WDMethods.WDSendkeys("textSource", "MEGRENDCIKK5", PropertyTypes.Id);
            //        //WDMethods.Click("AttributeIcon", PropertyTypes.Id);
            //        //WaitTime.Wait(2);


            //        //WDMethods.Start(appPath, winiumDriverDirectory);
            //        //WaitTime.Wait(2);
            //        //WDMethods.WDClick("Ugr�s a mai napra", PropertyTypes.Name);
            //        ////WDMethods.WDClick("07:25", PropertyTypes.Name);
            //        //WaitTime.Wait(2);
            //        //WDMethods.DragAndDrop("PART_TimeRulerPanel", "07:55", "08:55");


            //}
        }
    }
}