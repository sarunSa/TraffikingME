using UnityEngine;
using System.Collections;

public class DoorEnter : MonoBehaviour {

	// Use this for initialization
    //public CharacterController player;
    bool isActivate;
    public string mapName;
    public string nameSummon;
    public SceneOnLoad target;
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<SceneOnLoad>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.tag == "Player")
        {
            target.summon = nameSummon;
            //get current scene
            /*if (Application.loadedLevelName == "start_point")
            {
                //Debug.Log("Door entering");
                Application.LoadLevel(1);
            }
            else if (Application.loadedLevelName == "tutorial_point")
            {
                if(gameObject.name == "Door1"){
                    Application.LoadLevel(0);
                }
                else
                {
                    Application.LoadLevel(2);
                }
            }
            else
            {
                Application.LoadLevel(1);
            }*/
            Application.LoadLevel(mapName);
        }
    }
    
}
