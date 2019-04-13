using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndGame : MonoBehaviour
{
    SpriteRenderer whiteScreen;
    TextMeshPro text;
    float opacity;
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "RestartText")
        {
            text = GetComponent<TextMeshPro>();
            text.color = new Color(0,0,0,0);
            text.enabled = true;
        }
        else
        {
            whiteScreen = GetComponent<SpriteRenderer>();
            whiteScreen.color = new Color(1, 1, 1, 0);
            whiteScreen.enabled = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BoolHub.gameOver)
        {
            opacity = Mathf.Lerp(opacity, 1, Time.deltaTime * 7);
        }
        else
        {
            opacity = 0;
        }
        if (this.gameObject.name == "RestartText")
        {
            text.color = new Color(0,0,0,opacity);
        }
        else
        {
            whiteScreen.color = new Color(1, 1, 1, opacity);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
