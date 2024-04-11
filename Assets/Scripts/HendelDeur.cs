using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HendelDeur : MonoBehaviour
{
    public GameObject Hendel;
    public GameObject DeurPrefab;
    public Button interactButton;
    public bool hasInteracted = false;
    public AudioClip interactSound; // Geluidseffect dat moet worden afgespeeld
    private AudioSource audioSource; // AudioSource-component van Hendel

    public GameObject spawnPoint;
    public GameObject currentDoor;


    void Start()
    {
        // Zoek AudioSource-component op de Hendel
        audioSource = Hendel.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Voeg AudioSource-component toe als het niet aanwezig is
            audioSource = Hendel.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E) && !hasInteracted)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == Hendel)
                {
                    if (currentDoor != null)
                    {
                        Destroy(currentDoor);

                    }

                    if (DeurPrefab != null && spawnPoint != null)
                    {
                        currentDoor = Instantiate(DeurPrefab, spawnPoint.transform.position, Quaternion.identity);
                        hasInteracted = true;
                        interactButton.gameObject.SetActive(false);

                        // Speel het geluidseffect af
                        if (interactSound != null && audioSource != null)
                        {
                            audioSource.PlayOneShot(interactSound);
                        }
                    }
                }
            }
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == Hendel)
            {
                if (!hasInteracted)
                {
                    interactButton.gameObject.SetActive(true);
                }
            }
            else
            {
                interactButton.gameObject.SetActive(false);
            }
        }
        else
        {
            interactButton.gameObject.SetActive(false);
        }
    }

    public void SetSpawnPoint(GameObject point)
    {
        spawnPoint = point;
    }
}