using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class proog : MonoBehaviour {
    public string[] scenarios;
    [SerializeField] Text uiText;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float IntervalFCD = 0.05f;

    private int currL = 0;
    private string currT = string.Empty;
    private float TuniD = 0;
    private float TE = 1;
    private int lasrUp = -1;
    float matu = 0;
    public bool IsCompleteDisplayText
    {
        get { return Time.time > TE + TuniD; }
    }

	// Use this for initialization
	void Start () {
        TextUpdate();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsCompleteDisplayText)
        {
            if (currL < scenarios.Length && Input.GetMouseButtonDown(0))
            {
                TextUpdate();
            }
        }
        else {
            if (Input.GetMouseButtonDown(0))
            {
                TuniD=0;
            }
        }
        int DChCo = (int)(Mathf.Clamp01((Time.time - TE) / TuniD) * currT.Length);
        if (DChCo != lasrUp)
        {
            uiText.text = currT.Substring(0, DChCo);
            lasrUp = DChCo;
        }
        if(currL  == scenarios.Length)
        {
            matu += Time.deltaTime;
            if(matu>0.1f && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("pazzle");
            }

        }
	}
    void TextUpdate()
    {
        currT = scenarios[currL];
        currL ++;

        TuniD = currT.Length * IntervalFCD;
        TE = Time.time;

        lasrUp = -1;
    }
}
