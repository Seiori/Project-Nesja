﻿using System.Reflection.Metadata.Ecma335;

public class SummonerSpells
{
    public Asset FirstSpellData { get; set; }
    public Asset SecondSpellData { get; set; }
    public float Winrate { get; set; }
    public float Pickrate { get; set; }
    public int TotalGames { get; set; }

    public async Task<SummonerSpells> FetchAssetImages()
    {
        await Task.WhenAll(
            FirstSpellData.FetchAssetImage(),
            SecondSpellData.FetchAssetImage()
            );

        return this;
    }
}