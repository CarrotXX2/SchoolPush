using System.Collections;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    public Camera mainCamera;
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public bool radio1Interacted = false;
    public bool radio2Interacted = false;
    public bool radio3Interacted = false;
    public RaycastHit hit;


    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);        

        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            if (hit.collider.CompareTag("Radio1") && !radio1Interacted)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio1Interacted = true;
                    dialogue.StartDialogue(); //Start de component (script)
                }
            }
            else if (hit.collider.CompareTag("Radio2") && !radio2Interacted)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio2Interacted = true;
                    dialogue2.StartDialogue();
                }
            }
            else if (hit.collider.CompareTag("Radio3") && !radio3Interacted)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    radio3Interacted = true;
                    dialogue3.StartDialogue();
                }
            }
        }
    }
}