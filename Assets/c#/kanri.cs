using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanri : MonoBehaviour {
    private Vector3 touchStP;
    private Vector3 touchEnP;
    string Direction;
    bool ninshiki = false;
    public GameObject peace = null;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Flick();
        
        Debug.Log(Direction);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             int layerMask = 1<<8;
            float maxDistance = 10;

            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);


            if (hit.collider)
            {
                Debug.Log(hit.collider.gameObject.name);
               
                peace = hit.collider.gameObject;
                peace.transform.parent = transform;
                
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ninshiki = true;
            
        }


        switch (Direction)
        {
            case "up":
               if( ninshiki == true)
                {
                    
                    ninshiki = false;
                    peace.transform.parent = null;
                    
                }
                Direction = "touch";
                break;
            case "down":
                if (ninshiki == true)
                {
                   
                    ninshiki = false;
                    peace.transform.parent = null;
                }
                Direction = "touch";
                break;
            case "left":
                if (ninshiki == true)
                {
                   
                    ninshiki = false;
                    peace.transform.parent = null;
                }
                Direction = "touch";
                break;
            case "right":
                if (ninshiki == true)
                {
                   
                    ninshiki = false;
                    peace.transform.parent = null;
                }
                Direction = "touch";
                break;
            case "touch":
                ninshiki = false;
                peace.transform.parent = null;
                
                break;

        }

    }
   
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEnP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GetDirection();

        }
    }
    void GetDirection()
    {
        float seigyo = 30;
        float directionX = touchEnP.x - touchStP.x;
        float directionY = touchEnP.y - touchStP.y;
        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (seigyo < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-seigyo > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (seigyo < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-seigyo > directionY)
            {
                //下向きにフリック
                Direction = "down";
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
        }
    }

    
}
