using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public Scene Startscreen;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("dood")) // Controleer of de speler botst met een vijand
        {
            SceneManager.LoadScene(0);
        }
    }
}