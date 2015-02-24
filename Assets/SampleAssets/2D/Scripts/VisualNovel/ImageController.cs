using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageController : MonoBehaviour {

    enum position 
    {
        L = 0, M = 1, R = 2
    };
	// Use this for initialization
    private int[][] talker;
    private string[][] pos;
    public Image[] render;
    public Sprite[] picture;
	void Start () {
	    
	}
	
	// Update is called once per frame
    void Update() {
    talker = new int[3][] {new int[]{ 0, 1 },  new int[] { 1, 2 } , new int[]{0,1}};
    pos = new string[3][] { new string[] { "R", "M" }, new string[] { "R", "L" }, new string[]{"L","R"} };
	}
    public void UpdateRender(int n)
    {
        for (int j = 0; j < pos[n].Length; j++)
        {
            if (pos[n][j] == "L")
            {
                render[0].sprite = picture[talker[n][j]];
            }
            else if(pos[n][j] == "M")
            {
                render[1].sprite = picture[talker[n][j]];
            }
            else if (pos[n][j] == "R")
            {
                render[2].sprite = picture[talker[n][j]];
            }
        }
        
    }
    public void addData(){

    }
}
