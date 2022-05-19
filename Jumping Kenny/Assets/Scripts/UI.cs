using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text points;
    public Player player;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    [SerializeField] private Image healthBar;

    public Image GameOverBoard;
    public Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        points.text = player.GetPoints().ToString();
        float amount = player.GetHealth()/player.GetMaxHealth();
        SetHealthBar(amount);
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
            GameOverBoard.enabled = true;
            GameOverText.enabled = true;
        }
    }

    public void SetHealthBar(float amount){
        healthBar.fillAmount = amount;
    }
}
