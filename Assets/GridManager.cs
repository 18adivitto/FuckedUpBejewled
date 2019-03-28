using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{

    public static int[,] _gemGrid;

    int _gemtype;

    public GameObject _gem;
    public GameObject _gem1;
    public GameObject _gem2;
    public GameObject _gem3;
    public GameObject _gem4;

    public GameObject playerGO;
    // Start is called before the first frame update
    void Start()
    {
        _gemGrid = new int[7, 5]
        {
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
            { 0,0,0,0,0},
        };

        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                _gemtype = (Random.Range(0, 5));
                _gemGrid[i, ii] = _gemtype;

                if (i == 3 && ii == 2) //spawns player
                {
                    
                    _gemtype = 7;
                }

                if (_gemtype == 0)
                {
                    Instantiate(_gem, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemtype == 1)
                {
                    Instantiate(_gem1, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemtype == 2)
                {
                    Instantiate(_gem2, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemtype == 3)
                {
                    Instantiate(_gem3, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemtype == 4)
                {
                    Instantiate(_gem4, new Vector3(ii, i), Quaternion.identity);
                }

                if (_gemtype == 7)
                {
                    Instantiate(playerGO, new Vector3(ii, i), Quaternion.identity);
                }
            }
        }


    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GridTest");
        }

        if (BoolHub.isRefreshing)
        {
            RefreshGrid();
        }

        ThreeInARow();
    }

    void ThreeInARow()
    {
        if (_gemGrid[6,1] == 2)
        {
            Debug.Log("6,1 is red" + Time.deltaTime);
        }
    }

    void RefreshGrid()
    {






        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                if (_gemGrid[i,ii] == 0)
                {
                    Instantiate(_gem, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemGrid[i,ii] == 1)
                {
                    Instantiate(_gem1, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemGrid[i,ii] == 2)
                {
                    Instantiate(_gem2, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemGrid[i,ii] == 3)
                {
                    Instantiate(_gem3, new Vector3(ii, i), Quaternion.identity);
                }
                if (_gemGrid[i,ii] == 4)
                {
                    Instantiate(_gem4, new Vector3(ii, i), Quaternion.identity);
                }

            }
        }
        BoolHub.isRefreshing = false;
    }
}
