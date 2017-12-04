using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
    SpriteRenderer spre;
    float touka;
    float seigen = 1f;
    Animator anim;
    private bool scenel = false;
    void chantrans(float a)
    {
        this.spre.color = new Color(1, 1, 1, a);
    }
   
    // Use this for initialization
    void Start () {
        this.spre = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetFloat("move", 0);
    }
	
	// Update is called once per frame
	void Update () {
        touka += Time.deltaTime/4;
        if(touka < 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                touka += 1;
            }
        }
        if (touka >= 1)
        {
            touka = 1;
            
            anim.SetFloat("move", 1);
            scenel = true;
        }
        if (scenel == true && Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene("pazzle");
        }
        chantrans(touka);
	}
}
