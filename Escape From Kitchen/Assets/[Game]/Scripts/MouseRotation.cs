using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Rigidbody rb;

    public float rotationAmount;
    bool isDragging;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDrag()
    {
        isDragging = true;
    }
    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector3(0, 0, 1f) * speed, ForceMode.Impulse) ; 
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (Input.GetMouseButtonUp(0))
        {
            //transform.Rotate(Vector3.forward * rotationAmount * Time.deltaTime);
            isDragging = false;
            Debug.Log("Slided Left");
        }

    }  
        void FixedUpdate()
        {
            if (isDragging)
            {
                float x = Input.GetAxis("Mouse X") * rotationAmount * Time.fixedDeltaTime;
                float y = Input.GetAxis("Mouse Y") * rotationAmount * Time.fixedDeltaTime;
                rb.AddTorque(Vector3.left * x);
                rb.AddTorque(Vector3.right * y);
            }  
        }  
}