using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameButton; // Referentie naar de gamebutton
    public bool isPaused = false;
    private CursorLockMode previousLockMode;

    void Start()
    {
        // Zorg ervoor dat het pauzemenu niet actief is wanneer het spel begint
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
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
            Time.timeScale = 0.001f; // Pauzeer de tijd in het spel
            isPaused = true;
            previousLockMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None; // Ontgrendel de muis
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

    // Voer de Resume methode uit wanneer de gamebutton wordt gebruikt
    public void OnGameButtonClicked()
    {
        Resume();
    }
}