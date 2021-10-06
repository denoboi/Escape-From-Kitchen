using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private float sensitivity;
    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation;
    private bool isRotating;
    [SerializeField]
    float speed;

    void Start()
    {
        sensitivity = 0.4f;
        rotation = Vector3.zero;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetMouseButtonDown(0))
        {
            // rotating flag
            isRotating = true;

            // store mouse
            mouseReference = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // rotating flag
            isRotating = false;
        }


        if (isRotating)
        {
            // offset
            mouseOffset = (Input.mousePosition - mouseReference);

            // apply rotation
            rotation.y = (mouseOffset.x + mouseOffset.y) * sensitivity;

            // rotate
            transform.Rotate(rotation);

            // store mouse
            mouseReference = Input.mousePosition;
        }
    }

}
