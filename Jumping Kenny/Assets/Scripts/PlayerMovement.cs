using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Camera cam;
    [SerializeField, Range(1f, 5f)] private float speed = 5f;

    private float horizontal;
    private float vertical;

    private void Update()
    {
        GetInput();
        RotateCharacter();      
    }

    private void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Walk")) {
            player.GetComponent<Animator>().Play("HumanoidWalk");
        }

        if (Input.GetButtonUp("Walk")) {
            player.GetComponent<Animator>().Play("HumanoidIdle");
        }

        if (Input.GetButtonDown("Jump")) {
            player.GetComponent<Animator>().Play("HumanoidJumpUp");
        }
    }

    private void RotateCharacter()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
