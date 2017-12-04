using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sakusei_first : MonoBehaviour {
    public GameObject[] peace;
    public GameObject hantei;

    
    // Use this for initialization

    void Start () {
        int i;
        int f;
        int preS = 0;
        for (i = -3; i < 5; i++) {
            for (f = -3; f < 4; f++)
            {
                preS = Random.Range(0, 11);
                GameObject go = Instantiate(peace[preS]) as GameObject;
                go.transform.position = new Vector3(0f+(1.2f* i)+-0.6f, 0f+(1.2f * f), 0);
                GameObject han = Instantiate(hantei) as GameObject;
                han.transform.position = new Vector3(0f + (1.2f * i) + -0.6f, 0f + (1.2f * f), 0);
            }
        }

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
