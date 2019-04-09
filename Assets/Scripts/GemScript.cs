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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Xpos = Mathf.RoundToInt(transform.position.x);
        Ypos = Mathf.RoundToInt(transform.position.y);



        //Debug.Log(BoolHub.isRefreshing);
        if (!BoolHub.playingAnimation)
        {
            StartCoroutine("ClearGrid");
        }


    }

    IEnumerator ClearGrid()
    {
        //Debug.Log("refreshWorks");
        yield return new WaitForSeconds(.0f);
        BoolHub.isRefreshing = true;
        Destroy(this.gameObject);

    }
}
