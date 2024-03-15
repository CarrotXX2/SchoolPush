using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;
    private CursorLockMode previousLockMode;

    void Start()
    {
        // Zorg ervoor dat het pauzemenu niet actief is wanneer het spel begint
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Pauzemenu UI niet toegewezen in de Inspector!");
        }
    }

    void Update()
    {
        // Controleer of de speler op de Escape-toets drukt
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Als het spel niet gepauzeerd is, pauzeer het dan
            if (!isPaused)
            {
                Pause();
            }
            // Als het spel gepauzeerd is, hervat het dan
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        // Activeer het pauzemenu
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f; // Pauzeer de tijd in het spel
            isPaused = true;
            previousLockMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None; // Ontgrendel de muis
        }
        else
        {
            Debug.LogWarning("Pauzemenu UI niet toegewezen in de Inspector!");
        }
    }

    public void Resume()
    {
        // Deactiveer het pauzemenu
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f; // Hervat de tijd in het spel
            isPaused = false;
            Cursor.lockState = previousLockMode; // Vergrendel de muis weer in de vorige modus
        }
        else
        {
            Debug.LogWarning("Pauzemenu UI niet toegewezen in de Inspector!");
        }
    }

    // Methode om het spel te hervatten als de speler op een knop in het pauzemenu klikt
    public void ResumeGame()
    {
        Resume();
    }

    // Methode om terug te gaan naar het hoofdmenu
    public void LoadMainMenu()
    {
        // Hier kun je code toevoegen om naar het hoofdmenu te laden
        // SceneManager.LoadScene("MainMenu"); // Als je SceneManager gebruikt
        Debug.Log("Hoofdmenu wordt geladen...");
    }

    // Methode om het geluid uit te schakelen
    public void MuteSound()
    {
        // Hier kun je code toevoegen om het geluid uit te schakelen
        Debug.Log("Geluid wordt uitgeschakeld...");
    }
}