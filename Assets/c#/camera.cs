using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    void Awake()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        float bAspect = 4f / 3f;
        float nAspect = (float)Screen.height / (float)Screen.width;
        float cAspect;

        if (bAspect > nAspect)
        {
            cAspect = nAspect / bAspect;
            cam.rect = new Rect((1 - cAspect) * 0.5f, 0, cAspect, 1);
        }
        else
        {
            cAspect = bAspect / nAspect;
            cam.rect = new Rect(0, (1 - cAspect) * 0.5f, 1, cAspect);
        }
        Destroy(this);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
