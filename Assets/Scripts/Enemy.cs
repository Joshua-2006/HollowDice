using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Movement target;
    private Rigidbody rb;
    public float speed = 10f;
    public float stoppingDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Movement>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > stoppingDistance)
        {
            Vector3 movement = direction * speed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // Maintain vertical velocity
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0); // Stop horizontal movement
        }

    }
}
