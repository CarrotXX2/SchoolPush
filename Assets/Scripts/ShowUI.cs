using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    public Camera mainCamera;
    public Button button;
    public float raycastDistance = 3f;

    void Start()
    {
        button.gameObject.SetActive(false); 
    }

    void ShowButton()
    {
        button.gameObject.SetActive(true); 
    }

    void HideButton()
    {
        button.gameObject.SetActive(false); 
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Interactable"))
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    HideButton();
                }
            }
            else
            {
                HideButton();
            }
        }
        else
        {
            HideButton();
        }
    }
}