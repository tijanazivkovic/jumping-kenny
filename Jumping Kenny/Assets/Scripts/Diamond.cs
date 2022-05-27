using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other != null)
        {
            
            Player kenny = other.gameObject.GetComponent<Player>();
            if (kenny != null)
            {
                Destroy(gameObject); 
                kenny.AddPoints(5);
                Debug.Log("Points: " + kenny.GetPoints());
            }
        
        } 
    }
}
