using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Transform[] movePoints;
    private int n;

    void Start() {
        n = movePoints.Length;
    }

    void MoveToRandomPoint() {
        if(n > 0) {
            int i = Random.Range(0, n);
            Debug.Log("I: " + i);
            navMeshAgent.SetDestination(movePoints[i].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(!navMeshAgent.hasPath) { 
           this.GetComponent<Animation>().Play("walk");
           MoveToRandomPoint();
       }
       if (navMeshAgent.isStopped) {
        this.GetComponent<Animation>().Play("idle");
       }
    }
}
