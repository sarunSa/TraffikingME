using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	// Use this for initialization
    float speed = 5.0f;
    float wallLeft = 10.0f;
    float wallRight = 25.0f;
    bool onSight; // found player

    GameObject player;
    SpriteRenderer sprite;
    
    float faceDirection = 1.0f; //default face right
    Vector2 direction = Vector2.right;
    bool isAttackEnemy;


    public Transform currentladder;
    private bool EnemyMoveup;
    public LayerMask layermasks;
    private Vector2 radarVector;
    private bool radarRight;
    private bool checkInsideLadder;
    private GameObject[] allLadder;
    private bool isFindladder;
    private bool isinsideLadder;
    public LayerMask whatisLadder;
    public Transform ground;
    public float radiusGround = 0.2f;
    public float gravity = 20f;
    private bool isClimb;
    private bool enemyMoveDown;
    
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        radarVector = new Vector2(-1, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        isinsideLadder = Physics2D.OverlapCircle(ground.position, radiusGround, whatisLadder);

        direction = new Vector2(faceDirection, 0);

        if (!onSight) //not find player
        {
            transform.Translate(new Vector2(speed * faceDirection * Time.deltaTime, rigidbody2D.velocity.y));

            if (faceDirection > 0 && transform.position.x > wallRight)
            {
                faceDirection = -1.0f;
                Flip();
                
            }
            else if (faceDirection < 0 && transform.position.x < wallLeft)
            {
                faceDirection = 1.0f;
                Flip();
                
            }
            
        }
        DetectEnemy();
        MoveToPlayer();
        DetectEnemyUp();
        DetectEnemyDown();
        
        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //DestroyObject(player);
            onSight = false;
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
        if (isAttackEnemy) //when enemy find you
        {
            onSight = true;
            
            if (EnemyMoveup || enemyMoveDown)
            {
                
                float temp = 1;
                if (enemyMoveDown)
                {
                    temp = -1;
                }
                else
                {
                    temp = 1;
                }
                if (!isFindladder && currentladder ==null)
                {
                    FindLadder();
                    isFindladder = true;
                }
                if (isClimb)
                {
                    checkInsideLadder = true;
                    rigidbody2D.MovePosition(rigidbody2D.position + new Vector2(0,temp *speed* Time.deltaTime));
                    
                }
                if (!checkInsideLadder)
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
            else if (player.transform.position.x > transform.position.x) //player on the right side
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
        else
        {
            onSight = false;
        }
    }

    void Flip()
    {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void DetectEnemy()
    {
        RaycastHit2D hitSomething = Physics2D.Raycast(transform.position, direction, 8.0f);
        if (hitSomething.collider != null)
        {
            if (hitSomething.collider.gameObject.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("MainCamera").SendMessage("SetAlert", true);
                if (!isClimb)
                {
                    isAttackEnemy = true;
                    EnemyMoveup = false;
                    checkInsideLadder = false;
                    currentladder = null;
                    enemyMoveDown = false;
                    isFindladder = false;
                }

            }
            
        }
    }
    void DetectEnemyUp()
    {
        if (radarRight)
        {
            radarVector.x += 1;
            if (radarVector.x >= 5)
            {
                radarRight = false;
            }
        }
        else
        {
            radarVector.x -= 1;
            if (radarVector.x <= -5)
            {
                radarRight = true;
            }
        }
        RaycastHit2D hitSomething = Physics2D.Raycast(transform.position, new Vector2(radarVector.x/10,1), 30.0f,layermasks);
        
        if (hitSomething.collider != null)
        {
           // Debug.Log(hitSomething.collider.tag );
            if (hitSomething.collider.gameObject.tag == "Player")
            {
                EnemyMoveup = true;
            }

        }
    }
    void OnTriggerEnter2D(Collider2D e)
    {
        if (e.tag == "mouth")
        {

            DoorLadder temp = e.GetComponent<DoorLadder>();
            if (temp.movingUp && enemyMoveDown && !EnemyMoveup)
            {

                isClimb = false;
                //checkInsideLadder = false;
                enemyMoveDown = false;
                EnemyMoveup = false;
                //isFindladder = false;
                currentladder = null;
            }
            else if (!temp.movingUp && !enemyMoveDown && EnemyMoveup)
            {
                currentladder = null;
            }
        }
    }
    void OnTriggerStay2D(Collider2D e)
    {
        
        if ((e.tag == "Ladder" || e.tag =="mouth")  && isinsideLadder)
        {
            if ((enemyMoveDown || EnemyMoveup) && currentladder != null)
            {
                
                if ((transform.position.x - currentladder.position.x) <0.3)
                {
                    isClimb = true;
                    
                }
            }

           // Debug.Log("ladder!!!");
            isFindladder = false;
        }
    }
    void OnTriggerExit2D(Collider2D e)
    {

        if (e.tag == "Ladder")
        {
            checkInsideLadder = false;
            EnemyMoveup = false;
            enemyMoveDown = false;
            rigidbody2D.gravityScale = 20;
            rigidbody2D.isKinematic = true;
        }
    }
    void FindLadder()
    {
        allLadder = GameObject.FindGameObjectsWithTag("Ladder");
        float result =300;
        float positionOfOject;
        if (enemyMoveDown)
        {
            positionOfOject = transform.position.x;
        }
        else if (EnemyMoveup)
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
    void DetectEnemyDown()
    {
        RaycastHit2D hitSomething = Physics2D.Raycast(transform.position, new Vector2(radarVector.x/10,-1), 30.0f,layermasks);

        if (hitSomething.collider != null)
        {
            // Debug.Log(hitSomething.collider.tag );
            if (hitSomething.collider.gameObject.tag == "Player")
            {
                enemyMoveDown = true;
            }
            else
            {
                enemyMoveDown = false;
            }

        }
    }
}
