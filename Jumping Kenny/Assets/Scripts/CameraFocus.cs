using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private float camDist;
    private Vector3 camVec;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        camDist = Vector3.Distance(player.transform.position, transform.position);
        print(camDist);
        camVec = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + camVec.normalized * camDist;
    }
}
