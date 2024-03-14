using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowUI : MonoBehaviour
{
    public Camera mainCamera;
    public Button button;
    public float raycastDistance = 1f;
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    private bool radio1Interacted = false;
    private bool radio2Interacted = false;
    private bool radio3Interacted = false;

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
            if (hit.collider.CompareTag("Radio1") && !radio1Interacted)
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio1Interacted = true;
                    if (dialogue != null)
                    {
                        dialogue.StartDialogue();
                    }
                    hit.collider.enabled = false; // Schakel de collider van Radio1 uit
                }
            }
            else if (hit.collider.CompareTag("Radio2") && !radio2Interacted)
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio2Interacted = true;
                    if (dialogue2 != null)
                    {
                        dialogue2.StartDialogue();
                    }
                    hit.collider.enabled = false; // Schakel de collider van Radio2 uit
                }
            }
            else if (hit.collider.CompareTag("Radio3") && !radio3Interacted)
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio3Interacted = true;
                    if (dialogue3 != null)
                    {
                        dialogue3.StartDialogue();
                    }
                    hit.collider.enabled = false; // Schakel de collider van Radio3 uit
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