using UnityEngine;
using System.Collections;

public class CheckMap : MonoBehaviour {

    GameController gameController;
    public int mapID;
	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        CheckingMap();
	}

    public bool CheckingMap()
    {
        bool result = gameController.IsArrive(mapID);
        Debug.Log("Arrived: " + result);
        return result;

        
            
    }
	
	
}
