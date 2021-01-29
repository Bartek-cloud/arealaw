using System;
using menu;


namespace obszary_covid_jpp
{
    internal partial class Edit
    {
        Menu menuwhat;
        Menu Menudo;
        Menu Menudoclaw;
        Areas.Areas areas;
        internal Edit(Areas.Areas areas)
        {
            this.areas = areas;
            menuwhat = new Menu(new string[] { "obszary", "prawo", "powrót" }, 0, 0);
            Menudo = new Menu(new string[] { "dodaj", "modyfikuj", "usun", "powrót", }, 0, 0);
            Menudoclaw = new Menu(new string[] { "document", "prawo", " powrót" }, 0, 0);
        }
        public void Show()
        {
            int what, dod;
            do
            {
                Console.Clear();             
                what = menuwhat.Show();
                //EditArea a = new EditArea();
                switch (what)
                {
                    case 0:
                        Menudo.Posy = what;
                        dod = Menudo.Show();
                        switch (dod)
                        {
                            case 0:
                                //reczne tworzenei obszaru
                                Hand_made_area creataarea = new Hand_made_area(areas);
                                creataarea.Show();
                                break;
                            case 1:
                                Modarea modarea = new Modarea(areas);
                                modarea.Show();
                                break;
                            case 2:
                                DeleteArea delarea = new DeleteArea(areas);
                                delarea.Show();
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
                                    MakeDocumentto docto = new MakeDocumentto(areas);
                                    docto.Show();
                                }
                                else if(doc==1)
                                {
                                    MakeLawHor lawhor = new MakeLawHor(areas);
                                    lawhor.Show();
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
                                        Moddochor modhor= new Moddochor(areas);
                                        modhor.Show();
                                    }
                                    else if (typee == 1)
                                    {
                                        Moddocver modhor = new Moddocver(areas);
                                        modhor.Show();
                                    }
                                    
                                }
                                else if (doc == 1)
                                {
                                    Menu typeemenu = new Menu(new string[] { "pionowe", "poziome" }, 0, 0);
                                    int typee = typeemenu.Show();
                                    if (typee == 0)
                                    {
                                        ModLawver lawver = new ModLawver(areas);
                                        lawver.Show();
                                    }
                                    else if (typee == 1)
                                    {
                                        ModLawhor lawhor = new ModLawhor(areas);
                                        lawhor.Show();
                                    }
                                }
                                break;
                            case 2:
                                Menu typemenu = new Menu(new string[] { "pionowe", "poziome" }, 0, 0);
                                int type = typemenu.Show();
                                DelDoc deldoc = new DelDoc(areas);
                                if (type == 0)
                                {
                                    DelLawver dellawver = new DelLawver(areas);
                                    dellawver.Show();
                                }
                                else if(type == 1)
                                {
                                    DelLawhor dellawhor = new DelLawhor(areas);
                                    dellawhor.Show();
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