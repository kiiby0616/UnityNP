using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touka : MonoBehaviour {
    SpriteRenderer spre;
    
	// Use this for initialization
	void Start () {
        this.spre = GetComponent<SpriteRenderer>();
        chantrans(0.4f);
	}
	void chantrans(float a)
    {
        this.spre.color = new Color(1, 1, 1, a);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
