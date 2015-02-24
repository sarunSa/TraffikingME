using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NovelManager : MonoBehaviour {

	// Use this for initialization
    private Story currentStory;
    public VisualNovel button;
    private int path;
    public GameObject buttonway1;
    public GameObject buttonway2;
	void Start () {
        Initial();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void getAnswerFromPlayer(int n)
    {
        bool isMission= false;
        int r = currentStory.getPathWay(path,n,out isMission);
        path =r;
        Debug.Log(r);
        if (r != -1)
        {
            button.setData(currentStory.getConversation(path), currentStory.getNameCharacter(path));
        }
    }
    public void checkStory()
    {
        if (button.currentnumberText == button.getMaxConversation() + 1)
                {
                    gameObject.SetActive(false);
                }
        if (button.currentnumberText == button.getMaxConversation())
        {
           
            if (!currentStory.checkHaveQuestion(path))
            {
                button.currentnumberText++;
                
            }
            else
            {
                string[] choices = currentStory.getChoice(path);
                
                if (choices.Length == 3)
                {
                    buttonway1.SetActive(true);
                    Text[] temp = buttonway1.GetComponentsInChildren<Text>();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i].text = choices[i];
                    }
                }
                else
                {
                    buttonway2.SetActive(true);
                    Text[] temp = buttonway2.GetComponentsInChildren<Text>();
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i].text = choices[i];
                    }
                }
            }
        }
    }
    public void Initial()
    {
        buttonway1.SetActive(false);
        buttonway2.SetActive(false);
        currentStory = new IntroStory();
        path = 1;
        button.setData(currentStory.getConversation(path), currentStory.getNameCharacter(path));
        
    }
}
