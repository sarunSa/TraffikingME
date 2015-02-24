using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossQuest : Quest {

    List<List<int>> bossList;
    public BossQuest(int questID, string questName, string questDescription, string questStatus, int score)
        : base(questID, questName, questDescription, questStatus, score)
    {
        bossList = new List<List<int>>();
    }

    public void addBoss(int bossID, int mapID)
    {
        List<int> temp = new List<int>();
        temp.Add(bossID);
        temp.Add(mapID);
        bossList.Add(temp);
    }

    //key = mapID
    public bool HaveBoss(int key)
    {
        bool result = false;

        for (int i = 0; i < bossList.Count; i++)
        {
            if (key == bossList[i][1])
            {
                result = true;
                break;
            }
        }

        return result;
    }

}
