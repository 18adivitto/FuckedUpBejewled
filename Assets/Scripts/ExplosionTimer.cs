using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    public AudioClip explosion;
    AudioSource audioPP;
    // Start is called before the first frame update
    void Start()
    {
        audioPP = Camera.main.GetComponent<AudioSource>();
        StartCoroutine("DeathTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(this.gameObject);
    }
}
