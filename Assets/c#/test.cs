using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public GameObject[] peace;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            for(int i=0;i<5;i++)
            {
                peace[i].transform.position += new Vector3(0,1.1f,0);
            }
        }
       
	}
}
