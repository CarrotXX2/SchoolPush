using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankPickup : MonoBehaviour
{
    public Camera mainCamera;
    public float raycastDistance = 1f;
    public int hoeveelPlank = 0;
    public GameObject plankPrefab;
    public GameObject spawnPoint; 
    public float plankOffset = 1f; 

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Plank"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hoeveelPlank += 1;

                        Destroy(hit.collider.gameObject);
                    }
                }
                else if (hoeveelPlank >= 10 && hit.collider.CompareTag("PlankSpawner") && Input.GetKeyDown(KeyCode.E))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Vector3 spawnPosition = spawnPoint.transform.position + new Vector3(i * plankOffset, 0, 0);
                        Quaternion spawnRotation = Quaternion.Euler(0, 90, -90); // Rotatie instellen
                        Instantiate(plankPrefab, spawnPosition, spawnRotation);
                    }
                }
            }
        }
    }
}