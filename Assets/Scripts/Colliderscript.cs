using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    public float stopDistance = 0.1f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Calculate distance between this object and the collider
        float distance = Vector3.Distance(transform.position, other.transform.position);

        // If the collider is within the stop distance, stop movement
        if (distance <= stopDistance)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
