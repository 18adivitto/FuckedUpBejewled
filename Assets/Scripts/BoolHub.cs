using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoolHub : MonoBehaviour
{

    public static bool isRefreshing = false;

    public static int Score;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GridScene");
            
        }
    }

}
