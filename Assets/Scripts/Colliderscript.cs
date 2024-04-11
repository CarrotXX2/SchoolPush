using UnityEngine;

public class StopOnRaycast : MonoBehaviour
{
    public float stopDistance = 0.1f; // Distance at which movement stops
    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
    }

    void Update()
    {
        // Create a ray from the center of the screen
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit; // Variable to store information about the raycast hit

        // Check if the raycast hits any collider
        if (Physics.Raycast(ray, out hit))
        {
            // Calculate the distance between this object and the hit point
            float distance = Vector3.Distance(transform.position, hit.point);

            // If the distance is less than or equal to the stop distance, stop movement
            if (distance <= stopDistance)
            {
                rb.velocity = Vector3.zero; // Stop movement by setting velocity to zero
            }
        }
    }
}
