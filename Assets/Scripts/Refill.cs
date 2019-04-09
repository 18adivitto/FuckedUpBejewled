using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refill : MonoBehaviour
{

    public static GameObject[] refillRow;
    public GameObject[] gemTypes;

    // Start is called before the first frame update
    void Start()
    {
        refillRow = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            refillRow[i] = gemTypes[Random.Range(0, gemTypes.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
