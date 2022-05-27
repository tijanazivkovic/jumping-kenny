using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Player player = other.gameObject.GetComponentInChildren<Player>();
        if (player != null) {
            Debug.Log("Found Player");
            player.TakeDamage(1);
        }
    }
}
