using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    [Range(1,100)]
    private float fireRateSec = 1f;

    [SerializeField]
    [Range(0,1000)]
    private float bulletSpeed = 1f;
    [SerializeField]
    private GameObject bulletPrefab;

    private float timeElapsedSinceFire = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedSinceFire += Time.deltaTime;

        if((timeElapsedSinceFire >= 1/fireRateSec) && Input.GetKey(KeyCode.Space))
        {
            GameObject gb = Instantiate(this.bulletPrefab, this.transform.position, Quaternion.identity);
            gb.GetComponent<Rigidbody2D>().AddForce(this.transform.up * bulletSpeed);
            timeElapsedSinceFire = 0;
            GetComponent<AudioSource>().Play();

            //Temporaire
            Destroy(gb,8f);
        }
        
    }
}
