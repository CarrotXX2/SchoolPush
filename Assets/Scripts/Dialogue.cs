using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public string[] dialogueLines;
    public float textSpeed;
    private int regel;
    private bool isTyping;

    void Start()
    {
        gameObject.SetActive(false);
    }
    public void StartDialogue()
    {
        gameObject.SetActive(true);
        regel = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char character in dialogueLines[regel].ToCharArray())
        {
            textBox.text += character;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextLine();
        }
    }
    void NextLine()
    {
        if (regel < dialogueLines.Length - 1)
        {
            regel++;
            textBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}