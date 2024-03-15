using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOptionsPanel : MonoBehaviour
{
    public GameObject optionsPanel;

    void Update()
    {
        // Controleer of de Escape-toets wordt ingedrukt
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Als het OptionsPanel bestaat, activeer het
            if (optionsPanel != null)
            {
                optionsPanel.SetActive(!optionsPanel.activeSelf); // Wissel de actieve staat van het OptionsPanel
            }
            else
            {
                Debug.LogWarning("OptionsPanel is niet toegewezen in de Inspector!");
            }
        }
    }
}