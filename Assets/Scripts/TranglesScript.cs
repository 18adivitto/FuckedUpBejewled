using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranglesScript : MonoBehaviour
{
    public GameObject Ytri;
    public GameObject Xtri;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Xtri, new Vector3(2, -1), Quaternion.identity);
        Instantiate(Ytri, new Vector3(-1, 3), Quaternion.Euler(0,0,-90));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
