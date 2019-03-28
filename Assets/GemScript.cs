using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{

    int thisColor;
    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            
            StartCoroutine("ClearGrid");
        }
    }


    IEnumerator ClearGrid()
    {
        Debug.Log("refreshWorks");
        yield return new WaitForSeconds(.1f);
        Destroy(this.gameObject);
        
    }
}
