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
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == Sleutel)
                {
                    haveKey = true;
                    Destroy(Sleutel);
                }
                else if (hit.collider.gameObject == GeslotenDeur && haveKey)
                {
                    if (GeslotenDeur != null)
                    {
                        Destroy(GeslotenDeur);
                    }
                }
            }
        }

        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.collider.gameObject == GeslotenDeur)
            {
                interactButton.gameObject.SetActive(true);
            }
            else
            {
                interactButton.gameObject.SetActive(false);
            }
        }

    }
}