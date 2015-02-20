using UnityEngine;
using System.Collections;

public class Document : Thing {

    private string dataContain;
    public string DataContain { set { dataContain = DataContain; } get { return dataContain; } }
    public Document(int thingID, string thingName, string thingDescription, bool isCollect, string dataContain)
        : base(thingID, thingName, thingDescription, isCollect)
    {
        this.dataContain = dataContain;
    }
}
