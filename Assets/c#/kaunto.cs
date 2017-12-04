using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kaunto : MonoBehaviour {
    private const int peaceline = 5;
    private const int peacecol = 5;
    private const float peaceW = 300f;
    private const float peaceH = 280f;
    private const float FpeaceX = -600f;
    private const float FpeaceY = -840f;

    private GameObject[,] peaceS;
    private int[,] objN;


    public Text scoreT;
    public Text timeT;
    public static int point = 0;
    public static float time = 0;
    public static float Retime = 0;
    public static int[] peaceNum = new int[12];
    public static bool[] story = new bool[12];
    // Use this for initialization
    public static bool ziseki(int num)
    {
        switch (num)
        {
            case 0:
                if (time < 1)
                {
                    return false;
                    break;
                }
                else
                {
                    return true;
                    break;
                }
                break;
            case 1:
                if (time < 1)
                {
                    return false;
                    break;
                }
                else
                {
                    return true;
                    break;
                }
        }
       
        return true;
    }
    void Start () {
        SpeaceS();
        hensu();
    }
	
	// Update is called once per frame
	void Update () {
        SpeaceS();
        hensu();
        lapse();
        scoreT.text = "Score:" + point.ToString();
        

    }
    private void SpeaceS()
    {
        GameObject[,] peaceS = new GameObject[peaceline, peacecol];

        for (int i = 0; i < peaceline; i++)
        {
            for (int j = 0; j < peacecol; j++)
            {
                Collider2D col = Physics2D.OverlapPoint(new Vector2(FpeaceX + peaceW * j, FpeaceY + peaceH * i));
                if ("peace".Equals(col.tag))
                {
                    peaceS[i, j] = col.gameObject;
                    
                }
            }
        }
        this.peaceS = peaceS;
    }
    private void hensu()
    {
        int[,] objN = new int[peaceline, peacecol];
        for (int i = 0; i < peaceline; i++)
        {
            for (int j = 0; j < peacecol; j++)
            {
                peace SCpeace = this.peaceS[i, j].GetComponent<peace>();
                objN[i, j] = SCpeace.GetSpr();
            }
        }
        
        this.objN = objN;
    }
    public void pointP()
    {
        point += 10;
    }

    public int LeIn (int a)
    {
        int lenI=0;
        for (int i = 0; i < peaceline; i++)
        {
            for (int j = 0; j < peacecol; j++)
            {
                if (this.objN[i, j] == a)
                {
                    lenI++;
                }
            }
        }
                return lenI;
    }
    private void lapse()
    {
        time += Time.deltaTime;
        Retime += Time.deltaTime; 
        int deb = (int)Retime % 60;
        int nen = (int)(time / 20) + 1;

        if (Input.GetMouseButtonDown(0))
        {
            Retime = 0;
        }
        timeT.text = nen+ "年目";
        
    }
   
    
}
