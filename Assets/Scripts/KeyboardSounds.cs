using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardSounds : MonoBehaviour
{
    public AudioClip[] clicks;
    AudioSource audioPP;
    // Start is called before the first frame update
    void Start()
    {
        audioPP = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            audioPP.PlayOneShot(clicks[Random.Range(0,1)]);
        }
    }
}
