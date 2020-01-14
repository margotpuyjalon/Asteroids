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
            GameObject.Find("GameManager").GetComponent<GameManager>().DamageShip();
            Destroy(gameObject);
            //this.BulletCollision(collision.contacts[0]);
            //Destroy(collision.gameObject);
            Destroy(GameObject.Find("GhostSpaceship(Clone)"));
        }
        else //if(collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.tag == "Bullet")
                GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(1);

            this.BulletCollision(collision.contacts[0]);
            //Debug.Log("YO");
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
            GameObject gb1 = Instantiate(this.gameObject , contact.point + new Vector2(Random.Range(-1,1),Random.Range(-1,1)), Quaternion.identity);
            GameObject gb2 = Instantiate(this.gameObject, contact.point + new Vector2(Random.Range(-1,1),Random.Range(-1,1)), Quaternion.identity);
            
            gb1.transform.localScale = 0.5f * this.transform.localScale;
            gb2.transform.localScale = 0.5f * this.transform.localScale;
            
           
            //Vector2 dir = contact.point - (Vector2) this.transform.position ;
            //gb1.GetComponent<Asteroids>().direction =  Quaternion.Euler(0,0,90) * dir;
            gb1.GetComponent<Asteroids>().direction = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
            gb1.GetComponent<Asteroids>().enabled = true;
            gb1.GetComponent<Asteroids>().Launch();
            gb1.GetComponent<CapsuleCollider2D>().enabled = true;
            //gb2.GetComponent<Asteroids>().direction = Quaternion.Euler(0,0, - 90) * dir;
            gb2.GetComponent<Asteroids>().direction = new Vector2(Random.Range(-1,1),Random.Range(-1,1));
            gb2.GetComponent<Asteroids>().enabled = true;
            gb2.GetComponent<Asteroids>().Launch();
            gb2.GetComponent<CapsuleCollider2D>().enabled = true;
            Destroy(this.gameObject);
        }
    }
}
