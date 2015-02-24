using UnityEngine;
using System.Collections;

public class CheckThing : MonoBehaviour {

	// Use this for initialization
    public int itemID;
    GameController gameController;
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        checkingItem();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void checkingItem()
    {
        bool result = gameController.GetItemInQuest(itemID);
        gameObject.SetActive(result);
    }
}
