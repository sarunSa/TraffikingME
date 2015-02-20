using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Quest {

    private int score;
    private int questID; //finding quest 1xxxx, helping quest 2xxxx
    private string questName;
    private string questDescription; 
    private string questStatus; //incomplete, in progress, completed
    private List<int> nextQuestID;


    public Quest(int questID, string questName, string questDescription, string questStatus, int score)
    {
        this.score = score;
        this.questID = questID;
        this.questName = questName;
        this.questDescription = questDescription;
        this.questStatus = questStatus;
        nextQuestID = new List<int>();
    }

    public int Score
    {
        set { this.score = Score; }
        get { return this.score; }
    }

    public int QuestID
    {
        set {  this.questID = QuestID; }
        get {  return this.questID; }
    }

    public string QuestName
    {
        set {  this.questName = QuestName; }
        get {  return this.questName; }
    }

    public string QuestDescription
    {
        set {  this.questDescription = QuestDescription; }
        get { return this.questDescription;  }
    }

    public string QuestStatus
    {
        set { this.questStatus = QuestStatus;  }
        get { return this.questStatus; }
    }

    public void addnextQuestID(int questID)
    {
        nextQuestID.Add(questID);
    }

    
}
