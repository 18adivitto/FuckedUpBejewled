using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridRefresher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RefreshLoop");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(BoolHub.isRefreshing);
    }

    IEnumerator RefreshLoop()
    {
        
        BoolHub.isRefreshing = true;
        yield return new WaitForSeconds(.5f);
        BoolHub.isRefreshing = false;
        yield return new WaitForSeconds(.5f);
        StartCoroutine("RefreshLoop");
    }
}
