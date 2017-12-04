using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mamonoL : MonoBehaviour {
   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "hito")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "hitoF")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "hitoL")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "hitoW")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "tenshiW")
        {
            Destroy(col.gameObject);
        }
    }
}
