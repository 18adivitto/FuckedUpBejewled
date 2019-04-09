using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int Xpos;
    int Ypos;
    
    GameObject tempGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Xpos = Mathf.RoundToInt(transform.position.x);
        Ypos = Mathf.RoundToInt(transform.position.y);

        if (Input.GetKeyDown(KeyCode.S) && !(Input.GetKeyDown(KeyCode.A) ||Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.D)))
        {
            tempGameObject = GridManager.gemGrid[Ypos - 1,Xpos];
            GridManager.gemGrid[Ypos - 1, Xpos] = this.gameObject;
            //BoolHub.isRefreshing = true;
            GridManager.gemGrid[Ypos, Xpos] = tempGameObject;
            transform.position += new Vector3(0,-1,0);
        }
        if (Input.GetKeyDown(KeyCode.W) && !(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            tempGameObject = GridManager.gemGrid[Ypos + 1,Xpos];
            GridManager.gemGrid[Ypos + 1, Xpos] = this.gameObject;
            GridManager.gemGrid[Ypos, Xpos] = tempGameObject;
            transform.position += new Vector3(0,1,0);
        }
        if (Input.GetKeyDown(KeyCode.A) && !(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D)))
        {
            tempGameObject = GridManager.gemGrid[Ypos, Xpos - 1];
            GridManager.gemGrid[Ypos, Xpos - 1] = this.gameObject;
            GridManager.gemGrid[Ypos, Xpos] = tempGameObject;
            transform.position += new Vector3(-1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.D) && !(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)))
        {
            tempGameObject = GridManager.gemGrid[Ypos, Xpos + 1];
            GridManager.gemGrid[Ypos, Xpos + 1] = this.gameObject;
            GridManager.gemGrid[Ypos, Xpos] = tempGameObject;
            transform.position += new Vector3(1,0,0);
        }
        


    }
}
