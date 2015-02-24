using UnityEngine;
using System.Collections;

public class checkStory : MonoBehaviour {

    public int mapID;
    private GameController system;
	// Use this for initialization
	void Start () {
        system = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        if(system.haveConversation(mapID)){
            Debug.Log("have conversation");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
