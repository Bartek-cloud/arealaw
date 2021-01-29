using System;
using Area_date_ns;
using menu;
namespace obszary_covid_jpp
{
    internal static partial class Edit
    {
        internal static void edit_select(Areas.Areas areas, Area_date current_area, int DlugoscMaxElement, int posnewmenu, string message)//chyba zrboie z tego klase bo to za duzo kodu;
        {
            int what, dod;
            do
            {
                Console.Clear();
                var menuwhat = new Menu(new string[] { "obszary", "prawo", "powrót" }, 0, 0);
                what = menuwhat.Show();
                var Menudo = new Menu(new string[] { "dodaj", "modyfikuj", "usun","powrót", }, 0, 0);
                var Menudoclaw = new Menu(new string[] { "document", "prawo"," powrót" }, 0, 0);

                switch (what)
                {
                    case 0:
                        dod = Menudo.Show();
                        switch (dod)
                        {
                            case 0:
                                //reczne tworzenei obszaru
                                EditArea.hand_made_area(areas);
                                break;
                            case 1:
                                EditArea.Modarea(areas, current_area,0, 0, message);
                                break;
                            case 2:
                                EditArea.DeleteArea(areas, current_area, 0, 0, message);
                                break;
                            case 3:
                                what = 2;
                                break;
                        }
                        break;
                    case 1:
                        dod = Menudo.Show();
                        int doc;
                        switch (dod)
                        {
                            case 0:
                                Menudoclaw.Refresh_string(new string[] { "obszary do prawa", "prawo poziome", "powrót" });
                                doc = Menudoclaw.Show();
                                if (doc == 0)
                                {
                                    MakeDocument.MakeDocumentto(areas, current_area, 0, 0, message);
                                }
                                else if(doc==1)
                                {
                                    Editmainfunction.MakeLawHor(areas, current_area, 0, 0, message);
                                }
                                break;
                            case 1:
                                doc = Menudoclaw.Show();
                                if (doc == 0)
                                {
                                    Menu typeemenu = new Menu(new string[] { "poziome", "pionowe",  }, 0, 0);
                                    int typee = typeemenu.Show();
                                    if (typee == 0)
                                    {
                                        ModDoc.Moddochor(areas, current_area, 0, 0, message);
                                    }
                                    else if (typee == 1)
                                    {
                                        ModDoc.Moddocver(areas, current_area, 0, 0, message);
                                    }
                                    
                                }
                                else if (doc == 1)
                                {
                                    Menu typeemenu = new Menu(new string[] { "pionowe", "poziome" }, 0, 0);
                                    int typee = typeemenu.Show();
                                    if (typee == 1)
                                    {
                                        ModLaw.ModLawver(areas, current_area, 0, 0, message);
                                    }
                                    else if (typee == 1)
                                    {
                                        ModLaw.ModLawhor(areas, current_area, 0, 0, message);
                                    }
                                }
                                break;
                            case 2:
                                Menu typemenu = new Menu(new string[] { "pionowe", "poziome" }, 0, 0);
                                int type = typemenu.Show();
                                if (type == 1)
                                {
                                    ModLaw.DelLawver(areas, current_area, 0, 0, message);
                                }
                                else if(type == 2)
                                {
                                    ModLaw.DelLawhor(areas, current_area, 0, 0, message);
                                }
                                break;
                            case 3:
                                what = 2;
                                break;

                        }
                        break;

                }
            } while (what != 2 && what != -1);
            //pass
            return;
        }

    }
}