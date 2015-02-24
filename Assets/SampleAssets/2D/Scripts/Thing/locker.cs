using UnityEngine;
using System.Collections;

public class locker : MonoBehaviour {

	// Use this for initialization
    public GameObject getInLocker;
    public GameObject getOutLocker;
    public GameObject player;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); 

        getInLocker.SetActive(false);
        getOutLocker.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.gameObject.tag == "Player")
        {
            
            getInLocker.SetActive(true);
            
        }

    }

    void OnTriggerStay2D(Collider2D stay)
    {
        if (stay.gameObject.tag == "Player")
        {

            if (getInLocker.GetComponent<taplocker>().inLocker && getOutLocker.GetComponent<taplocker>().inLocker)
            {
                getInLocker.SetActive(false);
                getOutLocker.SetActive(true);
                
                player.renderer.enabled = false;
            }
            else if (getInLocker.GetComponent<taplocker>().inLocker == false && getOutLocker.GetComponent<taplocker>().inLocker == false)
            {
                getInLocker.SetActive(true);
                getOutLocker.SetActive(false);

                player.renderer.enabled = true;
            }
            
        }
        
    }


    void OnTriggerExit2D(Collider2D exit)
    {
        
        if (exit.gameObject.tag == "Player")
        {
            getInLocker.SetActive(false);

        }
    }

}
