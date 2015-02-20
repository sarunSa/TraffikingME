using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThingManager {

    private Dictionary<int, Thing> thingList;
    public ThingManager()
    {
        thingList = new Dictionary<int, Thing>();
        initial();
    }

    public void initial()
    {
        // thing type 1 = document, 2 = sound, 3 = quest item
        // 1xxxx, 2xxxx, 3xxxx
        thingList.Add(10001, new Document(10001, "Document1", "Document1 description", false, "Document1 data"));
        thingList.Add(10002, new Document(10002, "Document2", "Document2 description", false, "Document2 data"));
        thingList.Add(10003, new Document(10003, "Document3", "Document3 description", false, "Document3 data"));
        thingList.Add(20001, new SoundAttraction(20001, "Mouse sound", "Mouse sound description", false, "Mouse sound file", 6.90f));
        thingList.Add(30001, new QuestItem(30001, "Fuel", "Fuel description", false));
        thingList.Add(30002, new QuestItem(30002, "Lighter", "Lighter description", false));
    }

    public Document getDocument(int key)
    {

        if (thingList[key] != null && thingList[key].GetType() == typeof(Document))
        {
            return (Document)thingList[key];
        }
        else
            return null;  
    }
    public SoundAttraction getSound(int key)
    {

        if (thingList[key] != null && thingList[key].GetType() == typeof(SoundAttraction))
        {
            return (SoundAttraction)thingList[key];
        }
        else
            return null;
    }
    public QuestItem getQuestItem(int key)
    {

        if (thingList[key] != null && thingList[key].GetType() == typeof(QuestItem))
        {
            return (QuestItem)thingList[key];
        }
        else
            return null;
    }

}
