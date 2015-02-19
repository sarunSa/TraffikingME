using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float gameTime; //time spend in this game
    public Quest currentQuest;
    public QuestManager questManager;
    public bool isAlert;
    public float timeAlertEnd = 5;
    public float alertTime;
    public EventHandling eventHandling;
	// Use this for initialization
    CharacterEmotion player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterEmotion>();
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;


	}

    
}
