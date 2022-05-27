using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDiamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other != null)
        {
            
            Player kenny = other.gameObject.GetComponent<Player>();
            if (kenny != null)
            {
                Destroy(gameObject); 
                kenny.AddLife();
                Debug.Log("Lives: " + kenny.GetLives());
            }
        
        } 
    }
}
