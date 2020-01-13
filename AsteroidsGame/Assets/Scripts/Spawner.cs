using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Border positions
    // A CHANGER SELON LA DEFINITION FINALE DE L'ESPACE DE JEU
    public float xLeft = -10;
    public float xRight = 10;
    public float yUp = 6.5f;
    public float yDown = -6.5f;
    // Notre objet asteroide
    public GameObject asteroidObject;
    // Variable pour determiner la vitesse d'apparition
    public float spawnTime;
    private float timeBtwSpawn;

    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            SpawnAsteroid();
            // la variable TimeBtwSpawn est rechargee
            timeBtwSpawn = spawnTime;
        }
        else timeBtwSpawn -= Time.deltaTime;
    }

    void SpawnAsteroid()
    {
        // On initialise les valeurs de l'asteroide
        Vector3 pos = new Vector3(0,0,0);
        Vector2 dir = new Vector2(0, 0);

        float rnd = Random.Range(0f, 3f);
        float rnd2 = Random.Range(-1f, 1f);

        // On choisit les valeurs de l'asteroide en fonction de la position du spawner
        switch (Mathf.Round(rnd))
        {
            case 0 :
                pos.x = xLeft;
                pos.y = Random.Range(yDown, yUp);
                dir = new Vector2(1, rnd2);
                break;
            case 1:
                pos.x = xRight;
                pos.y = Random.Range(yDown, yUp);
                dir = new Vector2(-1, rnd2);
                break;
            case 2:
                pos.y = yUp;
                pos.x = Random.Range(xLeft, xRight);
                dir = new Vector2(rnd2, -1);
                break;
            case 3:
                pos.y = yDown;
                pos.x = Random.Range(xLeft, xRight);
                dir = new Vector2(rnd2, 1);
                break;
        }

        // On cree notre asteroide avec les valeurs choisies
        Asteroids asteroidTemp = Instantiate(asteroidObject, pos, Quaternion.identity).GetComponent<Asteroids>();
        asteroidTemp.direction = dir;
        asteroidTemp.Launch();
    }
}
