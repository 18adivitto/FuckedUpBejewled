using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreeb : MonoBehaviour
{
    public GameObject Logo;
    public AudioClip bleep;
    AudioSource audioPP;

    // Start is called before the first frame update
    void Start()
    {
        Logo.SetActive(false);
        audioPP = Camera.main.GetComponent<AudioSource>();
        StartCoroutine("startUp");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startUp()
    {
        yield return new WaitForSeconds(1);
        Logo.SetActive(true);
        audioPP.PlayOneShot(bleep);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GridScene");

    }
}
