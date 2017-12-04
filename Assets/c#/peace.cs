using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peace : MonoBehaviour {
    public Sprite[] Peace;
    int spr;
    public GameObject system;
    // Use this for initialization
    void Start () {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        spr = Random.Range(0, 12);
        render.sprite = Peace[spr];
        system = GameObject.Find("system");
	}
	
	// Update is called once per frame
	void Update () {
        
    }
   
   
    public int GetSpr()
    {
        return spr;
    }
}
