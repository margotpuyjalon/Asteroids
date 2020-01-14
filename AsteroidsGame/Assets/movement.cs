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

    public Object ghostSpaceship;
    private Object spawnedGhost;
    private float maxDelayBtwSprites;
    private float delayBtwSprites = 0;

    public Text spriteText;

    private void Start()
    {
        maxDelayBtwSprites = PerceptiveParameters.lagPlayer;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {

        }

        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        if (Input.GetAxis("Vertical") > 0 && accelerating)
        {
            currentSpeed += (speed * accelerationRate * Time.deltaTime);
            decreasing = true;
        }
        else if (Input.GetAxis("Vertical") == 0 && decreasing)
        {
            currentSpeed -= (speed * decreaseRate * Time.deltaTime);
            accelerating = true;
        }
        
        if(Input.GetAxis("Vertical") > 0)
        {
            direction = transform.rotation.eulerAngles;
        }

            if (currentSpeed > speed)
        {
            accelerating = false;
            currentSpeed = speed;
        }

        if(currentSpeed < 0)
        {
            decreasing = false;
            currentSpeed = 0;
            accelerating = true;
        }

        float translation = currentSpeed;
        float rotation =  Input.GetAxis("Horizontal") * rotationSpeed;


        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.Translate(0, translation, 0);
        // Rotate around our y-axis
        transform.Rotate(0, 0, -rotation);


        Vector2 scaledPos = camera.WorldToScreenPoint(transform.position);
        if (scaledPos.x > Screen.width || scaledPos.x < 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y,transform.position.z);
        }
        else if(scaledPos.y > Screen.height || scaledPos.y < 0)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, transform.position.z);
        }
        //if(framecount > 40)
        //{
        //    framecount = 0;
        //    Debug.Log(currentSpeed);
        //}
        //framecount++;

        if (delayBtwSprites > 0) delayBtwSprites--;
        if (delayBtwSprites <= 0) SpawnGhost();
    }

    void SpawnGhost()
    {
        // We have to find and destroy the previous spaceship sprite
        if(spawnedGhost) Destroy(spawnedGhost);
        spawnedGhost = Instantiate(ghostSpaceship, transform.position, transform.rotation);
        delayBtwSprites = maxDelayBtwSprites;
    }
}
