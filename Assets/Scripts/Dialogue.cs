using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public string[] dialogueArray;
    public float textSpeed;
    public int regelIndex;
    private bool isTyping;

    void Start()
    {
        gameObject.SetActive(false);
    }
    public void StartDialogue()
    {
        gameObject.SetActive(true);
        regelIndex = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char character in dialogueArray[regelIndex].ToCharArray())
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
        if (regelIndex < dialogueArray.Length - 1)
        {
            regelIndex++;
            textBox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}