using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 200.0f;
    public new Camera camera;
    public float accelerationRate = 5.0f;
    public float decreaseRate = 5.0f;


    private float currentSpeed = 0f;
    private bool accelerating = true;
    private bool decreasing = false;
    private Vector3 direction;

    public GameObject ghostSpaceship;
    private GameObject spawnedGhost;
    public int maxDelayBtwSprites = 10;
    private int delayBtwSprites = 0;

    private Rigidbody2D myrigidBody;

    public Text spriteText;

    private void Start()
    {
        myrigidBody = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            myrigidBody.AddForce(this.transform.up * speed);
        }

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);
        Vector2 scaledPos = camera.WorldToScreenPoint(transform.position);
        if (scaledPos.x > Screen.width || scaledPos.x < 0)
        {
            int dir;
            if (transform.position.x > 0) dir = 1;
            else dir = -1;
            transform.position = new Vector3(-(transform.position.x - dir * 0.5f), transform.position.y, transform.position.z);
        }
        else if (scaledPos.y > Screen.height || scaledPos.y < 0)
        {
            int dir;
            if (transform.position.y > 0) dir = 1;
            else dir = -1;
            transform.position = new Vector3(transform.position.x, -(transform.position.y - dir * 0.5f), transform.position.z);
        }
        if (delayBtwSprites > 0) delayBtwSprites--;
        SpawnGhostSpaceship();
    }

    void SpawnGhostSpaceship()
    {
        // We have to find and destroy the previous spaceship sprite
        if(spawnedGhost == null) 
        {
            
            spawnedGhost = Instantiate(ghostSpaceship, transform.position, transform.rotation);

            SpriteRenderer sprite = spawnedGhost.GetComponent<SpriteRenderer>();
            switch(PerceptiveParameters.shipColor)
            {
                case ShipColor.BACKGROUND : 
                    sprite.color = new Color(0.03137255f,0.0627451f,0.1176471f,1f);
                break;

                case ShipColor.ASTEROID : 
                    sprite.color = new Color(0.5960785f,0.4901961f,0.4509804f,1f);
                break;

                default :
                    sprite.color = new Color(1f,1f,1f,1f);
                break;
            }
        }
        else
        {
            spawnedGhost.transform.position = this.transform.position;
            spawnedGhost.transform.rotation = this.transform.rotation;
        }

        delayBtwSprites = maxDelayBtwSprites;
    }

    public void Reset()
    {
        Destroy(spawnedGhost);
        spawnedGhost = null;
    }
    public void SetmaxDelayBtwSprites(Slider slider)
    {
        maxDelayBtwSprites = (int)slider.value;
        spriteText.text = "Delay btw sprites : " + (int)slider.value;
    }
}
