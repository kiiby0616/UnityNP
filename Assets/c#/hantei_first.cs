using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hantei_first : MonoBehaviour
{
    Vector2 basyo;
    GameObject Hobj;
    GameObject pare;
    // Use this for initialization
    void Start()
    {
        basyo = transform.localPosition;
        pare = transform.root.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag =="hantei")
        {
            Hobj = col.gameObject;
            StartCoroutine("destroy");
        }if(col.gameObject.tag == "kabe")
        {
            Hobj = col.gameObject;
            StartCoroutine("destroy");
        }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}