using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float lastFrameFingerPostionX;
    private float moveFactorX;
    public float MoveFactorX { get { return moveFactorX; } }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPostionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPostionX;
            lastFrameFingerPostionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0;
        }
    }
}