using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    void Start()
    {
        // Zoek de knopcomponent in het gameobject waar dit script aan is gekoppeld
        Button fullScreenButton = GetComponent<Button>();
        // Voeg een luisteraar toe aan de knop om te reageren op klikken
        fullScreenButton.onClick.AddListener(ToggleFullScreen);
    }

    void ToggleFullScreen()
    {
        // Wissel tussen volledig scherm en venstermodus
        Screen.fullScreen = !Screen.fullScreen;
    }
}