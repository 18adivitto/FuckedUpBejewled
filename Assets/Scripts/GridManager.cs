using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject gem0;
    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;
    public GameObject gem5;
    public GameObject PlayerGO;
    public GameObject emptySpace;

    public GameObject[] gemTypes;

    GameObject tempGem;

    public static GameObject[,] gemGrid;


    // Start is called before the first frame update
    void Start()
    {
        gemGrid = new GameObject[7, 5];

        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                if (i == 3 && ii == 2)
                {
                    gemGrid[i, ii] = PlayerGO;
                    Instantiate(PlayerGO, new Vector3(ii, i), Quaternion.identity);

                }
                else
                {
                    gemGrid[i, ii] = gemTypes[Random.Range(0, gemTypes.Length)];
                    Instantiate(gemGrid[i, ii], new Vector3(ii, i), Quaternion.identity);
                }
                
            }
        }

        NoRowsInitialize();

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
                    if (((gemGrid[i, ii].tag == gemGrid[i, ii + 1].tag) && (gemGrid[i, ii].tag == gemGrid[i, ii - 1].tag)))
                    {
                        gemGrid[i, ii] = gemTypes[Random.Range(0, gemTypes.Length)];
                        gemGrid[i, ii + 1] = gemTypes[Random.Range(0, gemTypes.Length)];
                        gemGrid[i, ii - 1] = gemTypes[Random.Range(0, gemTypes.Length)];

                        BoolHub.isRefreshing = true;
                    }
                }

                //Rows/y values: if there is a matching block above or below you
                if (i < 6 && i > 0)
                {
                    if (((gemGrid[i, ii].tag == gemGrid[i + 1, ii].tag) && (gemGrid[i, ii].tag == gemGrid[i - 1, ii].tag)))
                    {
                        gemGrid[i, ii] = gemTypes[Random.Range(0, gemTypes.Length)];
                        gemGrid[i + 1, ii] = gemTypes[Random.Range(0, gemTypes.Length)];
                        gemGrid[i - 1, ii] = gemTypes[Random.Range(0, gemTypes.Length)];
                        
                        BoolHub.isRefreshing = true;
                    }
                }


            }
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {

        NoRows();

        GridFall();

        RefreshRow();

        if (BoolHub.isRefreshing)
        {
            RefreshGrid();
        }
    }

    void NoRows()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                if (ii < 4 && ii > 0) // for the xvalues (ii)
                {
                    if ((gemGrid[i, ii].tag == gemGrid[i, ii + 1].tag) && (gemGrid[i, ii].tag == gemGrid[i, ii - 1].tag)&&(gemGrid[i, ii].tag != "VOID"))
                    {
                        //row 1
                        if (ii == 1)
                        {
                            if (gemGrid[i,ii].tag == gemGrid[i,ii + 2].tag)
                            {
                                gemGrid[i, ii + 2] = emptySpace;

                                if (gemGrid[i, ii].tag == gemGrid[i, ii + 3].tag)
                                {
                                    gemGrid[i, ii + 3] = emptySpace;
                                }
                            }
                            
                        }
                        //row 2
                        if (ii == 2)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i, ii + 2].tag)
                            {
                                gemGrid[i, ii + 2] = emptySpace;
                            }

                            if (gemGrid[i, ii].tag == gemGrid[i, ii - 2].tag)
                            {
                                gemGrid[i, ii - 2] = emptySpace;
                            }
                        }
                        //row 3
                        if (ii == 3)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i, ii - 2].tag)
                            {
                                gemGrid[i, ii - 2] = emptySpace;

                                if (gemGrid[i, ii].tag == gemGrid[i, ii - 3].tag)
                                {
                                    gemGrid[i, ii - 3] = emptySpace;
                                }
                            }
                        }

                        gemGrid[i, ii] = emptySpace;
                        gemGrid[i, ii + 1] = emptySpace;
                        gemGrid[i, ii - 1] = emptySpace;
                    }
                }
                if (i < 6 && i > 0) // for the Yvalues (i)
                {
                    //row 1
                    if ((gemGrid[i, ii].tag == gemGrid[i + 1, ii].tag) && (gemGrid[i, ii].tag == gemGrid[i - 1, ii].tag) & (gemGrid[i, ii].tag != "VOID"))
                    {

                        if (i == 1)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i + 2, ii].tag)
                            {
                                gemGrid[i + 2, ii] = emptySpace;
                                if (gemGrid[i, ii].tag == gemGrid[i + 3, ii].tag)
                                {
                                    gemGrid[i + 3, ii] = emptySpace;
                                    if (gemGrid[i, ii].tag == gemGrid[i + 4, ii].tag)
                                    {
                                        gemGrid[i + 4, ii] = emptySpace;
                                        if (gemGrid[i, ii].tag == gemGrid[i + 5, ii].tag)
                                        {
                                            gemGrid[i + 5, ii] = emptySpace;
                                        }
                                    }
                                    
                                }
                                
                            }
                            
                        }
                        //row 2
                        if (i == 2)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i + 2, ii].tag)
                            {
                                gemGrid[i + 2, ii] = emptySpace;
                                if (gemGrid[i, ii].tag == gemGrid[i + 3, ii].tag)
                                {
                                    gemGrid[i + 3, ii] = emptySpace;
                                    if (gemGrid[i, ii].tag == gemGrid[i + 4, ii].tag)
                                    {
                                        gemGrid[i + 4, ii] = emptySpace;
                                    }
                                }
                            }
                            
                            if (gemGrid[i, ii].tag == gemGrid[i - 2, ii].tag)
                            {
                                gemGrid[i - 2, ii] = emptySpace;
                            }

                        }
                        //row 3
                        if (i == 3)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i + 2, ii].tag)
                            {
                                gemGrid[i + 2, ii] = emptySpace;
                                if (gemGrid[i, ii].tag == gemGrid[i + 3, ii].tag)
                                {
                                    gemGrid[i + 3, ii] = emptySpace;
                                }
                            }
                            
                            if (gemGrid[i, ii].tag == gemGrid[i - 2, ii].tag)
                            {
                                gemGrid[i - 2, ii] = emptySpace;
                                if (gemGrid[i, ii].tag == gemGrid[i - 3, ii].tag)
                                {
                                    gemGrid[i - 3, ii] = emptySpace;
                                }
                            }
                            
                        }
                        //row 4
                        if (i == 4)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i + 2, ii].tag)
                            {
                                gemGrid[i + 2, ii] = emptySpace;
                            }
                            if (gemGrid[i, ii].tag == gemGrid[i - 2, ii].tag)
                            {
                                gemGrid[i - 2, ii] = emptySpace;
                                if (gemGrid[i, ii].tag == gemGrid[i - 3, ii].tag)
                                {
                                    gemGrid[i - 3, ii] = emptySpace;
                                    if (gemGrid[i, ii].tag == gemGrid[i - 4, ii].tag)
                                    {
                                        gemGrid[i - 4, ii] = emptySpace;
                                    }
                                }
                            }
                        }
                        //row 5
                        if (i == 5)
                        {
                            if (gemGrid[i, ii].tag == gemGrid[i - 2, ii].tag)
                            {
                                gemGrid[i - 2, ii] = emptySpace;
                                if (gemGrid[i, ii].tag == gemGrid[i - 3, ii].tag)
                                {
                                    gemGrid[i - 3, ii] = emptySpace;
                                    if (gemGrid[i, ii].tag == gemGrid[i - 4, ii].tag)
                                    {
                                        gemGrid[i - 4, ii] = emptySpace;
                                        if (gemGrid[i, ii].tag == gemGrid[i - 5, ii].tag)
                                        {
                                            gemGrid[i - 5, ii] = emptySpace;
                                        }
                                    }

                                }

                            }
                        }

                        gemGrid[i, ii] = emptySpace;
                        gemGrid[i + 1, ii] = emptySpace;
                        gemGrid[i - 1, ii] = emptySpace;
                    }
                }
            }
        }
    }

    void GridFall()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                if (i > 0)
                {
                    if (gemGrid[i - 1,ii].tag == "VOID" && gemGrid[i,ii].tag != "VOID" && gemGrid[i, ii].tag != "Player")
                    {

                        tempGem = gemGrid[i, ii];
                        gemGrid[i, ii] = gemGrid[i - 1, ii];
                        gemGrid[i - 1, ii] = tempGem;
                    }

                }
            }
        }
    }

    void RefreshRow()
    {
        for (int i = 0; i < 5; i++)
        {
            if (gemGrid[6,i].tag == "VOID")
            {
                gemGrid[6,i] = gemTypes[Random.Range(0, gemTypes.Length)];
            }
        }
    }

    void RefreshGrid()
    {

        for (int i = 0; i < 7; i++)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                if (gemGrid[i, ii].tag == "Player")
                {

                }
                else
                {
                    Instantiate(gemGrid[i, ii], new Vector3(ii, i), Quaternion.identity);
                }
                
            }
        }
        BoolHub.isRefreshing = false;
    }
}
