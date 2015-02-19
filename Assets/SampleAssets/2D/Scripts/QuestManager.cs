using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager {

    public Dictionary<int, Quest> questList;
    public QuestManager()
    {
        questList = new Dictionary<int, Quest>();
    }

    public void Initial()
    {
        questList.Add(1, new Quest(1, "Help Friend", "Go and rescue your friend", 69));
    }

}
