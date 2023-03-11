public class RunePage
{
    public Rune? Keystone;
    public Rune? PrimTreeFirstRow;
    public Rune? PrimTreeSecondRow;
    public Rune? PrimTreeThirdRow;
    public Rune? SecTreeFirstOption;
    public Rune? SecTreeSecondOption;
    public StatMod? firstRowOption;
    public StatMod? secondRowOption;
    public StatMod? thirdRowOption;
}

public class Rune
{
    public Asset? RuneAsset;
    public RuneType RuneType;
    public float Winrate;
    public float Pickrate;
    public int TotalGames;
}

public class StatMod
{
    public Asset? StatModAsset;
    public float Winrate;
    public float Pickrate;
    public int TotalGames;
}

public enum RuneType
{
    Keystone,
    FirstRow,
    SecondRow,
    ThirdRow,
}