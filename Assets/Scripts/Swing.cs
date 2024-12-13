using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Transform transforms;
    public Transform transforms2;
    public Rigidbody rb;
    private Movement target;
    public float speed = 5;
    public bool swing;
    public float swingSpeed = 5f; // Speed of the swing
    public float swingAngle = 90f; // Maximum angle of the swing
    public KeyCode swingKey = KeyCode.Space; // Key to swing the sword

    private bool isSwinging = false;
    private float currentSwing = 0f;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Movement>();
        swing = true;
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<Movement>();
        Quaternion.LookRotation(target.transform.forward);
        transform.position = transforms.position;
            // Start the swing when the swingKey is pressed
            if (Input.GetButton("Swing") && !isSwinging)
            {
                isSwinging = true;
                currentSwing = 0f;
            }

            // Perform the swing
            if (isSwinging)
            {
                float swingStep = swingSpeed * Time.deltaTime;
                currentSwing += swingStep;

                if (currentSwing <= swingAngle)
                {
                    transform.Rotate(Vector3.right, swingStep); // Adjust axis for your sword setup
                }
                else
                {
                    isSwinging = false; // End the swing
                    transform.localRotation = Quaternion.identity; // Reset rotation
                }
            }
    }
    private void FixedUpdate()
    {
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
