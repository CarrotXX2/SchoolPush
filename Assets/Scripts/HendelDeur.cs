using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HendelDeur : MonoBehaviour
{
    public GameObject Hendel;
    public GameObject Deur;
    public Camera mainCamera;
    public Button interactButton; // Voeg hier de public Button toe

    void Update()
    {
        // Raycast vanuit het midden van het scherm
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        // Controleren of de speler op de "E" toets drukt
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Controleren of de raycast een object raakt
            if (Physics.Raycast(ray, out hit))
            {
                // Controleren of het geraakte object hetzelfde is als de hendel
                if (hit.collider.gameObject == Hendel)
                {
                    // Verwijder de deur als het geraakte object hetzelfde is als de hendel
                    if (Deur != null)
                    {
                        Destroy(Deur);
                    }
                }
            }
        }

        // Controleren of de raycast een object raakt
        if (Physics.Raycast(ray, out hit))
        {
            // Controleren of het geraakte object hetzelfde is als de hendel of de deur
            if (hit.collider.gameObject == Hendel)
            {
                // De speler kijkt naar de hendel of de deur, activeer de interactieknop
                interactButton.gameObject.SetActive(true);
            }
        }
        else
        {
            // De raycast heeft geen object geraakt, deactiveer de interactieknop
            interactButton.gameObject.SetActive(false);
        }
    }
}