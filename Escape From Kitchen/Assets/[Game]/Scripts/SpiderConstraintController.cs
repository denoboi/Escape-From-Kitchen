using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderConstraintController : MonoBehaviour
{
    Vector3 originalPosition;
    void Start()
    {
        originalPosition = transform.position;
    }

    
    void Update()
    {
        transform.position = originalPosition;
    }
}
