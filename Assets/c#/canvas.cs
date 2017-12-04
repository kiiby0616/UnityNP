using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas : MonoBehaviour {
    static Canvas _canvas;
	// Use this for initialization
	void Start () {
        _canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void SetInteractive(string name, bool osu)
    {
        foreach(Transform child in _canvas.transform)
        {
            if(child.name == name)
            {
                Button btn = child.GetComponent<Button>();
                btn.interactable = osu;
                return;
            }
        }
    }
}
