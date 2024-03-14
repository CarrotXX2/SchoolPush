using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankPickup : MonoBehaviour
{
    public Camera mainCamera;
    public float raycastDistance = 1f;
    public int hoeveelPlank = 0;
    public GameObject plankPrefab; // Prefab van de plank die je wilt spawnen
    public GameObject spawnPoint; // GameObject waarop de planken moeten worden gespawned
    public float plankOffset = 1f; // Offset tussen de gespawnede planken

    void Start()
    {
        // Zoek de MainCamera en sla een referentie ervan op
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Controleer of de mainCamera niet null is voordat we de raycast uitvoeren
        if (mainCamera != null)
        {
            // Voert een raycast uit vanuit het midden van de camera.
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Plank"))
                {
                    // Als het object dat is geraakt de juiste tag heeft en de speler op de E-toets drukt.
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        // Verhoog de variabele Hoeveelplank met 1.
                        hoeveelPlank += 1;

                        // Verwijder de plank.
                        Destroy(hit.collider.gameObject);
                    }
                }
                else if (hoeveelPlank >= 10 && hit.collider.CompareTag("PlankSpawner") && Input.GetKeyDown(KeyCode.E))
                {
                    // Spawn 10 nieuwe objecten met de tag "LoopPlank" op het spawnPoint
                    for (int i = 0; i < 10; i++)
                    {
                        Vector3 spawnPosition = spawnPoint.transform.position + new Vector3(i * plankOffset, 0, 0);
                        Instantiate(plankPrefab, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}