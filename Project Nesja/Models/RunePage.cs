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
    public float Winrate;
    public float TotalGames;

    public int[] GetRunePageIDs()
    {
        int[] RunePageIDs = new int[9];
        RunePageIDs[0] = Keystone!.RuneAsset!.ID;
        RunePageIDs[1] = PrimTreeFirstRow!.RuneAsset!.ID;
        RunePageIDs[2] = PrimTreeSecondRow!.RuneAsset!.ID;
        RunePageIDs[3] = PrimTreeThirdRow!.RuneAsset!.ID;
        RunePageIDs[4] = SecTreeFirstOption!.RuneAsset!.ID;
        RunePageIDs[5] = SecTreeSecondOption!.RuneAsset!.ID;
        RunePageIDs[6] = firstRowOption!.StatModAsset!.ID;
        RunePageIDs[7] = secondRowOption!.StatModAsset!.ID;
        RunePageIDs[8] = thirdRowOption!.StatModAsset!.ID;
        
        return RunePageIDs;
    }

    public int GetStyleID(RuneTree runeTree)
    {
        int runeStyleID = 0;

        switch (runeTree)
        {
            case RuneTree.Precision:
                runeStyleID = 8000;
                break;
            case RuneTree.Domination:
                runeStyleID = 8100;
                break;
            case RuneTree.Sorcery:
                runeStyleID = 8200;
                break;
            case RuneTree.Resolve:
                runeStyleID = 8400;
                break;
            case RuneTree.Inspiration:
                runeStyleID = 8300;
                break;
        }
        
        return runeStyleID;
    }
}

public class Rune
{
    public Asset? RuneAsset;
    public RuneType RuneType;
    public RuneTree RuneTree;
    public float Winrate;
    public float Pickrate;
    public int TotalGames;
}

public class StatMod
{
    public Asset? StatModAsset;
    public StatModType StatModType;
    public float Winrate;
    public float Pickrate;
    public int TotalGames;
}

public enum RuneTree
{
    Precision,
    Domination,
    Sorcery,
    Resolve,
    Inspiration,
}

public enum RuneType
{
    Keystone,
    FirstRow,
    SecondRow,
    ThirdRow,
}

public enum StatModType
{
    AdaptiveForce,
    AttackSpeed,
    AbilityHaste,
    Armor,
    MagicResistance,
    Health
}