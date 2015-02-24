using UnityEngine;
using System.Collections;

public class QuestItem : Thing {
    
    public QuestItem(int thingID, string thingName, string thingDescription, bool isCollect) :
        base(thingID, thingName, thingDescription, isCollect)
    {

    }
	
}
