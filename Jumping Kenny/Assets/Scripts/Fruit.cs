using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other) {
        if (other != null)
        {
            
            Player kenny = other.gameObject.GetComponent<Player>();
            if (kenny != null)
            {
                Destroy(gameObject); 
                kenny.GetHealthier(1);
                Debug.Log("Health: " + kenny.GetHealth());
            }
        
        } 
    }
}
