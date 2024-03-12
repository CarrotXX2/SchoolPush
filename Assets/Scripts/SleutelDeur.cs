using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleutelDeur : MonoBehaviour
{
    public GameObject Sleutel;
    public GameObject GeslotenDeur;
    public Camera mainCamera;
    public Button interactButton; 
    private bool haveKey = false;

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
                // Controleren of het geraakte object hetzelfde is als de sleutel
                if (hit.collider.gameObject == Sleutel)
                {
                    // Speler heeft de sleutel, set haveKey op true en vernietig de sleutel
                    haveKey = true;
                    Destroy(Sleutel);
                }
                else if (hit.collider.gameObject == GeslotenDeur && haveKey)
                {
                    // Verwijder de deur als het geraakte object hetzelfde is als de deur en de speler de sleutel heeft
                    if (GeslotenDeur != null)
                    {
                        Destroy(GeslotenDeur);
                    }
                }
            }
        }

        // Controleren of de raycast een object raakt
        if (Physics.Raycast(ray, out hit, 1f))
        {
            // Controleren of het geraakte object hetzelfde is als de deur
            if (hit.collider.gameObject == GeslotenDeur)
            {
                // De speler heeft de sleutel en kijkt naar de deur, activeer de interactieknop
                interactButton.gameObject.SetActive(true);
            }
            else
            {
                // De speler kijkt niet naar de deur of heeft de sleutel niet, deactiveer de interactieknop
                interactButton.gameObject.SetActive(false);
            }
        }

    }
}