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

        string cikkszam = "AUTITEM356C";        /*csak nagybetûvel!!!*/
        /*csak nagybetûvel!!!*/
        string cikkmegnevezes = "AUTITEM356C";    /*csak nagybetûvel!!!*/
        string cikkcsopcode = "31";
        string vevoilistaAr = "651";
        string vevoilistaArMargin = "10";
        string partner = "AUTCOMPY356C";   /*csak nagybetûvel!!!*/
        string providnev = "AT356C";       /*csak nagybetûvel!!!*/
        string szamlazasiAddress = "Pont az út 23";
        string levelezesiAddress = "Pont Nem az utca 22";
        string partnermail = "company356c@mail.hu";  /*csak kisbetûvel!!!*/
        string taxcode = "11111111-3-65";
        string partnernote = "megjegyzés partner240131";

        string cikkszam2 = "MEGRENDCIKK15C";      /*csak nagybetûvel!!!*/
        string cikkmegnevezes2 = "CMMEGRENDCIKK15C";   /*csak nagybetûvel!!!*/
        string cikkcsopcode2 = "8";

        string partner2 = "AUTCBSZ7C";   /*csak nagybetûvel!!!*/
        string providnev2 = "AB7C";       /*csak nagybetûvel!!!*/
        string szamlazasiAddress2 = "Pont az út 23";
        string levelezesiAddress2 = "Pont Nem az utca 22";
        string partnermail2 = "atb7c@mail.hu";  /*csak kisbetûvel!!!*/
        string taxcode2 = "11111111-3-66";

        string projektmegnkulsocode = "releasetest240131";

        string megrendelesmennyiseg = "10";

        string megrendelesegysegar = "1011";

        string szallito = "CSERNYIK ÁKOS";
        string koltseghely = "Test";

        string szallitolevel = "szlev000029";
        string szamlaszam = "szlszám000029";
        string szallitolevel2 = "bszlev000029";
        string szamlaszam2 = "bszlszám000029";

        string today = DateTime.Today.ToString("yyyy/MM/dd.");
        string muszakrend = "délelõtt";
        string munkatárs = "GÉPKEZELÕ ZOLTÁN";
        string reszleg = "R009 - MEGMUNKÁLÓ";
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
            LogWriterT.WriteLog(folderpath, testname, "felhasználó beírva");

            WDMethods.Sendkeys("tbJelszo", password, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "pw beírva");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("cbAdatbazisok", PropertyTypes.Id);
            SendKeys.SendWait("{F4}");
            WDMethods.ScrollToElementAndClick("cbAdatbazisok", PropertyTypes.Id, database);
            //SendKeys.SendWait("{Enter}");               
            LogWriterT.WriteLog(folderpath, testname, "db kiválasztva");
            WDMethods.TakePrtsc(folderpath, testname);
            WaitTime.Wait(4);

            WDMethods.Click("Bejelentkezés", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "bejelentkezés");


            WDMethods.Click("SETTINGS_TAB", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "beállítások tab");

            WDMethods.Click("MAINTENANCE_ORDINARY", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "törzsek katt");

            WDMethods.Sendkeys("Keresés...", "cikkek", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cikkek beírva");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("MAINTENANCE_PARTS", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkekre katt");

            /*profil betöltése cikkek*/

            WDMethods.RightClick("PART_DropDownButton", PropertyTypes.Id);
            WDMethods.RightClick("GridView profil betöltése", PropertyTypes.Name);
            WDMethods.Click("Releasetest", PropertyTypes.Name);
            WDMethods.Click("OkButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "profil betöltve");

            WDMethods.Click("PARTS_ADD_BUTTON", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "új cikkek hozzáadás");

            WDMethods.Click("RadRibbonButton", PropertyTypes.ClassName);
            LogWriterT.WriteLog(folderpath, testname, "új cikkek katt");

            WDMethods.Sendkeys("CodeTextBox", cikkszam, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkekszám beírás");

            WDMethods.Sendkeys("PartNational", cikkmegnevezes, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "cikkmegnevezés beírás");

            WDMethods.Click("toggleButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport választó katt");

            WDMethods.Sendkeys("FilterTextBoxEditor_0", cikkcsopcode, PropertyTypes.Id);
            WDMethods.driver.FindElement(By.Id("FilterTextBoxEditor_0")).Submit();
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport beírás");

            //WDMethods.WDClick("PART_DropDownButton", PropertyTypes.Id); 
            //LogWriterT.WriteLog(folderpath, testname, "cikkcsoport PART_DropDownButton katt");
            //WaitTime.Wait(1);

            WDMethods.Click(cikkcsopcode, PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport katt");

            WDMethods.Click("SelectCommand", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "OK katt");

            WDMethods.Sendkeys("PartBarCode", cikkmegnevezes, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vonalkód beírás");

            WDMethods.Sendkeys("PartExtCode", cikkmegnevezes, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vonalkód beírás");

            WDMethods.Sendkeys("CustomerListPrice", vevoilistaAr, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vevõi listaár beírás");

            WDMethods.Sendkeys("MarginNtb", vevoilistaArMargin, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk margin beírás");

            WDMethods.Sendkeys("PartUnitWeight", "21", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk nettó súly beírás");

            WDMethods.Sendkeys("PartBruttoWeight", "25", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk bruttó súly beírás");

            WDMethods.ScrollToElementAndClick("PartBruttoWeightUnitType", PropertyTypes.Id, "GR");
            LogWriterT.WriteLog(folderpath, testname, "bruttosúly típus katt");

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "mentés");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.TakePrtsc(folderpath, testname);
            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk törzs karbantartó ablak bezárás");

            /* Cikk 2 */

            WDMethods.Click("PARTS_ADD_BUTTON", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "új cikkek hozzáadás");

            WDMethods.Click("RadRibbonButton", PropertyTypes.ClassName);
            LogWriterT.WriteLog(folderpath, testname, "új cikkek katt");

            WDMethods.Sendkeys("CodeTextBox", cikkszam2, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkekszám beírás");

            WDMethods.Sendkeys("PartNational", cikkmegnevezes2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "cikkmegnevezés beírás");

            WDMethods.Click("toggleButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport választó katt");

            WDMethods.Sendkeys("FilterTextBoxEditor_0", cikkcsopcode2, PropertyTypes.Id);
            WDMethods.driver.FindElement(By.Id("FilterTextBoxEditor_0")).Submit();
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport beírás");

            //WDMethods.WDClick("PART_DropDownButton", PropertyTypes.Id); 
            //LogWriterT.WriteLog(folderpath, testname, "cikkcsoport PART_DropDownButton katt");
            //WaitTime.Wait(1);

            WDMethods.Click(cikkcsopcode2, PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cikkcsoport katt");

            WDMethods.Click("SelectCommand", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "OK katt");

            WDMethods.Sendkeys("CustomerListPrice", vevoilistaAr, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk vevõi listaár beírás");

            WDMethods.Sendkeys("MarginNtb", vevoilistaArMargin, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk margin beírás");

            WDMethods.Sendkeys("PartUnitWeight", "21", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk nettó súly beírás");

            WDMethods.Sendkeys("PartBruttoWeight", "25", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk bruttó súly beírás");

            WDMethods.ScrollToElementAndClick("PartBruttoWeightUnitType", PropertyTypes.Id, "GR");
            LogWriterT.WriteLog(folderpath, testname, "bruttosúly típus katt");

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "mentés");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.TakePrtsc(folderpath, testname);
            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "cikk törzs karbantartó ablak bezárás");


            /*-------------------beállítások partnerek-------------------*/

            WDMethods.TextClear("Keresés...", PropertyTypes.Name);
            WDMethods.Sendkeys("Keresés...", "partnerek", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "partnerek beírva");

            WDMethods.Click("MAINTENANCE_PARTNERS", PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partnerek katt");

            /*profil betöltésse partnerek*/

            WDMethods.RightClick("PART_HeaderRow", PropertyTypes.Id);
            WDMethods.RightClick("GridView profil betöltése", PropertyTypes.Name);
            WDMethods.Click("Releasetest", PropertyTypes.Name);
            WDMethods.Click("OkButton", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "profil betöltve");

            /* vevõ rögzítése */

            WDMethods.Click("addPartner_btn", PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "hozzáadás katt");

            WDMethods.Sendkeys("PartnerName", partner, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner név beírva");

            WDMethods.Sendkeys("PartnerNickName", providnev, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner rövidnév beírva");
            WDMethods.TakePrtsc(folderpath, testname);


            WDMethods.Sendkeys("Keresés...", "Szolnok 5000", PropertyTypes.Name); ;
            LogWriterT.WriteLog(folderpath, testname, "város név beírva");
            SendKeys.SendWait("{Enter}");

            //WDMethods.WDClick("Szolnok 5000", PropertyTypes.Name); ;
            //LogWriterT.WriteLog(folderpath, testname, "város név katt");
            //WaitTime.Wait(1);

            WDMethods.Sendkeys("PartnerInvAddress", szamlazasiAddress, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "város név beírva");

            WDMethods.Click("A számlázási cím megegyzik a levelezési címmel?", PropertyTypes.Name);
            WDMethods.Click("A számlázási cím megegyzik a levelezési címmel?", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cím másolás be-kikapcsolás katt");
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.TextClear("PartnerCorAddress", PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerCorAddress", levelezesiAddress, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "levelezési cím beírva");

            WDMethods.TextClear("PartnerEmail",PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerEmail", partnermail, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "email beírva");

            WDMethods.ScrollToElementAndClick("PartnerType", PropertyTypes.Id, "Társas vállalkozás");
            LogWriterT.WriteLog(folderpath, testname, "partner type kiválasztás");

            WDMethods.ScrollToElementAndClick("PartnerCompanyForm", PropertyTypes.Id, "KFT.");
            LogWriterT.WriteLog(folderpath, testname, "partner form kiválasztás");

            WDMethods.ScrollToElementAndClick("PartnerDepartmentType", PropertyTypes.Id, "Ipar, építõipar");
            LogWriterT.WriteLog(folderpath, testname, "ágazat kiválasztása");

            WDMethods.ScrollToElementAndClick("PartnerPayClass", PropertyTypes.Id, "Jól fizetõ");
            LogWriterT.WriteLog(folderpath, testname, "fizetési minõsítés katt");

            WDMethods.ScrollToElementAndClick("DefaultCurrency", PropertyTypes.Id, "HUF");
            LogWriterT.WriteLog(folderpath, testname, "alapértelmezett pénznem kiv.");

            WDMethods.Sendkeys("PartnerTaxaccount", taxcode, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "tax beírva");

            WDMethods.Sendkeys("PartnerEuTaxaccount", taxcode, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "taxeu beírva");

            WDMethods.Sendkeys("PartnerNote", partnernote, PropertyTypes.Id); ;

            LogWriterT.WriteLog(folderpath, testname, "megjegyzés beírva");

            WDMethods.Click("SaveBtn", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "mentés katt");

            WDMethods.Click("Partnerreláció kiválasztása", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "Partnerreláció kiválasztása katt");

            WDMethods.Click("CellElement_3_0", PropertyTypes.Id);
            WDMethods.Click("CellElement_5_0", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "Partnerreláció kiválasztva ");;
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "reláció mentés");

            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "bezárás katt");

            /* beszállító rögzítése */

            WDMethods.Click("addPartner_btn", PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "hozzáadás katt");            

            WDMethods.Sendkeys("PartnerName", partner2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner név beírva");
            

            WDMethods.Sendkeys("PartnerNickName", providnev2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "partner rövidnév beírva");            
            WDMethods.TakePrtsc(folderpath, testname);


            WDMethods.Sendkeys("Keresés...", "Szolnok 5000", PropertyTypes.Name); ;
            LogWriterT.WriteLog(folderpath, testname, "város név beírva");
            
            SendKeys.SendWait("{Enter}");

            //WDMethods.WDClick("Szolnok 5000", PropertyTypes.Name); ;
            //LogWriterT.WriteLog(folderpath, testname, "város név katt");
            //WaitTime.Wait(1);

            WDMethods.Sendkeys("PartnerInvAddress", szamlazasiAddress2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "város név beírva");
            

            WDMethods.Click("A számlázási cím megegyzik a levelezési címmel?", PropertyTypes.Name);
            WDMethods.Click("A számlázási cím megegyzik a levelezési címmel?", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "cím másolás be-kikapcsolás katt");
            

            WDMethods.TakePrtsc(folderpath, testname);
            WDMethods.TextClear("PartnerCorAddress", PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerCorAddress", levelezesiAddress2, PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "levelezési cím beírva");

            WDMethods.TextClear("PartnerEmail", PropertyTypes.Id);
            WDMethods.Sendkeys("PartnerEmail", partnermail2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "email beírva");
            

            WDMethods.ScrollToElementAndClick("PartnerType", PropertyTypes.Id, "Társas vállalkozás");
            LogWriterT.WriteLog(folderpath, testname, "partner type kiválasztás");
            

            WDMethods.ScrollToElementAndClick("PartnerCompanyForm", PropertyTypes.Id, "KFT.");
            LogWriterT.WriteLog(folderpath, testname, "partner form kiválasztás");
            

            WDMethods.ScrollToElementAndClick("PartnerDepartmentType", PropertyTypes.Id, "Ipar, építõipar");
            LogWriterT.WriteLog(folderpath, testname, "ágazat kiválasztása");
            
            WDMethods.ScrollToElementAndClick("PartnerPayClass", PropertyTypes.Id, "Jól fizetõ");
            LogWriterT.WriteLog(folderpath, testname, "fizetési minõsítés katt");
            

            WDMethods.ScrollToElementAndClick("DefaultCurrency", PropertyTypes.Id, "HUF");
            LogWriterT.WriteLog(folderpath, testname, "alapértelmezett pénznem kiv.");
            

            WDMethods.Sendkeys("PartnerTaxaccount", taxcode2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "tax beírva");
            

            WDMethods.Sendkeys("PartnerEuTaxaccount", taxcode2, PropertyTypes.Id); ;
            LogWriterT.WriteLog(folderpath, testname, "taxeu beírva");
            

            WDMethods.Sendkeys("PartnerNote", partnernote, PropertyTypes.Id); ;

            LogWriterT.WriteLog(folderpath, testname, "megjegyzés beírva");
            

            WDMethods.Click("SaveBtn", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "mentés katt");
            

            WDMethods.Click("Partnerreláció kiválasztása", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "Partnerreláció kiválasztása katt");
            

            WDMethods.Click("CellElement_3_0", PropertyTypes.Id);
            

            LogWriterT.WriteLog(folderpath, testname, "Partnerreláció kiválasztva ");
            
            WDMethods.TakePrtsc(folderpath, testname);

            WDMethods.Click("Ok", PropertyTypes.Name);
            LogWriterT.WriteLog(folderpath, testname, "reláció mentés");
            

            WDMethods.Click("Alkatrész beszállító", PropertyTypes.Name);
            
            WDMethods.Click("CheckBox", PropertyTypes.ClassName);
            
            WDMethods.Click("Mentés", PropertyTypes.Name);
            
            WDMethods.Click("PART_CloseButton", PropertyTypes.Id);
            

            WDMethods.Click("Szállító", PropertyTypes.Name);
            
            WDMethods.Click("CellElement_1_0", PropertyTypes.Id);
            
            WDMethods.Click("Mentés", PropertyTypes.Name);
            
            WDMethods.Click("PART_CloseButton", PropertyTypes.Id);
            

            WDMethods.Click("btClose", PropertyTypes.Id);
            LogWriterT.WriteLog(folderpath, testname, "bezárás katt");
            

        }
        [TearDown]
        public void Teardown()
        {
            
        }
    }
}