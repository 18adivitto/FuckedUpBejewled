using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBlink : MonoBehaviour
{
    MeshRenderer SR;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<MeshRenderer>();
        StartCoroutine("Blinker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Blinker()
    {
        yield return new WaitForSeconds(1f);
        SR.enabled = !SR.enabled;
        StartCoroutine("Blinker");
    }
}
