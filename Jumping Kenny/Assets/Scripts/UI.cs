using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text points;
    public Player player;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public GameObject gameOverMenu;

    public Text scorePointsGameOver;

    [SerializeField] private Image healthBar;
    [SerializeField] private Color healthBarColor;
    
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject help;
    [SerializeField] private GameObject pauseMenu;
    private bool gamePaused = false;
    private bool gameInProgress = false;

    public void SetGameInProgress(bool p)
    {
        gameInProgress = p;
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
        DisableHelp();
        DisablePauseMenu();
        DisableGameOverMenu();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = player.GetPoints().ToString();
        float amount = player.GetHealth()/player.GetMaxHealth();
        Color color = healthBarColor;
        if (amount <= 0.5) {
            color = Color.yellow;
        }
        if (amount <= 0.3) {
            color = Color.red;
        }
        SetHealthBar(amount, color);
        if (player.GetLives() == 3) {
            heart1.enabled = true;
            heart2.enabled = true;
            heart3.enabled = true;
        }

        if (player.GetLives() == 2) {
            heart1.enabled = false;
            heart2.enabled = true;
            heart3.enabled = true;
        } 

        if (player.GetLives() == 1) {
            heart2.enabled = false;
            heart3.enabled = true;
        }

        if (player.GetLives() == 0) {
            heart3.enabled = false;
            scorePointsGameOver.text = player.GetPoints().ToString();
            EnableGameOverMenu();
            SetGameInProgress(false);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameInProgress)
            {
                PauseGame();
                EnablePauseMenu();
            }
        }

    }

    public void SetHealthBar(float amount, Color color){
        healthBar.fillAmount = amount;
        healthBar.color = color;
    }

    public void PauseGame()
    {
    	Time.timeScale = 0;
        gamePaused = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }

    public bool GamePaused()
    {
        return gamePaused;
    }

    public void DisableMainMenu() 
    {
        mainMenu.SetActive(false);
    }

    public void EnableMainMenu() 
    {
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {   
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void DisableHelp() 
    {
        help.SetActive(false);
    }

    public void EnableHelp() 
    {
        help.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void DisablePauseMenu() 
    {
        pauseMenu.SetActive(false);
    }

    public void EnablePauseMenu() 
    {
        pauseMenu.SetActive(true);
    }

    public void DisableGameOverMenu() 
    {
        gameOverMenu.SetActive(false);
    }

    public void EnableGameOverMenu() 
    {
        gameOverMenu.SetActive(true);
    }

    public void PlayAgain()
    {
        RestartScene();
    }
}
