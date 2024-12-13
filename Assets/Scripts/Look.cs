using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private Movement target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<Movement>();
        Quaternion.LookRotation(target.transform.forward);
    }
}
