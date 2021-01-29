using Law_ns;
namespace Law_data_ns
{

    public static class LawDataconv
    {
        static public VerLawdata Lawto_data(Vertical_law verlaw){
            return new VerLawdata(verlaw.Id, verlaw.List_document);
        }
        static public HorLawdata Lawto_data(Horizontal_law horlaw)
        {
            return new HorLawdata(horlaw.Id,horlaw.Name,horlaw.Idarea ,horlaw.List_document);
        }
        static public VerLawdata HortoverLawdata(Horizontal_law horlaw)
        {
            return new VerLawdata(horlaw.Id, horlaw.List_document);
        }

    }
}
