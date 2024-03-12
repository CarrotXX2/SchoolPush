using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleuteldeur : MonoBehaviour
{
    public GameObject Hendel;
    public GameObject Deur;
    public Camera mainCamera;
    public Button Metsleutel; // Knop voor interactie met sleutel
    public Button ZonderSleutel; // Alternatieve knop voor interactie zonder sleutel

    private bool haveKey = false;

    void Start()
    {
        // Deactiveer de knoppen bij het starten van het spel
        Metsleutel.gameObject.SetActive(false);
        ZonderSleutel.gameObject.SetActive(false);
    }

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
                // Controleren of het geraakte object hetzelfde is als het huidige object
                if (hit.collider.CompareTag("Sleutel"))
                {
                    // Als het object de tag "Sleutel" heeft, set haveKey op true en vernietig de sleutel
                    haveKey = true;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.gameObject == Hendel && haveKey)
                {
                    // Verwijder de deur als het geraakte object hetzelfde is als de hendel en haveKey true is
                    if (Deur != null) // Controleer of Deur niet null is om fouten te voorkomen
                    {
                        Destroy(Deur);
                    }
                }
            }
        }

        // Controleren of de speler naar de hendel kijkt
        if (Physics.Raycast(ray, out hit))
        {
            // Als de speler naar de hendel kijkt, activeer de juiste knop
            if (hit.collider.gameObject == Hendel || hit.collider.gameObject == Deur)
            {
                if (haveKey)
                {
                    // Als de speler de sleutel heeft, activeer de Metsleutel knop
                    Metsleutel.gameObject.SetActive(true);
                }
                else
                {
                    // Als de speler de sleutel niet heeft, activeer de ZonderSleutel knop
                    Metsleutel.gameObject.SetActive(false);
                    ZonderSleutel.gameObject.SetActive(true);
                }
            }

        }
    }
}