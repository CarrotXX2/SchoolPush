using UnityEngine;
using UnityEngine.UI;

public class LookAtButton : MonoBehaviour
{
    public string targetTag = "Plank";
    public Button uiButton;

    private bool isLookingAtTarget = false;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                if (!isLookingAtTarget)
                {
                    isLookingAtTarget = true;
                    uiButton.gameObject.SetActive(true);
                }
            }
            else
            {
                if (isLookingAtTarget)
                {
                    isLookingAtTarget = false;
                    uiButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (isLookingAtTarget)
            {
                isLookingAtTarget = false;
                uiButton.gameObject.SetActive(false);
            }
        }
    }
}