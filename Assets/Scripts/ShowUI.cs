using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowUI : MonoBehaviour
{
    public Camera mainCamera;
    public Button button;
    public float raycastDistance = 3f;
    public Dialogue dialogue;
    public Dialogue dialogue2;

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
            if (hit.collider.CompareTag("Radio1"))
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (dialogue != null)
                    {
                        dialogue.StartDialogue();
                    }
                }
            }
            else if (hit.collider.CompareTag("Radio2"))
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (dialogue2 != null)
                    {
                        dialogue2.StartDialogue();
                    }
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