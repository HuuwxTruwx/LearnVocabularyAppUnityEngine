using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayersRank")]
public class Leaderboard : ScriptableObject
{
   public List<Player> Players = new List<Player>();

    public void AddPlayerRank(string id,string rank,string score)
    {
        Player player = new Player(id,rank, score);
        Players.Add(player);
    }

    
}

public class Player
{
    public string id;
    public string rank;
    public string totalScore;

    public Player (string id,string rank,string score)
    {
        this.id = id;
        this.rank = rank;
        this.totalScore = score;
    }
}
