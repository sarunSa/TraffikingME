using UnityEngine;
using System.Collections;

public class SoundAttraction : Thing {

	// Use this for initialization
    private string soundFile;
    private float soundLength;

    public string SoundFile
    {
        set { this.soundFile = SoundFile; }
        get { return this.soundFile; }
    }

    public float SoundLength
    {
        set { this.soundLength = SoundLength; }
        get { return this.soundLength; }
    }

    public SoundAttraction(int thingID, string thingName, string thingDescription, bool isCollect, string soundFile, float soundLength)
        : base(thingID, thingName, thingDescription, isCollect)
    {
        this.soundFile = soundFile;
        this.soundLength = soundLength;
    }
}
