
namespace menu
{
    public class Menuform
    {
        public static Menu Menu_yn(int position_x, int position_y)
        {
            Menu menu_yn = new Menu(new string[] { "Tak", "Nie" }, position_x, position_y);
            return menu_yn;
        }

    }
}
