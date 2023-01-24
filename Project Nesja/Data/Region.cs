public class Region
{
    public Ranks NA { get; set; }
    public Ranks EUW { get; set; }
    public Ranks EUNE { get; set; }
    public Ranks OCE { get; set; }
    public Ranks KR { get; set; }
    public Ranks JP { get; set; }
    public Ranks BR { get; set; }
    public Ranks LAS { get; set; }
    public Ranks LAN { get; set; }
    public Ranks RU { get; set; }
    public Ranks TR { get; set; }
    public Ranks SG { get; set; }
    public Ranks PH { get; set; }
    public Ranks TW { get; set; }
    public Ranks VN { get; set; }
    public Ranks TH { get; set; }
    public Ranks All { get; set; }

    public Region()
    {
        NA = new Ranks();
        EUW = new Ranks();
        EUNE = new Ranks();
        OCE = new Ranks();
        KR = new Ranks();
        JP = new Ranks();
        BR = new Ranks();
        LAS = new Ranks();
        LAN = new Ranks();
        RU = new Ranks();
        TR = new Ranks();
        SG = new Ranks();
        PH = new Ranks();
        TW = new Ranks();
        VN = new Ranks();
        TH = new Ranks();
        All = new Ranks();
    }
}