using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    /* Game state */
    enum GameState
    {
        Death,
        InitMenu,
        Menu,
        InitGame,
        Game
    }

    public GameObject spaceship = null;
    public GameObject spawner = null;

    private GameState gameState;

    /* Canvas */
    private GameObject canvasMenu;
    private GameObject canvasGame;

    /* Label */
    private GameObject labelScore;
    private GameObject labelTime;
    private GameObject labelHealth;

    /* Data variables */
    int score = 0;
    int time = 0;
    int health = 3;

    float fullTime = 0f;

    void Awake()
    {
        canvasMenu = GameObject.Find("Canvas_Menu");
        if (canvasMenu == null)
            Debug.LogError("Canvas_Menu does not exist");

        canvasGame = GameObject.Find("Canvas_Game");
        if (canvasGame == null)
            Debug.LogError("Canvas_Game does not exist");

        labelScore = GameObject.Find("Label_Score");
        if (labelScore == null)
            Debug.LogError("Label_Score does not exist");

        labelTime = GameObject.Find("Label_Time");
        if (labelTime == null)
            Debug.LogError("Label_Time does not exist");

        labelHealth = GameObject.Find("Label_Health");
        if (labelHealth == null)
            Debug.LogError("Label_Health does not exist");

        gameState = GameState.InitMenu;
    }
    
    void FixedUpdate()
    {
        switch (gameState)
        {
            case GameState.Death:
                Death();
                break;

            case GameState.InitMenu:
                InitMenu();
                break;

            case GameState.InitGame:
                InitGame();
                break;

            case GameState.Menu:
                Menu();
                break;

            case GameState.Game:
                Game();
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.InitMenu;

        if (health <= 0 && health > -999)
        {
            health = -1000;
            gameState = GameState.Death;
        }
    }

    /* Answer to click on "Play" button */
    public void Play()
    {
        gameState = GameState.InitGame;
    }

    /* Answer to click on "Quit" button */
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    /* Freeze the game for a few seconds until reset */
    void Death()
    {
        fullTime += Time.deltaTime;

        spaceship.SetActive(false);
        spawner.SetActive(false);

        if (fullTime > 5f)
            gameState = GameState.InitMenu;
    }

    public void DamageShip()
    {
        health--;
    }

    /* Initialize the Menu */
    void InitMenu()
    {
        canvasMenu.SetActive(true);
        canvasGame.SetActive(false);

        spaceship.SetActive(false);
        spawner.SetActive(false);

        Debug.Log("InitMenu");

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Asteroid"))
            Destroy(go);

        gameState = GameState.Menu;
    }

    /* Initialize the Game */
    void InitGame()
    {
        canvasMenu.SetActive(false);
        canvasGame.SetActive(true);

        score = 0;
        time = 0;
        health = 3;

        fullTime = 0f;

        spaceship.SetActive(true);
        spawner.SetActive(true);

        Debug.Log("InitGame");

        gameState = GameState.Game;
    }

    /* Menu loop */
    void Menu()
    {

    } //empty

    /* Game loop */
    void Game()
    {
        fullTime += Time.deltaTime;

        if (fullTime >= 1f)
        {
            time++;
            fullTime--;
        }

        labelScore.GetComponent<Text>().text = "Score : " + score;
        labelTime.GetComponent<Text>().text = "Time : " + time;
        labelHealth.GetComponent<Text>().text = "Health : " + health;
    }
}
