using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text elapsedTimeText;
    public Text happinessCounterText;
    public GameObject gameOverPanel;

    private bool isGameOver;
    private float elapsedTime;
    private ResponsiveCat[] responsiveCats;

    void Start()
    {
        GameObject[] pets = GameObject.FindGameObjectsWithTag("Pet");
        responsiveCats = new ResponsiveCat[pets.Length];

        for (int i = 0; i < pets.Length; i++)
        {
            responsiveCats[i] = pets[i].GetComponent<ResponsiveCat>();
        }

        SetHappinessCountText(0);
        SetElapsedTimeText(0f);
        isGameOver = false;
        elapsedTime = 0f;
    }

    void Update()
    {
        if (!isGameOver)
        {
            int happinessCount = 0;

            for (int i = 0; i < responsiveCats.Length; i++)
            {
                happinessCount += responsiveCats[i].counter;
            }

            elapsedTime += Time.deltaTime;
            SetHappinessCountText(happinessCount);
            SetElapsedTimeText(elapsedTime);

            if (happinessCount <= 0)
            {
                isGameOver = true;
                gameOverPanel.SetActive(true);
                SaveCurrentScore();
            }
        }
    }

    private string GetHappinessCountText(int currentScore)
    {
        return "Happiness: " + currentScore;
    }

    private void SetHappinessCountText(int currentScore)
    {
        happinessCounterText.text = GetHappinessCountText(currentScore);
    }

    private void SetElapsedTimeText(float elapsedTime)
    {
        elapsedTimeText.text = "Score: " + elapsedTime.ToString("0");
    }

    private void SaveCurrentScore()
    {
        ScoreManager.Instance.SubmitNewHighscore((int)elapsedTime);
    }
}
