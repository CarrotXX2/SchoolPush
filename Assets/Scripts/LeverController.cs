using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public Animator leverAnimator;

    void Update()
    {
        // Check for input to pull the lever (example: "E" key)
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Trigger the lever animation
            leverAnimator.SetTrigger("PullLever");
        }
    }
}
