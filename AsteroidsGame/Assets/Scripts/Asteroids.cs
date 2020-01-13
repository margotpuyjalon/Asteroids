using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // Spawner variables
    public Vector2 direction;
    public float speed;

    
    void Update()
    {
        //transform.Translate(direction.normalized * speed);
    }

    public void Launch()

    {
        this.GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed * this.GetComponent<Rigidbody2D>().mass);
        Destroy(this.gameObject, 8f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // collision.GetComponent<Player>().health -= damage;
        // Debug.Log(collision.GetComponent<Player>().health);
        if(collision.gameObject.tag == "Player")
        {
            this.BulletCollision(collision.contacts[0]);
            Destroy(collision.gameObject);
        }
        else //if(collision.gameObject.tag == "Bullet")
        {
            
            this.BulletCollision(collision.contacts[0]);
            Debug.Log("YO");
            Destroy(collision.gameObject);
        }
    }

    private void BulletCollision(ContactPoint2D contact)
    {
        if(this.transform.localScale.x  < 0.33f)
        {
            Destroy(this.gameObject);

            
        }
        else
        {
            GameObject gb1 = Instantiate(this.gameObject, contact.point, Quaternion.identity);
            GameObject gb2 = Instantiate(this.gameObject, contact.point, Quaternion.identity);
            
            gb1.transform.localScale = 0.5f * this.transform.localScale;
            gb2.transform.localScale = 0.5f * this.transform.localScale;
            
           
            //Vector2 dir = contact.point - (Vector2) this.transform.position ;
            //gb1.GetComponent<Asteroids>().direction =  Quaternion.Euler(0,0,90) * dir;
            gb1.GetComponent<Asteroids>().direction = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
            gb1.GetComponent<Asteroids>().Launch();
            //gb2.GetComponent<Asteroids>().direction = Quaternion.Euler(0,0, - 90) * dir;
            gb2.GetComponent<Asteroids>().direction = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
            gb2.GetComponent<Asteroids>().Launch();
            Destroy(this.gameObject);
        }
    }
}
