using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitoL : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "tenshi")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "tenshiF")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "tenshiL")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "tenshiW")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "mamonoW")
        {
            Destroy(col.gameObject);
        }
    }
}
