using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public GameObject canvasObject;
    public GameObject endObject;

    private float startTime;
    private float totalTimeSpent;
    private bool gameFinished = false;

    void Start()
    {
        // Record the start time only at the beginning of the game
        if (!gameFinished)
        {
            startTime = Time.time;
        }
    }

    void Update()
    {
        if (gameFinished)
            return;

        float timeSpentInGame = Time.time - startTime;
        timeText.text = "Goedzo je hebt het spel beindigt in: " + timeSpentInGame.ToString("F2") + " seconds";

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                if (hit.collider.CompareTag("Einde"))
                {
                    EndGame(timeSpentInGame);
                    canvasObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }

    void EndGame(float totalTimeSpent)
    {
        gameFinished = true;
    }
}