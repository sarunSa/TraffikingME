using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float gameTime; //time spend in this game
    public Quest currentQuest;
    private QuestManager questManager;
    private ThingManager thingManager;
    public bool isAlert;
    public float timeAlertEnd = 5;
    public float alertTime;
    public EventHandling eventHandling;
	// Use this for initialization
    CharacterEmotion player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterEmotion>();
        questManager = new QuestManager();
        thingManager = new ThingManager();
        currentQuest = questManager.getCurrentQuest(1); //let default quest is mission 1 
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
        if (isAlert)
        {
            Timealtert();
            Debug.Log("alert!! " + alertTime);
        }
	}

    void UpdateQuestStatus()
    {
        if (currentQuest.QuestStatus == "incomplete")
        {
            currentQuest.QuestStatus = "in progress";
            questManager.setQuestStatus(currentQuest, currentQuest.QuestStatus);
        }
        else if(currentQuest.QuestStatus == "completed"){
            //currentQuest.QuestStatus = "completed";
            questManager.setQuestStatus(currentQuest, currentQuest.QuestStatus);
        }
    }
    public bool GetItemInQuest(int key)
    {
        bool haveItem = false;
        if (currentQuest != null)
        {
            if (currentQuest.GetType() == typeof(HelpingQuest))
            {

            }
            else if (currentQuest.GetType() == typeof(FindingQuest))
            {
                FindingQuest temp = (FindingQuest)currentQuest;
                haveItem = temp.HaveItem(key);
            }
            else if (currentQuest.GetType() == typeof(BossQuest))
            {

            }
            else if (currentQuest.GetType() == typeof(MapQuest)){
                
                
            }
        }
        

        return haveItem;
    }

    public bool IsArrive(int key)
    {
        bool arrived = false;

        if (currentQuest.GetType() == typeof(MapQuest))
        {
            MapQuest temp = (MapQuest)currentQuest;
            arrived = temp.IsInDestination(key);
        }

        return arrived;
    }
    public void Timealtert()
    {
        if (alertTime > 0)
        {
            alertTime -= Time.deltaTime;
        }
        else
        {
            isAlert = false;
        }
    }
    public void SetAlert(bool n)
    {
        alertTime = timeAlertEnd;
        isAlert = n;
    }
    
    
}
