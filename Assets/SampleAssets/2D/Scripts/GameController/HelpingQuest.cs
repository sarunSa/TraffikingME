using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HelpingQuest : Quest
{
    // Use this for initialization
    
    private List<int> mapObjective; //map that contain this quest

    public HelpingQuest(int questID, string questName, string questDescription, string questStatus, int score)
        : base(questID, questName, questDescription, questStatus, score) 
    {
        mapObjective = new List<int>();
    }       

    public void AddMapObjective(int mapID)
    {
        mapObjective.Add(mapID);
    }

    public bool HaveMapID(int mapID)
    {
        bool result = false;
        for(int i = 0;  i < mapObjective.Count; i++)
        {
            if(mapID==mapObjective[i])
            {
                result = true;
                break;
            }
        }
        return result;
    }


}
