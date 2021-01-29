using System.Collections.Generic;

//using obszary_covid_jpp_areas;
using System.IO;
namespace obszary_covid_jpp
{//21.12.2020 w miare gotowe teraz msuze bd dorobic potem zoptymalizuje
 //29.12.2020 dodałem edytuj i paru inny rzeczy pS to nie tak ze miedy nic nie pisałem tylko nie chciało mi sie wpisu robic

    //12.01.2021 TO DO Słwonik przypadków, horlavdata i verlavdata wiec tez lavdata, areas edit metody i ich implemaetacje w poszczegolnych klasach, a jescze wyjscia z edit nie wpadnicje to dziury :D.  I  JUŻ NAPRAWDE STARCZY ale kiedy mi sie zachce przerobie do na www
    //bool[] TODO = new bool[4] { false, false, false, false}
    //12.01.2021//bool[] TODO = {true,false,false,false+}; + dodałem kolejną funkcje
    //13.01.2021//bool[] TODO = {true,true,Testy(),Testy()};
    //14.01.2021//bool[] TODO = {true,true,Testy()+,nie da sie wyjsc z samego wpisywania danych czasami};
    static class Program
    {
        // Słabo szukałem      https://www.monitorpolski.gov.pl/DU ale tam nie ma tagów a kon i pies nie działa Zwierzeta domowe też 
        // praw lokalnych pewnie tez nie ma
        // tak szcezrze to dopiero 12.01.2021 to znalzałem
        // do dodania poprawiacz wyszukiwania
        // ulpesznia atgow
        //zrobnie www
        //wyeliminowanie tych niepotrzebnych parametrow
        //ulepszenie edita
        //zweryfikowanie co uzytkonik wpisuje
       // mozna by zrobic clase okno ktura by robiła cleara i była by oknem
        static public Dictionary<string, string> AngPolMianownik = new Dictionary<string, string>()
        {
            {"Country","kraj"},
            {"Province","wojewodztwo"},
            {"District","powiat"},
            {"Commune","gmina"}
        };
        static public Dictionary<string, string> PolAngMianownik = new Dictionary<string, string>()
        {
            {"kraj","Country"},
            {"wojewodztwo","Province"},
            {"powiat","District"},
            {"gmina","Commune"}
        };
        static public Dictionary<string, string> AngPolDopełniacz = new Dictionary<string, string>()//stelaris sie przyadało
        {
            {"Country","kraju"},
            {"Province","wojewodztwa"},
            {"District","powiatu"},
            {"Commune","gminy"}
        };
        static public Dictionary<string, string> AngPolCelownik = new Dictionary<string, string>()//stelaris sie przyadało
        {
            {"Country","krajowi"},
            {"Province","wojewodztwu"},
            {"District","powiatowi"},
            {"Commune","gminie"}
        };
        static public Dictionary<string, string> AngPolMiejscownik = new Dictionary<string, string>()
        {
            {"Country","kraju"},
            {"Province","wojewodztwie"},
            {"District","powiacie"},
            {"Commune","gminie"}
        };
        internal static Areas.Areas areas = new Areas.Areas();
        static void Main()//pierwotny pomysl to napisac program do oczytawania jakie obostrzenia covid sa w danym miescu obecnie mysle na powiekszeniem na program do stanowienia prawa
        {

            Mainmenu mainmenu = new Mainmenu(areas);
            mainmenu.Show();
        }

    }
}
