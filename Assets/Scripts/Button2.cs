using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    public string[] targetTags = { "Radio1", "Radio2", "Radio3" };
    public Button uiButton;

    private bool isLookingAtTarget = false;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
        {
            foreach (string tag in targetTags)
            {
                if (hit.collider.CompareTag(tag))
                {
                    if (!isLookingAtTarget)
                    {
                        isLookingAtTarget = true;
                        uiButton.gameObject.SetActive(true);
                    }
                    return;
                }
            }
            if (isLookingAtTarget)
            {
                isLookingAtTarget = false;
                uiButton.gameObject.SetActive(false);
            }
        }
        else
        {
            if (isLookingAtTarget)
            {
                isLookingAtTarget = false;
                uiButton.gameObject.SetActive(false);
            }
        }
    }
}