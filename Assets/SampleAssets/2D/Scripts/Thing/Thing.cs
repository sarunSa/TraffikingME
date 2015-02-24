using UnityEngine;
using System.Collections;

public class Thing {

    private int thingID; //thing type 1xxxx = document, 2xxxx = sound, 3xxxx = quest item
    private string thingName;
    private string thingDescription;
    private bool isCollect;
    public Thing(int thingID, string thingName, string thingDescription, bool isCollect)
    {
        this.thingID = thingID;
        this.thingName = thingName;
        this.thingDescription = thingDescription;
        this.isCollect = isCollect;
    }

    public int ThingID {
        set { this.thingID = ThingID; }
        get { return this.thingID;  }
    }

    public string ThingName
    {
        set { this.thingName = ThingName; }
        get { return this.thingName; }
    }

    public string ThingDescription
    {
        set { this.thingDescription = ThingDescription;  }
        get { return this.thingDescription; }
    }

    public bool IsCollect
    {
        set { this.isCollect = IsCollect; }
        get { return this.IsCollect; }
    }
}
