using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    // De naam van de scene waarnaar de speler moet worden doorgestuurd bij de dood
    public string sceneToLoad;

    void OnCollisionEnter(Collision collision)
    {
        // Controleren of de speler wordt geraakt door iets met de tag "dood"
        if (collision.gameObject.CompareTag("dood"))
        {
            // Laad de opgegeven scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}