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
        Debug.Log(transform.position);
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
        if (delayBtwSprites == 0)
        {
            // We have to find and destroy the previous spaceship sprite
            Destroy(GameObject.Find("GhostSpaceship(Clone)"));
            Instantiate(ghostSpaceship, transform.position, transform.rotation);
            delayBtwSprites = maxDelayBtwSprites;
        }
    }

    public void SetmaxDelayBtwSprites(Slider slider)
    {
        Debug.Log(slider.value);
        maxDelayBtwSprites = (int)slider.value;
        spriteText.text = "Delay btw sprites : " + (int)slider.value;
    }
}
