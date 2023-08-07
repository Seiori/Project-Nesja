using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Project_Nesja.Objects
{
    public interface IMatchData
    {

    }

    public class Normal : IMatchData
    {
        public int Duration;
        public int Timestamp;
        public string? Version;
        public int Queue;
        public bool ParseLaning;
        public string[]? Lane;
        public int[]? Champion;
        public int[]? Winner;
        public int[]? Barons;
        public int[]?    Herald;
        public int[]? Dragon;
        public int[]? Tower;
        public int[]? Inhib;
        public int[][]? Items;
        public int[][]? Spell;
        public int[]? Kills;
        public int[]? Deaths;
        public int[]? Assists;
        public int[]? TotalDamageDealtToChampions;
        public int[]? PhysicalDamageDealtToChampions;
        public int[]? MagicDamageDealtToChampions;
        public int[]? TrueDamageDealtToChampions;
        public int[]? TotalDamageTaken;
        public int[]? TotalHeal;
        public int[]? LargestKillingSpree;
        public int[]? GoldEarned;
        public int[]? TotalMinionsKilled;
        public int[]? NeutralMinionsKilled;
        public int[]? VisionWardsBoughtInGame;
        public int[]? WardsPlaced;
        public int[]? WardsKilled;
        public int[]? ChampionLevel;
        public int[]? TurretKills;
        public int[]? InhibitorKills;
        public int[]? DoubleKills;
        public int[]? TripleKills;
        public int[]? QuadraKills;
        public int[]? PentaKills;
        public string[]? PUUID;
        public string[]? SummonerName;
        public int[]? StatPerk0;
        public int[]? StatPerk1;
        public int[]? StatPerk2;
        public int[]? Perk0;
        public int[]? Perk1;
        public int[]? Perk2;
        public int[]? Perk3;
        public int[]? PerkPrimaryStyle;
        public int[]? Perk4;
        public int[]? Perk5;
        public int[]? PerkSubStyle;
        public string[]? Skill;
        public JArray? Build;
        public int[]? Bans;
        public string? Source;
        public string[]? CurrentName;
        public string[]? Tier;
        public string[]? Division;
        public int[]? LP;
        public string? Mid;
    }

    public class Bot : IMatchData
    {
        public int Duration;
        public int Timestamp;
        public string? Version;
        public int Queue;
        public bool ParseLaning;
        public string[]? Lane;
        public int[]? Champion;
        public int[]? Winner;
        public int[]? Barons;
        public int[]? Herald;
        public int[]? Dragon;
        public int[]? Tower;
        public int[]? Inhib;
        public JArray? Items;
        public JArray? Spell;
        public int[]? Kills;
        public int[]? Deaths;
        public int[]? Assists;
        public int[]? TotalDamageDealtToChampions;
        public int[]? PhysicalDamageDealtToChampions;
        public int[]? MagicDamageDealtToChampions;
        public int[]? TrueDamageDealtToChampions;
        public int[]? TotalDamageTaken;
        public int[]? TotalHeal;
        public int[]? LargestKillingSpree;
        public int[]? GoldEarned;
        public int[]? TotalMinionsKilled;
        public int[]? NeutralMinionsKilled;
        public int[]? VisionWardsBoughtInGame;
        public int[]? WardsPlaced;
        public int[]? WardsKilled;
        public int[]? ChampionLevel;
        public int[]? TurretKills;
        public int[]? InhibitorKills;
        public int[]? DoubleKills;
        public int[]? TripleKills;
        public int[]? QuadraKills;
        public int[]? PentaKills;
        public string[]? PUUID;
        public string[]? SummonerName;
        public int[]? StatPerk0;
        public int[]? StatPerk1;
        public int[]? StatPerk2;
        public int[]? Perk0;
        public int[]? Perk1;
        public int[]? Perk2;
        public int[]? Perk3;
        public int[]? PerkPrimaryStyle;
        public int[]? Perk4;
        public int[]? Perk5;
        public int[]? PerkSubStyle;
        public string[]? Skill;
        public JArray? Build;
        public string[]? CurrentName;
        public string[]? Tier;
        public string[]? Division;
        public int[]? LP;
        public string? Mid;
    }

    public class Arena : IMatchData
    {
        public int Duration;
        public int Timestamp;
        public string? Version;
        public int Queue;
        public int[]? Champion;
        public int[]? Team;
        public int[]? Placement;
        public int[]? Winner;
        public int[][]? Items;
        public int[]? Augment1;
        public int[]? Augment2;
        public int[]? Augment3;
        public int[]? Augment4;
        public int[]? Kills;
        public int[]? Deaths;
        public int[]? Assists;
        public int[]? TotalDamageDealtToChampions;
        public int[]? PhysicalDamageDealtToChampions;
        public int[]? MagicDamageDealtToChampions;
        public int[]? TrueDamageDealtToChampions;
        public int[]? TotalDamageTaken;
        public int[]? TotalHeal;
        public int[]? LargestKillingSpree;
        public int[]? GoldEarned;
        public int[]? ChampionLevel;
        public int[]? DoubleKills;
        public string[]? PUUID;
        public string[]? SummonerName;
        public string[]? Skill;
        public JArray? Build;
        public int[]? Bans;
        public string? Source;
        public string[]? CurrentName;
        public string[]? Tier;
        public string[]? Division;
        public int[]? LP;
        public string? Mid;
    }
}
