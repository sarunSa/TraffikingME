using UnityEngine;
using System.Collections;

public class IntroStory : Story {

    public IntroStory() : base("A01","KUYYYYYY","I don't know")
    {
        Initial();
    }
    public void Initial()
    {
        addConversation(1,"Benz", "hello I am Benz");
        addConversation(1, "Benz","Today I would like to present about game");
        addConversation(1, "Benz", "My game is...... I don't know. what should I do?");
        addConversation(2, "Benz", "why you are so clue");
        addConversation(2, "Benz", "I don't know I don't care");
        addConversation(2, "everyone", "die!!");
        addConversation(3, "Benz", "I don't mind");
        addConversation(3, "Benz", "I want to.....");
        addConversation(3, "everyone", "die!!");
        addChoices(1, "get out");
        addChoices(1, "go to the hell");
        addAnswer(1, 1, 2, 0);
        addAnswer(1, 2, 3, 0);
    }
}
