using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float vert;
    public float hor;
    public Vector3 movedir;
    public float speed;
    public float sprintSpeedMultiplier = 2f;
    public float crouchSpeedMultiplier = 0.5f; // Added crouch speed multiplier
    private bool isSprinting = false;
    private bool isCrouching = false; // Added crouching flag

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        vert = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            transform.localScale = new Vector3(1, 0.10f, 1); 
        }
        else
        {
            isCrouching = false;
            transform.localScale = new Vector3(1, 1, 1);
        }

        movedir.z = vert;
        movedir.x = hor;

        float currentSpeed = speed;

        if (isSprinting)
        {
            currentSpeed *= sprintSpeedMultiplier;
        }
        else if (isCrouching)
        {
            currentSpeed *= crouchSpeedMultiplier; 
        }

        transform.Translate(movedir * Time.deltaTime * currentSpeed);
    }
}