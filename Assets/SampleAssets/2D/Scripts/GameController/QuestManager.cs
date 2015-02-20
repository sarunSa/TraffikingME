using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager {

    public Dictionary<int, Quest> questList;
    public QuestManager()
    {
        questList = new Dictionary<int, Quest>();
        Initial();
    }

    public void Initial()
    {
        FindingQuest temp =  new FindingQuest(0, "Help Friend", "Go and rescue your friend", "incomplete", 100);
        temp.addObjectiveLocation(69,1);
        questList.Add(0, temp);

        questList.Add(1, new MapQuest(1, "Find the way out", "Find the main door of the building", "incomplete", 50, 2));
        questList.Add(2, new Quest(2, "Contact authority", "Find the way to contact authority for help", "incomplete", 100));
    }

    public void setQuestStatus(Quest quest, string status)
    {
        int key = quest.QuestID;
        questList[key].QuestStatus = status;
    }

    public Quest getCurrentQuest(int key)
    {
        return questList[key];
    }

    

}
