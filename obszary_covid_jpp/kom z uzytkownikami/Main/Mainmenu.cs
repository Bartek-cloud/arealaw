using System;

using menu;
using Area_date_ns;


namespace obszary_covid_jpp
{
    public partial class Mainmenu 
    {       
        Area_date current_area;
        int task;
        int end;
        string po_podktóry;
        string message;
        string[] main_menu_string;
        Menu main_menu;
        Areas.Areas areas;
        public Mainmenu(Areas.Areas areas)
        {
            this.areas = areas;
            current_area = areas.Search("Polska")[0];
            
            main_menu_string = new string[]
            { 
            $"Sprawdź lokalne prawa w {(current_area.Sex == false ? "tym" : "tej")} {Program.AngPolMiejscownik[current_area.Type]}.",
            $"Sprawdź prawa w {(current_area.Sex == false ? "tym" : "tej")} {Program.AngPolMiejscownik[current_area.Type]}.",
            $"sprawdź umowy miedynarodowe w {(current_area.Sex == false ? "tym" : "tej")} {Program.AngPolMiejscownik[current_area.Type]}. ",
            "Wyszukaj umowy miedzynarodowe",
                "Znajdź swój obszar.",
            $"zobacz { current_area.Name } pod który {po_podktóry} {Program.AngPolMianownik[current_area.Type]} podlega.",//current_area.sex==true ? ten : ta plec biologiczno jest zasadniczo determinowa przez obecnosc chromosomu y
            $"zobacz obszary podległe {(current_area.Sex == false ? "tego" : "tej")} {Program.AngPolCelownik[current_area.Type]}.",
            "edytuj",
            "Zakoncz"
            };
            int menuposy = 2, menuposx = 0;
            main_menu = new Menu(main_menu_string, menuposx, menuposy);
            main_menu.Shower = new Showernoclear();
            end = main_menu_string.Length - 1;
            
        }
        public void Show() {
            while ((task > -1 && task != end))
            {
                if (current_area.Type == "Province")
                {
                    po_podktóry = "to";
                }
                else { po_podktóry = (current_area.Sex == false ? "ten" : "ta"); }

                main_menu_string = new string[]
                {
                    $"Sprawdź lokalne prawa w {(current_area.Sex == false ? "tym" : "tej")} {Program.AngPolMiejscownik[current_area.Type]}.",
                    $"Sprawdź prawa w {(current_area.Sex == false ? "tym" : "tej")} {Program.AngPolMiejscownik[current_area.Type]}.",
                    $"sprawdź umowy miedynarodowe w {(current_area.Sex == false ? "tym" : "tej")} {Program.AngPolMiejscownik[current_area.Type]}. ",
                    "Wyszukaj umowy miedzynarodowe",
                    "Znajdź swój obszar.",
                    $"zobacz { current_area.Name } pod który {po_podktóry} {Program.AngPolMianownik[current_area.Type]} podlega.",//current_area.sex==true ? ten : ta plec biologiczno jest zasadniczo determinowa przez obecnosc chromosomu y
                    $"zobacz obszary podległe {(current_area.Sex == false ? "tego" : "tej")} {Program.AngPolCelownik[current_area.Type]}.",
                    "edytuj",
                    "Zakoncz"
                };// mam nadzeje ze sie w przypadkach nie pomyliłem
                //Console.Clear();
                Console.WriteLine(current_area.Name);
                Console.WriteLine(message);
                main_menu.Refresh_string(main_menu_string);

                //main_menu.Wybrany = task;

                task = main_menu.Show();

                Searcher searcher = new Searcher();
                try
                {
                    switch (task)
                    {
                        case 0:
                            FindLocalLaw();
                            break;
                        case 1:
                            FindAllLaw();
                            break;
                        case 2:
                            FindhorLaw();
                            break;
                        case 3:
                            Searchhorlaw();
                            break;
                        case 4:
                            current_area = searcher.Search(main_menu.DlugoscMaxElement, task + main_menu.Posy,current_area);
                            Console.Clear();
                            break;
                        case 5:
                            current_area = admhigher(areas, current_area, message);
                            break;
                        case 6:
                            current_area = admlover();
                            Console.Clear();
                            break;
                        case 7:
                            Edit Edit = new Edit(areas);
                            Edit.Show();
                            Console.Clear();
                            break;
                        case 8:
                            return;

                    }
                    // Console.Clear();
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(message);
                    message = "";
                    Console.SetCursorPosition(0, 0);
                }
                finally { };
                /*
                catch (Exception e)
                {
                    message = e.Message;//to chyba nie działa
                    try
                    {
                        StreamWriter streamWriter = File.CreateText("log.ts");
                        streamWriter.WriteLine($"{e.Message}");
                        streamWriter.Close();
                    }
                    catch (System.IO.IOException loge)
                    {
                        message=message+" "+loge.Message;
                    }
                }
                */
            }
        }
    }
}
