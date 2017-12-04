using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamreST : MonoBehaviour {
    private float Wspeed = 1f;
    private float Mspeed = 2f;
    private float Rspeed = 0.3f;

    private Vector3 preMousepos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MouseUpdate();
        return;
	}

    private void MouseUpdate()
    {
        float scW = Input.GetAxis("Mouse ScrollWheel");
        if (scW != 0.0f) MouseWheel(scW);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) preMousepos = Input.mousePosition;

        MouseDrug(Input.mousePosition);

    }
    private void MouseWheel(float dalta)
    {
        transform.position += transform.forward * dalta * Wspeed;
        return;
    }
    private void MouseDrug(Vector3 mousepos)
    {
        Vector3 diff = mousepos - preMousepos;
        if (diff.magnitude < Vector3.kEpsilon)
            return;

        if (Input.GetMouseButton(0)) transform.Translate(diff * Time.deltaTime * Mspeed);

    }
}
