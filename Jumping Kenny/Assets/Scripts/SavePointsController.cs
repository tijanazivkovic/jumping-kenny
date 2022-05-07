using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointsController : MonoBehaviour
{
    // [SerializeField] private List<Transform> savePoints = new List<Transform>();
    [SerializeField] private Transform lastSavedPoint;

    public void SetLastSavedPoint(Transform t)
    {
        lastSavedPoint = t;
    }

    public Transform GetLastSavedPoint()
    {
        return lastSavedPoint;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
