using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOptionsPanel : MonoBehaviour
{
    public GameObject optionsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsPanel != null)
            {
                optionsPanel.SetActive(!optionsPanel.activeSelf); 
            }
        }
    }
}