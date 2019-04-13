using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{

    int Xpos;
    int Ypos;

    GameObject tempOBJ;
    public GameObject emptySpace;

    Animator anim;

    bool movingDown = false;

    bool movingtest = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Xpos = Mathf.RoundToInt(transform.position.x);
        Ypos = Mathf.RoundToInt(transform.position.y);

        //if (Xpos == 4 && Ypos == 6)
        //{
        //    movingtest = true;
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        Xpos = Mathf.RoundToInt(transform.position.x);
        Ypos = Mathf.RoundToInt(transform.position.y);

        

        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        //{
            StartCoroutine("ClearGrid");
        
        
        //if (movingtest && !BoolHub.isRefreshing)
        //{
        //    transform.position += new Vector3(1,0) * Time.deltaTime;
        //    Debug.Log("geez");
        //}

       

    }

    IEnumerator ClearGrid()
    {
        //Debug.Log("refreshWorks");
        yield return new WaitForSeconds(.0f);
        BoolHub.isRefreshing = true;
        Destroy(this.gameObject);

    }
}
