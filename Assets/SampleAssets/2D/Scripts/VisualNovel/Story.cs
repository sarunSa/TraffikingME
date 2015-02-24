using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Story {
    private string ID;
    private string name;
    private string des;
    private Dictionary<int,List<string>> text;
    private Dictionary<int,List<string>> nameCharacters;
    private Dictionary<int,List<string>> choices;
    private List<List<int>> answer;
	// Use this for initialization
    public Story(string ID, string name,string des)
    {
        this.ID = ID;
        this.name = name;
        this.des = des;
        answer = new List<List<int>>();
        text = new Dictionary<int, List<string>>();
        choices = new Dictionary<int, List<string>>();
        nameCharacters = new Dictionary<int, List<string>>();
    }
    public string getID(){
        return ID;
    }
    public string getName()
    {
        return name;
    }
    public string getDes()
    {
        return des;
    }
    public void addConversation(int n,string name, string context)
    {
        List<string> checkDictionary;
        if(!text.TryGetValue(n,out checkDictionary)){
            text.Add(n, new List<string>());
            nameCharacters.Add(n, new List<string>());
        }
        nameCharacters[n].Add(name);
        text[n].Add(context);
    }
    public void addChoices(int n, string choice)
    {
        List<string> checkDictionary;
        if (!choices.TryGetValue(n, out checkDictionary))
        {
            choices.Add(n, new List<string>());
        }
        choices[n].Add(choice);
    }
    public void addAnswer(int n, int answerQuestion, int way, int isquest)
    {
        List<int> temp = new List<int>();
        temp.Add(n);
        temp.Add(answerQuestion);
        temp.Add(way);
        temp.Add(isquest);
        answer.Add(temp);
    }
    public string[] getConversation(int n)
    {
        return text[n].ToArray();
    }
    public string[] getChoice(int n)
    {
        return choices[n].ToArray();
    }
    public int[] getAnswer(int n)
    {
        return answer[n].ToArray();
    }
    public int getPathWay(int n, int ans, out bool isQuest)
    {
        int result =-1;
        bool isquest = false;
        for (int i = 0; i < answer.Count; i++)
        {
            if (answer[i][0] == n && answer[i][1] == ans)
            {
                result = answer[i][2];
                isquest = getisQuest(i);
                break;
            }
        }
        isQuest = isquest;
        return result;
    }
    private bool getisQuest(int n)
    {
        int result = answer[n][3];
        if (result == 1)
        {
            return true;
        }
        else
            return false;
    }
    public bool checkHaveQuestion(int n)
    {
        List<string> checkDictionary;
        return choices.TryGetValue(n, out checkDictionary);
    }
    public string[] getNameCharacter(int n)
    {
        return nameCharacters[n].ToArray();
    }
}
