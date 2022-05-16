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

        if (player.GetLives() == 2) {
            heart1.enabled = false;
        } 

        if (player.GetLives() == 1) {
            heart2.enabled = false;
        }

        if (player.GetLives() == 0) {
            heart3.enabled = false;
            GameOverBoard.enabled = true;
            GameOverText.enabled = true;
        }
    }
}
