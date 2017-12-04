using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zisseki : MonoBehaviour {
    bool[] storyN = new bool[12];
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        storyN[0] = kaunto.ziseki(0);
        canvas.SetInteractive("story", storyN[0]);
        storyN[1] = kaunto.ziseki(1);
        canvas.SetInteractive("storyH1", storyN[1]);
    }
}
