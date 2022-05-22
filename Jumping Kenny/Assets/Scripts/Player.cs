using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Damageable
{
    private int health;
    private int lives;
    private const int MAX_LIVES = 3;
    private const int MAX_HEALTH = 10;
    private int points;
    private int jump_counter;

    public int GetJumpCounter() {
        Debug.Log("Jump counter: " + jump_counter);
        return jump_counter;
    }

    public void SetJumpCounter(int x) {
        jump_counter = x;
        Debug.Log("Jump counter: " + jump_counter);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Platform")
        {
            jump_counter = 0;
            Debug.Log("Jump counter: " + jump_counter);
        }
    }

    public float GetMaxHealth(){
        return MAX_HEALTH;
    }

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

    public int GetLives()
    {
        return lives;
    }

    private void Awake()
    {
        points = 0;
        lives = MAX_LIVES;
        health = MAX_HEALTH;
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.transform.position.y <= 0)
        {
            LoseLife();
            Debug.Log("Lives: " + lives);
            SavePointsController spc = GameObject.FindGameObjectWithTag("SPC").GetComponent<SavePointsController>();
            if (spc != null)
            {
                if (gameObject != null)
                {
                    gameObject.transform.position = spc.GetLastSavedPoint().position;
                }
            }
        }
    }
}
