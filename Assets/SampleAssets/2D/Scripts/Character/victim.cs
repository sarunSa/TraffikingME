using UnityEngine;
using System.Collections;

public class victim : MonoBehaviour {

	// Use this for initialization
    public tapHelp popup;
    public Animator anim;
    float speed = 8.0f;
    public bool onSight;

    GameObject player;
    SpriteRenderer sprite;
    float faceDirection = -1.0f; //default face left
    Vector2 direction = Vector2.right;
    public LayerMask layermasks;
    public Transform currentladder;
    private bool radarRight;
    public bool playerMoveUp;
    public bool playerMoveDown;
    public bool notmovetoLadder;
    private GameObject[] allLadder;
    private bool isFindladder;
    public bool isinsideLadder;
    public LayerMask whatisLadder;
    public Transform ground;
    public Transform head;
    public float radiusGround = 0.2f;
    public bool isClimb;
	void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        popup.gameObject.SetActive(false);


        
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (popup.helpStatus)
        {
            popup.gameObject.SetActive(false);

            isinsideLadder = Physics2D.OverlapCircle(ground.position, radiusGround, whatisLadder);

            //make player trigger to victim 
            Physics2D.IgnoreCollision(player.collider2D, collider2D);

            
            CheckFaceDirection();
            DetectPlayer();
            
            DetectPlayerUp();
            DetectPlayerDown();
            MoveToPlayer();

            
        }
	}

    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.tag == "Player")
        {
            popup.gameObject.SetActive(true);
            
        }
        if (enter.tag == "mouth")
        {

            DoorLadder temp = enter.GetComponent<DoorLadder>();
            if (temp.movingUp && playerMoveDown && !playerMoveUp)
            {

                //Debug.Log("Delete ladder");
                isClimb = false;
                notmovetoLadder = false;
                playerMoveDown = false;
                playerMoveUp = false;
                isFindladder = false;
                currentladder = null;
            }
            else if (!temp.movingUp && !playerMoveDown && playerMoveUp)
            {
                
                currentladder = null;
            }
        }
    }

    void OnTriggerStay2D(Collider2D e)
    {

        if ((e.tag == "Ladder" || e.tag == "mouth") && isinsideLadder)
        {
            if ((playerMoveDown || playerMoveUp) && currentladder != null)
            {


                
                if (Mathf.Abs((transform.position.x - currentladder.position.x)) < 0.3 && e.tag == "mouth")
                {
                    isClimb = true;

                }
                
            }

            isFindladder = false;
        }
    }

    void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.tag == "Player")
        {
            popup.gameObject.SetActive(false);
            
        }
        if (exit.tag == "Ladder")
        {
            notmovetoLadder = false;
            playerMoveUp = false;
            playerMoveDown = false;
            rigidbody2D.gravityScale = 20;
            rigidbody2D.isKinematic = true;
        }
    }

    void DetectPlayer()
    {
        
        //RaycastHit2D hitSomething = Physics2D.Raycast(transform.position, direction, 8.0f, layermasks);

        Vector2 vector = player.transform.position - transform.position;
        float distanceToPlayer = Vector2.SqrMagnitude(vector);

        

        if (distanceToPlayer <= 60) {
            onSight = true;
            if (!player.GetComponent<CharacterController>().isClimb)
            {
                
                isFindladder = false;
                //currentladder = null;
                //playerMoveUp = false;
                //playerMoveDown = false;
            }
            
        }
        else
        {
            onSight = false;
        }
        if ((playerMoveDown || playerMoveUp))
        {
            notmovetoLadder = false;
        }
        else
        {
            notmovetoLadder = true;
        }

        
    }

    void DetectPlayerUp()
    {
        //Debug.Log("player: " + player.GetComponent<CharacterController>().groundCheck.position.y);
        //Debug.Log("victim: " + head.position.y);

        if (player.GetComponent<CharacterController>().groundCheck.position.y > head.position.y + 0.3
            && ground.position.y <= player.GetComponent<CharacterController>().groundCheck.position.y)
        {
            playerMoveUp = true;
        }
        else
        {
            playerMoveUp = false;
        }
        

        
    }

    void DetectPlayerDown()
    {
        //Debug.Log("player: " + player.GetComponent<CharacterController>().groundCheck.position.y);
        //Debug.Log("npc: " + ground.position.y);
        //Debug.Log(playerMoveDown);

        if (head.position.y > player.GetComponent<CharacterController>().headCheck.position.y + 0.1)
        {

            playerMoveDown = true;
        }
        else if(playerMoveDown)
        {
            

            if (ground.position.y == player.GetComponent<CharacterController>().groundCheck.position.y)
            {
                playerMoveDown = false;
            }
        }
    }

    void MoveToPlayer()
    {
        if (isinsideLadder)
        {
            rigidbody2D.gravityScale = 0;
            rigidbody2D.isKinematic = true;
            
        }
        else
        {
            rigidbody2D.gravityScale = 10;
            rigidbody2D.isKinematic = false;
            isClimb = false;

        }
        float temp = 1;
        //detect and move to player
        if (playerMoveDown)
        {
            temp = -1;
        }
        else
        {
            temp = 1;
        }
        if (onSight)
        {
            
            if (playerMoveUp || playerMoveDown)
            {
                
                
                
                if (!isFindladder && currentladder == null)
                {
                    FindLadder();
                    isFindladder = true;
                }
                if (!notmovetoLadder && !isClimb)
                {

                    if (currentladder.position.x > transform.position.x) //player on the right side
                    {
                        transform.Translate(new Vector3(speed * 1.0f * Time.deltaTime, 0, 0));
                        if (faceDirection != 1.0f)
                        {
                            Flip();
                            faceDirection = 1.0f;
                        }
                    }
                    else
                    { //player on the left side
                        transform.Translate(new Vector3(speed * -1.0f * Time.deltaTime, 0, 0));
                        if (faceDirection == 1.0f)
                        {
                            faceDirection = -1.0f;
                            Flip();
                        }
                    }
                }
            }
            
            else if (player.transform.position.x - 5 > transform.position.x) //player on the right side
            {
                
                transform.Translate(new Vector3(speed * 1.0f * Time.deltaTime, 0, 0));
                anim.SetFloat("speed", Mathf.Abs(speed));
                if (faceDirection != 1.0f)
                {
                    Flip();
                    faceDirection = 1.0f;
                }
            }
            else if (player.transform.position.x + 5 < transform.position.x)
            { //player on the left side
                transform.Translate(new Vector3(speed * -1.0f * Time.deltaTime, 0, 0));
                anim.SetFloat("speed", Mathf.Abs(speed));
                if (faceDirection == 1.0f)
                {
                    faceDirection = -1.0f;
                    Flip();
                }

            }
            else
            {
                anim.SetFloat("speed", 0);
            }
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
        
        if (isClimb)
        {

            notmovetoLadder = true;
            rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(0, temp * speed * Time.deltaTime));

        }
    }

    void CheckFaceDirection()
    {
        
        if (player.transform.position.x - 5 > transform.position.x)
        {
            direction = new Vector2(1.0f, 0);
        }
        else if (player.transform.position.x + 5 < transform.position.x)
        {
            
            direction = new Vector2(-1.0f, 0);
        }
        
    }

    void Flip()
    {

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FindLadder()
    {
        allLadder = GameObject.FindGameObjectsWithTag("Ladder");
        float result = 300;
        float positionOfOject;
        if (playerMoveDown)
        {
            positionOfOject = transform.position.x;
        }
        else if (playerMoveUp)
        {
            positionOfOject = player.transform.position.x;
        }
        else
        {
            positionOfOject = player.transform.position.x;
        }
        for (int i = 0; i < allLadder.Length; i++)
        {
            float distance = Mathf.Abs(allLadder[i].transform.position.x - positionOfOject);
            if (distance < result)
            {
                result = distance;
                currentladder = allLadder[i].transform;
            }
        }
    }
    
    
}
