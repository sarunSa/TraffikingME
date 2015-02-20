using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapQuest : Quest {

    private int destination;
    public MapQuest(int questID, string questName, string questDescription, string questStatus, int score, int destination)
        : base(questID, questName, questDescription, questStatus, score)
    {
        this.destination = destination;
    }

    public void setDestination(int mapID){
        destination = mapID;
    }

    public bool IsInDestination(int mapID)
    {
        bool result = false;
        if (mapID == destination)
        {
            result = true;
        }

        return result;
    }
	
}
