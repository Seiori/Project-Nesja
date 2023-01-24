public class Ranks
{
    public Roles Iron { get; set; }
    public Roles Bronze { get; set; }
    public Roles Silver { get; set; }
    public Roles Gold { get; set; }
    public Roles Platinum { get; set; }
    public Roles Diamond { get; set; }
    public Roles Master { get; set; }
    public Roles Grandmaster { get; set; }
    public Roles Challenger { get; set; }
    public Roles All { get; set; }

    public Ranks()
    {
        Iron = new Roles();
        Bronze = new Roles();
        Silver = new Roles();
        Gold = new Roles();
        Platinum = new Roles();
        Diamond = new Roles();
        Master = new Roles();
        Grandmaster = new Roles();
        Challenger = new Roles();
        All = new Roles();
    }
}