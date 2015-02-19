using UnityEngine;
using System.Collections;

public class Quest {

    private int score;
    private int questID;
    private string questName;
    private string questDescription;
    public Quest(int questID, string questName, string questDescription, int score)
    {
        this.score = score;
        this.questID = questID;
        this.questName = questName;
        this.questDescription = questDescription;
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
}
