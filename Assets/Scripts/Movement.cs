using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    public float speed;
    public float rotationSpeed;
    public Rigidbody rb;
    [SerializeField] private GameObject enemy;
    public float hp;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        if(hit)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hit = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hit = false;
        }
    }

}
