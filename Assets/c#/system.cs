using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class system : MonoBehaviour {
    private const int peaceline = 7;
    private const int peacecol = 7;
    private const float peaceW = 300f;
    private const float peaceH = 280f;
    private const float FpeaceX = -900f;
    private const float FpeaceY = -1120f;

    public GameObject holdObj;
    public GameObject UholdObj;
    public GameObject DholdObj;
    public GameObject LholdObj;
    public GameObject RholdObj;
    public float holdPosX;
    public float holdPosY;
    public float UholdPosX;
    public float UholdPosY;
    public float DholdPosX;
    public float DholdPosY;
    public float RholdPosX;
    public float RholdPosY;
    public float LholdPosX;
    public float LholdPosY;
    private float z = 10f;

    private int HobjN;
    private int HUobjN;
    private int HDobjN;
    private int HRobjN;
    private int HLobjN;
    private int SpeaX;
    private int SpeaY;


    private GameObject[,] peaceS;
    private int[,] objN;


    private bool ugoku = false;
    private bool ugoita=false;
    private string Vhoukou;

    public GameObject peace;
    public GameObject score;

	// Use this for initialization
	void Start () {
        SpeaceS();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            leftClick();            
        }
        if (Input.GetMouseButton(0))
        {
            leftDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            leftUP();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene("storyT");
        }
        
        Debug.Log(ugoita);
    }
    private void leftClick()
    {
        Vector3 tapPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        Vector3 CtapPoint = Camera.main.ScreenToWorldPoint(tapPoint);
        if(holdObj == null)
        {
            int SpeaX = Mathf.FloorToInt((Camera.main.ScreenToWorldPoint(tapPoint).x + 1100f)/300f);
            int SpeaY = Mathf.FloorToInt((Camera.main.ScreenToWorldPoint(tapPoint).y + 1212.5f)/280f);
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(tapPoint));
            Collider2D[] set = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z)));
            Collider2D colU = Physics2D.OverlapPoint(new Vector2(CtapPoint.x, CtapPoint.y + 280f));
            Collider2D colD = Physics2D.OverlapPoint(new Vector2(CtapPoint.x, CtapPoint.y - 280f));
            Collider2D colR = Physics2D.OverlapPoint(new Vector2(CtapPoint.x + 300f, CtapPoint.y));
            Collider2D colL = Physics2D.OverlapPoint(new Vector2(CtapPoint.x - 300f, CtapPoint.y));

            if (set.Length == 1)
            {

                if (col != null)
                {
                    this.holdObj = col.gameObject;
                    holdPosX = this.holdObj.transform.position.x;
                    holdPosY = this.holdObj.transform.position.y;
                    //Debug.Log(objN[SpeaY, SpeaX]);
                    //Debug.Log(SpeaX + "," + SpeaY);
                    HobjN = objN[SpeaY, SpeaX];

                }
                if (colU != null)
                {
                    this.UholdObj = colU.gameObject;
                    UholdPosX = this.UholdObj.transform.position.x;
                    UholdPosY = this.UholdObj.transform.position.y;
                    //Debug.Log(objN[SpeaY + 1, SpeaX]);
                    //Debug.Log(SpeaX + "," + (SpeaY+1));
                    HUobjN = objN[SpeaY +1 , SpeaX];
                }

                if (colD != null)
                {
                    this.DholdObj = colD.gameObject;
                    DholdPosX = this.DholdObj.transform.position.x;
                    DholdPosY = this.DholdObj.transform.position.y;
                   // Debug.Log(objN[SpeaY - 1, SpeaX]);
                   // Debug.Log(SpeaX + "," + (SpeaY-1));
                    HDobjN = objN[SpeaY - 1, SpeaX];
                }
                if (colR != null)
                {
                    this.RholdObj = colR.gameObject;
                    RholdPosX = this.RholdObj.transform.position.x;
                    RholdPosY = this.RholdObj.transform.position.y;
                    //Debug.Log(objN[SpeaY, SpeaX + 1]);
                    //Debug.Log((SpeaX+1) + "," + SpeaY);
                    HRobjN = objN[SpeaY, SpeaX+1];
                }
                if (colL != null)
                {
                    this.LholdObj = colL.gameObject;
                    LholdPosX = this.LholdObj.transform.position.x;
                    LholdPosY = this.LholdObj.transform.position.y;
                    //Debug.Log(objN[SpeaY, SpeaX - 1]);
                    //Debug.Log((SpeaX-1) + "," + SpeaY);
                    HLobjN = objN[SpeaY, SpeaX - 1];
                }
                
            }
            if (set.Length > 1)
            {
                leftUP();
              //  Debug.Log("error");
            }
            this.SpeaX = SpeaX;
            this.SpeaY = SpeaY;
        }
    }
    private void leftDrag()
    {
        Vector3 tapPoint = Input.mousePosition;
        if (holdObj != null)
        {
            Vector3 mouseP = Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z));
            int flick= idou(mouseP);
            //this.holdObj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z));
            //this.holdObj.transform.position = (new Vector3(Mathf.Clamp(holdObj.transform.position.x, sgPosX +0.2f, sgPosX + 1), Mathf.Clamp(holdObj.transform.position.y, sgPosY - 1, sgPosY + 1), z));
            
            Collider2D[] colSet = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(new Vector3(tapPoint.x, tapPoint.y, z)));
            //Debug.Log(HobjN+","+flick+","+ugoku);
            this.ugoku = hantei(HobjN,flick);
            if (colSet.Length > 1)
            {
                foreach(Collider2D col in colSet)
                {
                    if (!col.gameObject.Equals(this.holdObj))
                    {
                        if (this.ugoku == true)
                        {
                            float tmpPosX = holdPosX;
                            float tmpPosY = holdPosY;
                            holdPosX = col.gameObject.transform.position.x;
                            holdPosY = col.gameObject.transform.position.y;
                            //col.gameObject.transform.position = new Vector3(10, 10, z);
                            Destroy(col.gameObject);
                            
                            this.ugoku = false;
                            this.ugoita = true;

                        }
                        if(this.ugoku == false)
                        {                           
                            leftUP();
                            
                        }
                    }
                    
                }
            }
        }
    }
    private void leftUP()
    {
        if (holdObj != null)
        {
           holdObj.transform.position = new Vector3(holdPosX, holdPosY, z);
            holdObj = null;
            UholdObj = null;
            DholdObj = null;
            RholdObj = null;
            LholdObj = null;
            if (this.ugoita == true)
            {
                kaunto();                
                switch (this.Vhoukou)
                {
                    case "up":
                        peaceS[SpeaY + 1, SpeaX] = null;
                        for (int i = 1; i <= this.SpeaY; i++)
                        {
                            peaceS[SpeaY - i , SpeaX].transform.position += new Vector3(0, 280f, 0);
                        }
                        
                        GameObject up = Instantiate(peace) as GameObject;
                        up.transform.position = new Vector3(-900f+(300f*SpeaX), -1120f, z);
                        this.ugoita = false;
                        Debug.Log("a");
                        
                        break;
                    case "down":
                        peaceS[SpeaY - 1, SpeaX] = null;
                        for (int i = 1; i <=6 - this.SpeaY; i++)
                        {
                            peaceS[SpeaY + i, SpeaX].transform.position += new Vector3(0, -280f, 0);
                        }
                       
                        GameObject down = Instantiate(peace) as GameObject;
                        down.transform.position = new Vector3(-900f + (300f * SpeaX), 560f, z);
                        this.ugoita = false;
                        Debug.Log("a");
                        break;

                    case "right":
                        peaceS[SpeaY , SpeaX+1] = null;
                        for (int i = 1; i <= this.SpeaX; i++)
                        {
                            peaceS[SpeaY  , SpeaX-i].transform.position += new Vector3(300f,0, 0);
                        }
                        
                        GameObject right = Instantiate(peace) as GameObject;
                        right.transform.position = new Vector3(-900f, -1120f + (280f * SpeaY), z);
                        this.ugoita = false;
                        Debug.Log("a");
                        
                        break;
                    case "left":
                        peaceS[SpeaY, SpeaX - 1] = null;
                        for (int i = 1; i <= 6-this.SpeaX; i++)
                        {
                            peaceS[SpeaY, SpeaX + i].transform.position += new Vector3(-300f, 0, 0);
                        }

                        GameObject left = Instantiate(peace) as GameObject;
                        left.transform.position = new Vector3(900f, -1120f + (280f * SpeaY), z);
                        this.ugoita = false;
                       
                        break;
                }     
                          
            }
            else
            {
                SpeaceS();                
            }

        }
    }

    private void SpeaceS()
    {
        GameObject[,] peaceS = new GameObject[peaceline, peacecol];
        
        for (int i = 0; i < peaceline; i++)
        {
            for(int j = 0; j < peacecol; j++)
            {
                Collider2D col = Physics2D.OverlapPoint(new Vector2(FpeaceX + peaceW * j, FpeaceY + peaceH * i));
                if ("peace".Equals(col.tag))
                {
                    peaceS[i, j] = col.gameObject;
                }                
            }
        }
        this.peaceS = peaceS;
        Invoke("hensu", 0.1f);
        Debug.Log("Set");
    }
    private void hensu()
    {
        int[,] objN = new int[peaceline, peacecol];
        for(int i = 0; i < peaceline; i++)
        {
            for (int j = 0; j < peacecol; j++)
            {
                peace SCpeace = this.peaceS[i, j].GetComponent<peace>();
                objN[i, j] = SCpeace.GetSpr();
            } 
        }
        this.objN = objN;
        Debug.Log("10");
    }
    private int idou(Vector3 mouseP)
    {
        float directionX=mouseP.x-holdPosX;
        float directionY=mouseP.y-holdPosY;
        float seigyo = 30;
        
        int objN  = 12;
        string Vhoko = "NULL";

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (seigyo < directionX)
            {
                //右向きにフリック
                objN = HRobjN;
                Vhoko = "right";
            }
            else if (-seigyo > directionX)
            {
                //左向きにフリック
                objN = HLobjN;
                Vhoko = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (seigyo < directionY)
            {
                //上向きにフリック
                objN = HUobjN;
                Vhoko = "up";
            }
            else if (-seigyo > directionY)
            {
                //下向きにフリック
                objN = HDobjN;
                Vhoko = "down";
            }
        }
        else
        {
            //タッチを検出
            objN = 12;
        }
        this.Vhoukou = Vhoko;
        return objN;
    }
   private bool hantei(int cenN,int aroN)
    {
        bool ugoku=true;
        switch (cenN)
        {
            case 0:
                if (aroN >= 8 && aroN <= 11 )
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }                               
                break;
            case 1:
                if (aroN >= 8 && aroN <= 11||(aroN==6))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 2:
                if (aroN >= 7 && aroN <= 11)
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 3:
                if (aroN >= 8 && aroN <= 11||(aroN==5))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 4:
                if (aroN >= 0 && aroN <= 3 )
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 5:
                if (aroN >= 0 && aroN <= 3||(aroN==10))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 6:
                if (aroN >= 0 && aroN <= 3 || (aroN == 11))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 7:
                if (aroN >= 0 && aroN <= 3 || (aroN == 9))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 8:
                if (aroN >= 4 && aroN <= 7)
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 9:
                if (aroN >= 4 && aroN <= 7 || (aroN == 2))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 10:
                if (aroN >= 4 && aroN <= 7 || (aroN == 3))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
            case 11:
                if (aroN >= 4 && aroN <= 7 || (aroN == 1))
                {
                    ugoku = true;
                }
                else
                {
                    ugoku = false;
                }
                break;
        }
        return ugoku;
    }
   
   private void kaunto()
    {
        kaunto score = this.score.GetComponent<kaunto>();
        score.pointP();
    }
   
}
