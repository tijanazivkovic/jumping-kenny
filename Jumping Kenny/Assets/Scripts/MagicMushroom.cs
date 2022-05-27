using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroom : MonoBehaviour
{
    private bool disorientationSet;

    private void Start()
    {
        disorientationSet = false;
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null)
        {
            PlayerMovement kenny = other.gameObject.GetComponentInChildren<PlayerMovement>();
            if (kenny != null)
            {
                if (!kenny.IsDisoriented())
                {
                    // Debug.Log("hihihi");
                    kenny.Disorient(true);
                    disorientationSet = true;
                    StartCoroutine(Timer());
                }        
            }
        
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds (10f);

        // after 10 seconds disorientation stops
        PlayerMovement kenny = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>();
        if (disorientationSet)
        {
            kenny.Disorient(false);
            disorientationSet = false;
        }

    }
}
