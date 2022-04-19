using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;

    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    private float horizontal;
    private float vertical;

    private void Update()
    {
        if (Input.GetButtonDown("Walk")) {
            player.GetComponent<Animator>().Play("HumanoidWalk");
        }

        if (Input.GetButtonUp("Walk")) {
            player.GetComponent<Animator>().Play("HumanoidIdle");

        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 changeInPosition = new Vector3(horizontal, 0f, vertical);

        transform.Translate(changeInPosition * Time.deltaTime * speed);
    }
}
