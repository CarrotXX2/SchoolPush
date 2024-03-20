using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // Naam van de scene die moet worden geladen

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded: " + sceneName); // Optioneel: voeg een debugbericht toe om te controleren of de knop correct werkt
    }
}