using UnityEngine;
using System.Collections;

public class DoorLadder : MonoBehaviour {

	// Use this for initialization
    CharacterController player;
    public bool movingUp;
    public ladder Ladder;
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D e)
    {
        if (e.tag == "Player")
        {
            if (!movingUp && player.move2 < 0)
            {
                player.isClimb = true;
            }
            else if (movingUp && player.move2 < 0)
            {
                player.isClimb = false;
            }
        }
        
    }
    void OnTriggerStay2D(Collider2D e)
    {
        if (e.tag == "Player")
        {
            if (movingUp && player.move2 > 0)
            {

                player.isClimb = true;
            }
            else if (!movingUp && player.move2 < 0)
            {
                player.isClimb = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D e)
    {
        
    }
}
