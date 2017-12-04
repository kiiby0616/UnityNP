using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huyasu : MonoBehaviour {
    public GameObject pease;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "peace")
        {
            Debug.Log("aaaaaa");
        }
    }
}
