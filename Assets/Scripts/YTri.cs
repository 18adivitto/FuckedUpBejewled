using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTri : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player(Clone)").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-1, player.position.y);
    }
}
