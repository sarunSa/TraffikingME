using UnityEngine;
using System.Collections;

public class CharacterDetail {

    private string characterName;
    private int gender;
    private int age;
    private int braveryStat;
    private int encouragementStat;
    private int trustinessStat;
    public CharacterDetail()
    {
        braveryStat = 1;
        encouragementStat = 1;
    }

    public void setBraveryStat(int braveryStat)
    {
        this.braveryStat = braveryStat;
    }

    public int getBraveryStat()
    {
        return braveryStat; 
    }
    public void setEncouragementStat(int encour)
    {
        this.encouragementStat = encour;
    }
    public int getEncouragementStat()
    {
        return this.encouragementStat;
    }
    public void setTrustnessStat(int trust)
    {
        this.trustinessStat = trust;
    }
    public int getTrustnessStat()
    {
        return this.trustinessStat;
    }
}
