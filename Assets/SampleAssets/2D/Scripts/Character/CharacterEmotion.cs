using UnityEngine;
using System.Collections;

public enum StatList
{
    bravery, encouragement, trust
};
public class CharacterEmotion : MonoBehaviour {
    
    
    CharacterDetail characterDetail;
    CharacterController player;
    public float maxNormalCoundown =20;
    public float maxInverseCoundown = 10;
    public float stopMoveCoundown = 3;
    private float currentTime;
    
    public float maxNormalCoundownE = 20;
    public float stopMoveCoundownE = 4;
    private float currentTimeE;

    public bool isStun;
    public bool isStunE;

	// Use this for initialization
    
    void Start()
    {
        player = GetComponent<CharacterController>();
        characterDetail = new CharacterDetail();
        currentTime = maxNormalCoundown;
        currentTimeE = maxNormalCoundownE;
	}
	
	// Update is called once per frame
	void Update () {
        //first time stun bravery

        if (player.isMove && isStun)
        {
            currentTime = stopMoveCoundown;
            player.isMove = false;

        }
        //end of stun
        if (currentTime < 0 && !player.isMove)
        {
            isStun = false;
            player.isMove = true;
        }

        //move inverse
	    if(characterDetail.getBraveryStat() == 0 && !player.isswapMove && currentTime < 0){
            player.isswapMove = true;
            currentTime = maxInverseCoundown;
            
        }
        //normal move
        else if (characterDetail.getBraveryStat() == 0 && currentTime < 0 && player.isswapMove)
        {
            player.isswapMove = false;
            currentTime = maxNormalCoundown;
            
        }

        //encouragement stat
        if (characterDetail.getEncouragementStat() == 0 && currentTimeE < 0 && !isStunE)
        {
            isStunE = true;
            currentTimeE = stopMoveCoundownE;
            player.isMove = false;
        }
        else if (characterDetail.getEncouragementStat() == 0 && currentTimeE < 0 && isStunE)
        {
            isStunE = false;
            currentTimeE = maxNormalCoundownE;
            player.isMove = true;

        }
        
        coundownTime();
        
        
	}

    public void updateStat(StatList e, int value, bool isstun)
    {
        switch(e){
            case StatList.bravery: updateBraveryStat(value); this.isStun = isstun; break;
            case StatList.encouragement: updateEncouragementStat(value); this.isStunE = isstun; break;
            case StatList.trust : ;  break;
        }
        
    }
    public void updateBraveryStat(int stat)
    {
        int temp = characterDetail.getBraveryStat();
        if (temp + stat > 0)
        {
            temp += stat;
        }
        else
        {
            temp = 0;
        }
        
        characterDetail.setBraveryStat(temp);
    }

    public void updateEncouragementStat(int stat)
    {
        int temp = characterDetail.getEncouragementStat();
        if (temp + stat > 0)
        {
            temp += stat;
        }
        else
        {
            temp = 0;
        }

        characterDetail.setEncouragementStat(temp);
    }

    public void coundownTime()
    {
        if(currentTime > 0 ){
            currentTime -= Time.deltaTime;
        }
        
        if (currentTimeE > 0)
        {
            currentTimeE -= Time.deltaTime;
        }
        //Debug.Log("Time" + currentTime+ "Time2 "+ currentTimeE);
    }
    
}

