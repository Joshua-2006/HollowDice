using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    public float speed;
    public float rotationSpeed;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(transform.forward * vertical * speed);
        rb.AddForce(transform.right * horizontal * speed);
        rb.velocity *= rb.drag;

        float rotates = Input.GetAxis("Rotate");
        float rotato = Input.GetAxis("Rotate 2");
        transform.Rotate(0, -rotates * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(0, rotato * rotationSpeed * Time.deltaTime, 0);

    }
}
