using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{
    // Methode om tussen volledig scherm en venstermodus te schakelen wanneer op de knop wordt geklikt
    public void ToggleFullScreen()
    {
        // Controleer of de huidige schermmodus volledig scherm is
        if (Screen.fullScreen)
        {
            // Schakel over naar venstermodus als we momenteel in volledig scherm zijn
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
            print("hoi");
        }
        else
        {
            // Schakel over naar volledig scherm als we momenteel in venstermodus zijn
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }
}