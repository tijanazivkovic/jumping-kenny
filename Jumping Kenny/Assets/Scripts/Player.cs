using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Damageable
{
    private int health;
    private int lives;
    private const int MAX_LIVES = 3;
    private const int MAX_HEALTH = 5;
    private int points;

    public void AddPoints(int pts)
    {
        points += pts;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            lives --;
            if (lives == 0)
            {
                Die(); // GAME OVER
                return;
            }
            health = MAX_HEALTH;
        }
    }

    public void LoseLife()
    {
        lives--;
        if (lives == 0)
        {
            Die(); // GAME OVER
        }
    }

    public void AddLife()
    {
        lives++;
        if (lives > MAX_LIVES)
        {
            lives = MAX_LIVES;
        }
    }

    public void GetHealthier(int h)
    {
        health += h;
        if (health > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }
    }

    public int GetPoints()
    {
        return points;
    }

    public int GetHealth()
    {
        return health;
    }

    private void Awake()
    {
        points = 0;
        lives = MAX_LIVES;
        health = MAX_HEALTH-3;
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
