using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenelader : MonoBehaviour
{
    // Voeg de naam van de scene toe die je wilt laden in de inspector
    public string sceneToLoad;

    // Methode om een bepaalde scene te laden
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}