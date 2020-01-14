using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMovement : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Movement());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Movement()
    {
        while(Application.isPlaying)
        {
            this.transform.position = new Vector2(Random.Range(-5,5),Random.Range(-5,5));
            this.audioSource.volume = Random.Range(0f,1f);
            yield return new WaitForSeconds(Random.Range(0.5f,3f));
        }
    }
}
