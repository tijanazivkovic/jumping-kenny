using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlatform : MonoBehaviour
{
    public bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            EnableTouched();
        }
    }

    public void EnableTouched() {
        touched = true;
    }

    public void RestartTouched() {
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
