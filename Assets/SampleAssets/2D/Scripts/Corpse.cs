using UnityEngine;
using System.Collections;

public class Corpse : MonoBehaviour {
    
	// Use this for initialization
    GameObject player;
    public bool isFound;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.gameObject.tag == "Player")
        {
            
            if (!isFound)
            {
                Debug.Log("corpse!!!!");
                isFound = true;
                player.GetComponent<CharacterEmotion>().updateStat(StatList.bravery, -1, true);
                player.GetComponent<CharacterEmotion>().updateStat(StatList.encouragement, -1, true);
                
            }
        }
    }
}
