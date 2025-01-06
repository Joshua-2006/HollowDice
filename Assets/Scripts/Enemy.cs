using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Movement target;
    private Rigidbody rb;
    public float speed = 10f;
    public float stoppingDistance = 2f;
    public float hp = 3;
    public bool hit;
    public float force = 1000;
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
        
    }
    private void FixedUpdate()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > stoppingDistance)
        {
            Vector3 movement = direction * speed;
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, speed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword"))
        {
            StartCoroutine(Wait());
            if(hit)
            {
                hp -= 1;
                rb.AddForce(target.transform.forward * force, ForceMode.Impulse);
            }
        }
        if(hp <=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Wait());
            if(hit)
            {
                target.hp -= 1;
                rb.AddForce(target.transform.forward * force, ForceMode.Impulse);
            }
        }
    }
    IEnumerator Wait()
    {
        hit = true;
        yield return new WaitForSeconds(0.01f);
        hit = false;
    }
}
