using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMotion : MonoBehaviour
{
    public static Vector2 gapPosition;
    public GameObject gapTest;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            gapPosition = new Vector2(transform.position.x, transform.position.y);
            //Instantiate(gapTest, gapPosition, Quaternion.identity);
            //Debug.Log(gapPosition);
        }

        //so, depending on the direction you move... set one of the directional values to the point 

        /* //for spawwing a block to the left of the player
         * GridManager._gemGrid[gapPosition.y, gapPsoition.x] =  GridManager._gemGrid[Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.x) - 1];
         * BoolHub.isrefreshing = true;
         * 
         */


        if (Input.GetKeyDown(KeyCode.A))
        {
            //for spawwing a block to the left of the player
            GridManager._gemGrid[Mathf.RoundToInt(gapPosition.y), Mathf.RoundToInt(gapPosition.x)] = GridManager._gemGrid[Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.x) - 1];
            BoolHub.isRefreshing = true;
            transform.position += new Vector3(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //right
            GridManager._gemGrid[Mathf.RoundToInt(gapPosition.y), Mathf.RoundToInt(gapPosition.x)] = GridManager._gemGrid[Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.x) + 1];
            BoolHub.isRefreshing = true;
            transform.position += new Vector3(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //up
            GridManager._gemGrid[Mathf.RoundToInt(gapPosition.y), Mathf.RoundToInt(gapPosition.x)] = GridManager._gemGrid[Mathf.RoundToInt(transform.position.y)+1, Mathf.RoundToInt(transform.position.x)];
            BoolHub.isRefreshing = true;
            transform.position += new Vector3(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //down
            GridManager._gemGrid[Mathf.RoundToInt(gapPosition.y), Mathf.RoundToInt(gapPosition.x)] = GridManager._gemGrid[Mathf.RoundToInt(transform.position.y)-1, Mathf.RoundToInt(transform.position.x)];
            BoolHub.isRefreshing = true;
            transform.position += new Vector3(0, -1);
        }

        //Debug.Log(GridManager._gemGrid[Mathf.RoundToInt(transform.position.y) + 1, Mathf.RoundToInt(transform.position.x)]); //writes the vlaue of the block above
        //Debug.Log(GridManager._gemGrid[Mathf.RoundToInt(transform.position.y) - 1, Mathf.RoundToInt(transform.position.x)]); //writes the vlaue of the block below
        //Debug.Log(GridManager._gemGrid[Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.x) + 1]); //writes the vlaue of the block to the right
        //Debug.Log(GridManager._gemGrid[Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.x) - 1]); //writes the vlaue of the block to the left



        //Debug.Log((GridManager._gemGrid[4,2])); 
    }

}
