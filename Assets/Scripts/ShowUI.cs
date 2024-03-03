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
                    // Controleer of het dialoogscript is toegewezen
                    if (dialogue != null)
                    {
                        // Start het dialoogscript
                        dialogue.StartDialogue();
                    }
                }
            }
            else if (hit.collider.CompareTag("Radio2"))
            {
                ShowButton();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Controleer of het dialoogscript is toegewezen
                    if (dialogue2 != null)
                    {
                        // Start het dialoogscript
                        dialogue2.StartDialogue();
                    }
                }
            }
            else
            {
                HideButton(); // Verberg de knop als geen van de radio-objecten wordt geraakt
            }
        }
        else
        {
            HideButton(); // Verberg de knop als er geen objecten worden geraakt door de raycast
        }
    }
}