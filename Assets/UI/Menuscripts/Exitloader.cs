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
    }
}