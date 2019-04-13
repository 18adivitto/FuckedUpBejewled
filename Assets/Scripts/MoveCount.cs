using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveCount : MonoBehaviour
{
    TextMeshPro text;
    public static int moves = 10;

    // Start is called before the first frame update
    void Start()
    {
        moves = 10;
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = moves.ToString();

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            moves -= 1;
        }

        if (moves < 0)
        {
            moves = 0;
        }

        if (moves == 0)
        {
            BoolHub.gameOver = true;
        }
    }
}
