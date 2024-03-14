using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] lines;
    public float textspeed;

    private int index;
    private bool isTyping; // A flag to indicate whether the text is currently being typed
    private bool dialogueActive; // A flag to indicate whether the dialogue is active

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textcomponent.text == lines[index] && !isTyping) // Check if not currently typing
            {
                Nextline();
            }
            else if (!isTyping) // Check if not currently typing
            {
                StopAllCoroutines();
                textcomponent.text = lines[index];
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !dialogueActive) // Check if dialogue is not already active
        {
            StartDialogue();
        }
    }

    public void StartDialogue()
    {
        dialogueActive = true; // Set dialogue as active
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true; // Set typing flag
        foreach (char c in lines[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
        isTyping = false; // Reset typing flag
    }

    void Nextline()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueActive = false; // Reset dialogue as not active
            gameObject.SetActive(false);
        }
    }
}