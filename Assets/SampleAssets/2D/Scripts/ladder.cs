using UnityEngine;
using System.Collections;

public class ladder : MonoBehaviour {

	// Use this for initialization
    public bool isinSide;
    
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}
    void OnTriggerStay2D(Collider2D enter){
        
    }

    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.tag == "Player")
        {
            isinSide = true;
        }
    }

    void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.tag == "Player")
        {
            isinSide = false;
            
        }
        
    }
}
