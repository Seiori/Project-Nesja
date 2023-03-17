using System.Windows.Documents;

public class ItemSet
{
    public List<int>? associatedChampions;
    public List<int>? associatedMaps;
    public List<Block>? blocks;
    public string? map;
    public string? mode;
    public List<int>? preferredItemSlots;
    public int sortrank;
    public string? title;
    public string? type;
    public string? uid;
}

public class ItemGroup
{
    public Asset? FirstItem;
    public Asset? SecondItem;
    public Asset? ThirdItem;
    public float Winrate;
    public float Pickrate;
    public float TotalGames;
}

public class Item
{
    public Asset? ItemAsset;
    public float Winrate;
    public float Pickrate;
    public int TotalGames;
}

public class ItemInfo
{
    public int count;
    public string? id;
}

public class Block
{
    public List<ItemInfo>? items;
    public string? type;
}