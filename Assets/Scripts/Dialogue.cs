using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public string[] dialoogregels;
    public float textspeed;
    public int index;
    public bool isTyping;
    public bool dialogueActive;

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
            if (textcomponent.text == dialoogregels[index] && !isTyping)
            {
                Nextline();
            }
        }
    }

    public void StartDialogue()
    {
        dialogueActive = true; 
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in dialoogregels[index].ToCharArray())
        {
            textcomponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
        isTyping = false;
    }

    void Nextline()
    {
        if (index < dialoogregels.Length - 1)
        {
            index++;
            textcomponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueActive = false;
            gameObject.SetActive(false);
        }
    }
}