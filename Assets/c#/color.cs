using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour {
    SpriteRenderer spr;
	// Use this for initialization
	void Start () {
        this.spr = GetComponent<SpriteRenderer>();
        
	}
	

	// Update is called once per frame
	void Update () {
        float alpha = 0.5f;
        var col = spr.color;
        col.a = alpha;
        spr.color = col;
	}
}
