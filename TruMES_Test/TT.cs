using Modules;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Winium;
using System;
using System.Windows.Forms;

namespace TruMES_Test
{
    public class Tests
    {
        public static WiniumDriver driver { get; set; }
        private const string WiniumDriverDirectory = @"C:\Winiumdriver\";

        string testname = "releasetest240131";
        string errorlog = "errorlog240131";
        string folderpath = "C:\\WorkSpace\\240131\\";

        string database = "KONZ TESZT(PROXMOX)";
        string felhasznalo = "dmsdba";
        string password = "gum1cukor";

        string cikkszam = "AUTITEM356C";        /*csak nagybet�vel!!!*/
        /*csak nagybet�vel!!!*/
        string cikkmegnevezes = "AUTITEM356C";    /*csak nagybet�vel!!!*/
        string cikkcsopcode = "31";
        string vevoilistaAr = "651";
        string vevoilistaArMargin = "10";
        string partner = "AUTCOMPY356C";   /*csak nagybet�vel!!!*/
        string providnev = "AT356C";       /*csak nagybet�vel!!!*/
        string szamlazasiAddress = "Pont az �t 23";
        string levelezesiAddress = "Pont Nem az utca 22";
        string partnermail = "company356c@mail.hu";  /*csak kisbet�vel!!!*/
        string taxcode = "11111111-3-65";
        string partnernote = "megjegyz�s partner240131";

        string cikkszam2 = "MEGRENDCIKK15C";      /*csak nagybet�vel!!!*/
        string cikkmegnevezes2 = "CMMEGRENDCIKK15C";   /*csak nagybet�vel!!!*/
        string cikkcsopcode2 = "8";

        string partner2 = "AUTCBSZ7C";   /*csak nagybet�vel!!!*/
        string providnev2 = "AB7C";       /*csak nagybet�vel!!!*/
        string szamlazasiAddress2 = "Pont az �t 23";
        string levelezesiAddress2 = "Pont Nem az utca 22";
        string partnermail2 = "atb7c@mail.hu";  /*csak kisbet�vel!!!*/
        string taxcode2 = "11111111-3-66";

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



        [SetUp]
        public void Setup()
        {
            WDMethods.Start(appPath, WiniumDriverDirectory);
            LogWriterT.LogDirFileCreate(folderpath, testname);
        }

        [Test]
        public void Test()
        {
            WDMethods.TextClear("tbFelhasznalo1", PropertyTypes.Id);
            WDMethods.Sendkeys("tbFelhasznalo1", felhasznalo, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "felhaszn�l� be�rva");

            WDMethods.Sendkeys("tbJelszo", password, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "pw be�rva");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("cbAdatbazisok", PropertyTypes.Id);
            SendKeys.SendWait("{F4}");
            WDMethods.ScrollToElementAndClick("cbAdatbazisok", PropertyTypes.Id, database);
            //SendKeys.SendWait("{Enter}");               
            LogWriterT.WriteLog(folderpath, testname, "db kiv�lasztva");
            WDMethods.TakePrtsc(folderpath, testname);
            WaitTime.Wait(4);

            WDMethods.Click("Bejelentkez�s", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "bejelentkez�s");


            WDMethods.Click("SETTINGS_TAB", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "be�ll�t�sok tab");

            WDMethods.Click("MAINTENANCE_ORDINARY", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "t�rzsek katt");

            WDMethods.Sendkeys("Keres�s...", "cikkek", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cikkek be�rva");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("MAINTENANCE_PARTS", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkekre katt");

            /*profil bet�lt�se cikkek*/

            WDMethods.RightClick("PART_DropDownButton", PropertyTypes.Id);
            WDMethods.RightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            WDMethods.Click("Releasetest", PropertyTypes.Name);
            WDMethods.Click("OkButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");

            WDMethods.Click("PARTS_ADD_BUTTON", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "�j cikkek hozz�ad�s");

            WDMethods.Click("RadRibbonButton", PropertyTypes.ClassName);
            LogWriterT.WriteLog(folderpath, testname, "�j cikkek katt");

            WDMethods.Sendkeys("CodeTextBox", cikkszam, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkeksz�m be�r�s");

            WDMethods.Sendkeys("PartNational", cikkmegnevezes, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "cikkmegnevez�s be�r�s");

            WDMethods.Click("toggleButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport v�laszt� katt");

            WDMethods.Sendkeys("FilterTextBoxEditor_0", cikkcsopcode, PropertyTypes.Id);
            WDMethods.driver.FindElement(By.Id("FilterTextBoxEditor_0")).Submit();
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport be�r�s");

            //WDMethods.WDClick("PART_DropDownButton", PropertyTypes.Id); 
            //LogWriterT.WriteLog(folderpath, testname, "cikkcsoport PART_DropDownButton katt");
            //WaitTime.Wait(1);

            WDMethods.Click(cikkcsopcode, PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport katt");

            WDMethods.Click("SelectCommand", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "OK katt");

            WDMethods.Sendkeys("PartBarCode", cikkmegnevezes, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vonalk�d be�r�s");

            WDMethods.Sendkeys("PartExtCode", cikkmegnevezes, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vonalk�d be�r�s");

            WDMethods.Sendkeys("CustomerListPrice", vevoilistaAr, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vev�i lista�r be�r�s");

            WDMethods.Sendkeys("MarginNtb", vevoilistaArMargin, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk margin be�r�s");

            WDMethods.Sendkeys("PartUnitWeight", "21", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk nett� s�ly be�r�s");

            WDMethods.Sendkeys("PartBruttoWeight", "25", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk brutt� s�ly be�r�s");

            WDMethods.ScrollToElementAndClick("PartBruttoWeightUnitType", PropertyTypes.Id, "GR");
            LogWriterT.WriteLog(folderpath, testname, "bruttos�ly t�pus katt");

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "ment�s");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.TakePrtsc(folderpath, testname);
            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk t�rzs karbantart� ablak bez�r�s");

            /* Cikk 2 */

            WDMethods.Click("PARTS_ADD_BUTTON", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "�j cikkek hozz�ad�s");

            WDMethods.Click("RadRibbonButton", PropertyTypes.ClassName);
            LogWriterT.WriteLog(folderpath, testname, "�j cikkek katt");

            WDMethods.Sendkeys("CodeTextBox", cikkszam2, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkeksz�m be�r�s");

            WDMethods.Sendkeys("PartNational", cikkmegnevezes2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "cikkmegnevez�s be�r�s");

            WDMethods.Click("toggleButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport v�laszt� katt");

            WDMethods.Sendkeys("FilterTextBoxEditor_0", cikkcsopcode2, PropertyTypes.Id);
            WDMethods.driver.FindElement(By.Id("FilterTextBoxEditor_0")).Submit();
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport be�r�s");

            //WDMethods.WDClick("PART_DropDownButton", PropertyTypes.Id); 
            //LogWriterT.WriteLog(folderpath, testname, "cikkcsoport PART_DropDownButton katt");
            //WaitTime.Wait(1);

            WDMethods.Click(cikkcsopcode2, PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport katt");

            WDMethods.Click("SelectCommand", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "OK katt");

            WDMethods.Sendkeys("CustomerListPrice", vevoilistaAr, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vev�i lista�r be�r�s");

            WDMethods.Sendkeys("MarginNtb", vevoilistaArMargin, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk margin be�r�s");

            WDMethods.Sendkeys("PartUnitWeight", "21", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk nett� s�ly be�r�s");

            WDMethods.Sendkeys("PartBruttoWeight", "25", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk brutt� s�ly be�r�s");

            WDMethods.ScrollToElementAndClick("PartBruttoWeightUnitType", PropertyTypes.Id, "GR");
            LogWriterT.WriteLog(folderpath, testname, "bruttos�ly t�pus katt");

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "ment�s");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.TakePrtsc(folderpath, testname);
            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk t�rzs karbantart� ablak bez�r�s");


            /*-------------------be�ll�t�sok partnerek-------------------*/

            WDMethods.TextClear("Keres�s...", PropertyTypes.Name);
            WDMethods.Sendkeys("Keres�s...", "partnerek", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "partnerek be�rva");

            WDMethods.Click("MAINTENANCE_PARTNERS", PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partnerek katt");

            /*profil bet�lt�sse partnerek*/

            WDMethods.RightClick("PART_HeaderRow", PropertyTypes.Id);
            WDMethods.RightClick("GridView profil bet�lt�se", PropertyTypes.Name);
            WDMethods.Click("Releasetest", PropertyTypes.Name);
            WDMethods.Click("OkButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "profil bet�ltve");

            /* vev� r�gz�t�se */

            WDMethods.Click("addPartner_btn", PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "hozz�ad�s katt");

            WDMethods.Sendkeys("PartnerName", partner, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner n�v be�rva");

            WDMethods.Sendkeys("PartnerNickName", providnev, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner r�vidn�v be�rva");
            WDMethods.TakePrtsc(folderpath, testname);


            WDMethods.Sendkeys("Keres�s...", "Szolnok 5000", PropertyTypes.Name); ;
            LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");
            SendKeys.SendWait("{Enter}");

            //WDMethods.WDClick("Szolnok 5000", PropertyTypes.Name); ;
            //LogWriterT.WriteLog(folderpath, testname, "v�ros n�v katt");
            //WaitTime.Wait(1);

            WDMethods.Sendkeys("PartnerInvAddress", szamlazasiAddress, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");

            WDMethods.Click("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            WDMethods.Click("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "c�m m�sol�s be-kikapcsol�s katt");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.TextClear("PartnerCorAddress", PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerCorAddress", levelezesiAddress, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "levelez�si c�m be�rva");

            WDMethods.TextClear("PartnerEmail",PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerEmail", partnermail, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "email be�rva");

            WDMethods.ScrollToElementAndClick("PartnerType", PropertyTypes.Id, "T�rsas v�llalkoz�s");
            LogWriterT.WriteLog(folderpath, testname, "partner type kiv�laszt�s");

            WDMethods.ScrollToElementAndClick("PartnerCompanyForm", PropertyTypes.Id, "KFT.");
            LogWriterT.WriteLog(folderpath, testname, "partner form kiv�laszt�s");

            WDMethods.ScrollToElementAndClick("PartnerDepartmentType", PropertyTypes.Id, "Ipar, �p�t�ipar");
            LogWriterT.WriteLog(folderpath, testname, "�gazat kiv�laszt�sa");

            WDMethods.ScrollToElementAndClick("PartnerPayClass", PropertyTypes.Id, "J�l fizet�");
            LogWriterT.WriteLog(folderpath, testname, "fizet�si min�s�t�s katt");

            WDMethods.ScrollToElementAndClick("DefaultCurrency", PropertyTypes.Id, "HUF");
            LogWriterT.WriteLog(folderpath, testname, "alap�rtelmezett p�nznem kiv.");

            WDMethods.Sendkeys("PartnerTaxaccount", taxcode, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "tax be�rva");

            WDMethods.Sendkeys("PartnerEuTaxaccount", taxcode, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "taxeu be�rva");

            WDMethods.Sendkeys("PartnerNote", partnernote, PropertyTypes.Id); ;

            LogWriterT.WriteLog(folderpath, testname, "megjegyz�s be�rva");

            WDMethods.Click("SaveBtn", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "ment�s katt");

            WDMethods.Click("Partnerrel�ci� kiv�laszt�sa", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�laszt�sa katt");

            WDMethods.Click("CellElement_3_0", PropertyTypes.Id);
            WDMethods.Click("CellElement_5_0", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�lasztva ");;
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "rel�ci� ment�s");

            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "bez�r�s katt");

            /* besz�ll�t� r�gz�t�se */

            WDMethods.Click("addPartner_btn", PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "hozz�ad�s katt");            

            WDMethods.Sendkeys("PartnerName", partner2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner n�v be�rva");
            

            WDMethods.Sendkeys("PartnerNickName", providnev2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner r�vidn�v be�rva");            
            WDMethods.TakePrtsc(folderpath, testname);


            WDMethods.Sendkeys("Keres�s...", "Szolnok 5000", PropertyTypes.Name); ;
            LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");
            
            SendKeys.SendWait("{Enter}");

            //WDMethods.WDClick("Szolnok 5000", PropertyTypes.Name); ;
            //LogWriterT.WriteLog(folderpath, testname, "v�ros n�v katt");
            //WaitTime.Wait(1);

            WDMethods.Sendkeys("PartnerInvAddress", szamlazasiAddress2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "v�ros n�v be�rva");
            

            WDMethods.Click("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            WDMethods.Click("A sz�ml�z�si c�m megegyzik a levelez�si c�mmel?", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "c�m m�sol�s be-kikapcsol�s katt");
            

            WDMethods.TakePrtsc(folderpath, testname);
            WDMethods.TextClear("PartnerCorAddress", PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerCorAddress", levelezesiAddress2, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "levelez�si c�m be�rva");

            WDMethods.TextClear("PartnerEmail", PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerEmail", partnermail2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "email be�rva");
            

            WDMethods.ScrollToElementAndClick("PartnerType", PropertyTypes.Id, "T�rsas v�llalkoz�s");
            LogWriterT.WriteLog(folderpath, testname, "partner type kiv�laszt�s");
            

            WDMethods.ScrollToElementAndClick("PartnerCompanyForm", PropertyTypes.Id, "KFT.");
            LogWriterT.WriteLog(folderpath, testname, "partner form kiv�laszt�s");
            

            WDMethods.ScrollToElementAndClick("PartnerDepartmentType", PropertyTypes.Id, "Ipar, �p�t�ipar");
            LogWriterT.WriteLog(folderpath, testname, "�gazat kiv�laszt�sa");
            
            WDMethods.ScrollToElementAndClick("PartnerPayClass", PropertyTypes.Id, "J�l fizet�");
            LogWriterT.WriteLog(folderpath, testname, "fizet�si min�s�t�s katt");
            

            WDMethods.ScrollToElementAndClick("DefaultCurrency", PropertyTypes.Id, "HUF");
            LogWriterT.WriteLog(folderpath, testname, "alap�rtelmezett p�nznem kiv.");
            

            WDMethods.Sendkeys("PartnerTaxaccount", taxcode2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "tax be�rva");
            

            WDMethods.Sendkeys("PartnerEuTaxaccount", taxcode2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "taxeu be�rva");
            

            WDMethods.Sendkeys("PartnerNote", partnernote, PropertyTypes.Id); ;

            LogWriterT.WriteLog(folderpath, testname, "megjegyz�s be�rva");
            

            WDMethods.Click("SaveBtn", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "ment�s katt");
            

            WDMethods.Click("Partnerrel�ci� kiv�laszt�sa", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�laszt�sa katt");
            

            WDMethods.Click("CellElement_3_0", PropertyTypes.Id);
            

            LogWriterT.WriteLog(folderpath, testname, "Partnerrel�ci� kiv�lasztva ");
            
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "rel�ci� ment�s");
            

            WDMethods.Click("Alkatr�sz besz�ll�t�", PropertyTypes.Name);
            
            WDMethods.Click("CheckBox", PropertyTypes.ClassName);
            
            WDMethods.Click("Ment�s", PropertyTypes.Name);
            
            WDMethods.Click("PART_CloseButton", PropertyTypes.Id);
            

            WDMethods.Click("Sz�ll�t�", PropertyTypes.Name);
            
            WDMethods.Click("CellElement_1_0", PropertyTypes.Id);
            
            WDMethods.Click("Ment�s", PropertyTypes.Name);
            
            WDMethods.Click("PART_CloseButton", PropertyTypes.Id);
            

            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "bez�r�s katt");
            

        }
        [TearDown]
        public void Teardown()
        {
            
        }
    }
}