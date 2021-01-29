using Area_date_ns;
using Law_data_ns;
using menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obszary_covid_jpp
{
    class Suportfunction
    {
        internal Document SelectDoc(VerLawdata local_law, int DlugoscMaxElement, int posnewmenu)
        {
            return SelectDoc(local_law, DlugoscMaxElement, posnewmenu, Menu.DeflautBackcolhos, Menu.DeflautForecolhos, Menu.DeflautBackcol, Menu.DeflautForecol);
        }
        internal Document SelectDoc(VerLawdata local_law, int DlugoscMaxElement, int posnewmenu, ConsoleColor backcol_hos, ConsoleColor forecol_hos, ConsoleColor backcol, ConsoleColor forecol)
        {
            Menu selectlaw = Menu_form_area.Law_to_menu(local_law, DlugoscMaxElement, posnewmenu);
            return SelectDoc(selectlaw, local_law);
        }
        internal Document SelectDoc(Menu menu, VerLawdata local_law)
        {
            return SelectDoc(menu, local_law.List_document);
        }
        internal Document SelectDoc(HorLawdata local_law, int DlugoscMaxElement, int posnewmenu)
        {
            return SelectDoc(local_law, DlugoscMaxElement, posnewmenu, Menu.DeflautBackcolhos, Menu.DeflautForecolhos, Menu.DeflautBackcol, Menu.DeflautForecol);
        }
        internal Document SelectDoc(HorLawdata local_law, int DlugoscMaxElement, int posnewmenu, ConsoleColor backcol_hos, ConsoleColor forecol_hos, ConsoleColor backcol, ConsoleColor forecol)
        {
            Menu selectlaw = Menu_form_area.Law_to_menu(local_law, DlugoscMaxElement, posnewmenu);
            return SelectDoc(selectlaw, local_law);
        }
        internal Document SelectDoc(Menu menu, HorLawdata local_law)
        {
            return SelectDoc(menu, local_law.List_document);
        }
        internal Document SelectDoc(Menu menu, List<Document> list_doc)
        {
            int selec = menu.Show();
            if (selec == 0 || selec == -1)
            {
                return new Document();
            }
            else
            {
                //Console.Clear();
                return list_doc[selec - 1];//Console.WriteLine(local_law.list_document[selec - 1].reference);                                                        //Console.ReadKey();
            }
        }

        internal void Show_doc(Document doc)
        {
            Console.WriteLine($"nazwa {doc.title}");
            Console.WriteLine($"nazwa {doc.brief}");
            Console.WriteLine($"nazwa {doc.reference}");
        }
        internal List<Document> TagSearch(VerLawdata law, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Aby zwezic wybór podaj tag. W przecwinym wypadku nic nie pisz");
            Console.SetCursorPosition(x, y + 1);
            string usertag = Console.ReadLine();

            if (usertag != "")
            {
                List<Document> DocWithTag = new List<Document>();
                foreach (Document doc in law.List_document)
                {
                    foreach (string tag in doc.tags)
                    {
                        if (tag == usertag)
                        {
                            DocWithTag.Add(doc);
                            break;
                        }
                    }
                }
                return DocWithTag;

            }
            else
            {
                return law.List_document;
            }
        }
        internal void Show_area_date(Area_date area, Areas.Areas areas)
        {
            Console.WriteLine($"nazwa {area.Name}");
            Console.WriteLine($"nazwa roznicujaca {area.differential_name}");
            var higher_area = areas.Get_adm_higher(area.id_higher);
            Console.WriteLine($"nazwa wyszego adm {higher_area.Name}");
            Console.WriteLine($"typ {Program.AngPolMianownik[area.Type]}");
        }
        internal string Createtags()
        {
            Console.WriteLine("podaj tagi odzielone przecinkami");
            string tags = Console.ReadLine();
            string[] tagstab = tags.Split(',');
            tags = "";
            for (int i = 0; i < tagstab.Length; i++)
            {
                tags = tags + tagstab[i].Trim() + ", ";
            }
            return tags;
        }
        internal bool Linkverfication(string link)
        {
            return true;
        }
        internal bool nameverifcation(string name)
        {
            return true;
        }
    }
}
