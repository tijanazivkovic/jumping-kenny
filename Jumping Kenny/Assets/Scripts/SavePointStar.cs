using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointStar : MonoBehaviour
{
    [SerializeField] private Transform point;
    private void OnTriggerEnter(Collider other) {
        if (other != null)
        {
            
            Player kenny = other.gameObject.GetComponent<Player>();
            if (kenny != null)
            {
                SavePointsController spc = GameObject.FindGameObjectWithTag("SPC").GetComponent<SavePointsController>();
                if (spc != null)
                {
                    if (point != null)
                    {
                        spc.SetLastSavedPoint(point);
                        Destroy(gameObject);
                        Debug.Log("Last saved point: " + spc.GetLastSavedPoint());
                    }
                }
            }
        
        } 
    }
}
