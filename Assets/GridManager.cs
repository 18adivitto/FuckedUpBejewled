using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    //*****VERY IMPORTANT**** if you walk into groups of two, then it gets rid of them becuase the player script duplicates the value in the array, then the grid manager sets the spot to empty
    // since it occurs in this order, for a frame or two in the array, there is an extra duplicated value, which makes a group of three! 

    public static int[,] _gemGrid;

    int _gemtype;

    public GameObject _gem;
    public GameObject _gem1;
    public GameObject _gem2;
    public GameObject _gem3;
    public GameObject _gem4;
    public GameObject emptySpace;

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

                NoRowsInitialize(); // makes sure that upon initial generation there are no pre constructed rows
            }
        }

        
        
    }

    

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("GridTest");
        }

        
            NoRows();
       
            

        if (BoolHub.isRefreshing)
        {
            RefreshGrid();
        }

       
    }

    void NoRows() //now it sets it to an empty space, but since it just changes it to the same value, it becomes recursive
    {
        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                // Columns/x values: if there is a matching block to either side of you
                if (ii < 4 && ii > 0)
                {
                    if (((_gemGrid[i, ii] == _gemGrid[i, ii + 1]) && (_gemGrid[i, ii] == _gemGrid[i, ii - 1]))&&_gemGrid[i,ii] != 5)
                    {
                        
                        _gemGrid[i, ii] = 5;
                        _gemGrid[i, ii+1] = 5;
                        _gemGrid[i, ii-1] = 5;
                        BoolHub.isRefreshing = true;
                    }
                }
                
                //Rows/y values: if there is a matching block above or below you
                if (i < 6 && i > 0)
                {
                    if (((_gemGrid[i, ii] == _gemGrid[i+1, ii]) && (_gemGrid[i, ii] == _gemGrid[i - 1, ii]))&& _gemGrid[i, ii] != 5)
                    {
                        
                        _gemGrid[i, ii] = 5;
                        _gemGrid[i+1, ii] = 5;
                        _gemGrid[i - 1, ii] = 5; 
                        BoolHub.isRefreshing = true;
                    }
                }
                
                
            }
        }

    }

    void NoRowsInitialize() //just forthe start loop
    {
        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                // Columns/x values: if there is a matching block to either side of you
                if (ii < 4 && ii > 0)
                {
                    if (((_gemGrid[i, ii] == _gemGrid[i, ii + 1]) && (_gemGrid[i, ii] == _gemGrid[i, ii - 1])))
                    {
                        
                        _gemGrid[i, ii] = Random.Range(0,5);
                        _gemGrid[i, ii+1] = Random.Range(0, 5);
                        _gemGrid[i, ii-1] = Random.Range(0, 5);
                        BoolHub.isRefreshing = true;
                    }
                }
                
                //Rows/y values: if there is a matching block above or below you
                if (i < 6 && i > 0)
                {
                    if (((_gemGrid[i, ii] == _gemGrid[i+1, ii]) && (_gemGrid[i, ii] == _gemGrid[i - 1, ii])))
                    {
                        
                        _gemGrid[i, ii] = Random.Range(0, 5);
                        _gemGrid[i+1, ii] = Random.Range(0, 5);
                        _gemGrid[i - 1, ii] = Random.Range(0, 5);
                        BoolHub.isRefreshing = true;
                    }
                }
                
                
            }
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
                if (_gemGrid[i, ii] == 5)
                {
                    Instantiate(emptySpace, new Vector3(ii, i), Quaternion.identity);
                }

            }
        }
       BoolHub.isRefreshing = false;
    }
}
