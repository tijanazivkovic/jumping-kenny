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

    [SerializeField, Range(1f, 50f)] private float force = 5f;
    private CharacterController controller;
    private float horizontal;
    private float vertical;
    private bool disoriented;

    private UI ui;

    private void Start() {
        controller = GetComponent<CharacterController>();
        ui = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UI>();
    }

    public void Disorient(bool d)
    {
        disoriented = d;
    }

    public bool IsDisoriented()
    {
        return disoriented;
    }

    private void Awake()
    {
        Disorient(false);
    }

    private void Update()
    {
        if (!ui.GamePaused())
        {
            GetInput();
            if (!disoriented)
            {
                RotateCharacter();
            } else {
                ContraRotateCharacter();
            }
        }
        
    }

    private void GetInput()
    {

        if ( (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HumanoidMidAir") || 
            (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("HumanoidJumpUp")) )  && 
            Input.GetButton("Walk") ){
            if (!disoriented) {
                rigidbody.AddForce(player.transform.up * 0.5f * force, ForceMode.Force);
                rigidbody.AddForce(player.transform.forward * force, ForceMode.Force);
            } 
            
        }

        if (Input.GetButtonDown("Walk")) {
            player.GetComponent<Animator>().SetBool("Walk", true);
            player.GetComponent<Animator>().Play("HumanoidRun");
        }

        if (Input.GetButtonUp("Walk")) {
            player.GetComponent<Animator>().SetBool("Walk", false);
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

    private void ContraRotateCharacter()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            float distx = hit.point.x - transform.position.x;
            float x = hit.point.x - 2 * distx;
            float distz = hit.point.z - transform.position.z;
            float z = hit.point.z - 2 * distz;
            transform.LookAt(new Vector3(x, transform.position.y, z));
        }
    }
}
