using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;

    private bool isGameOver;
    private ResponsiveCharacter[] responsiveCharacters;

    void Start()
    {
        GameObject[] pets = GameObject.FindGameObjectsWithTag("Pet");
        responsiveCharacters = new ResponsiveCharacter[pets.Length];

        for (int i = 0; i < pets.Length; i++)
        {
            responsiveCharacters[i] = pets[i].GetComponent<ResponsiveCharacter>();
        }

        SetScoreText(0);
        gameOverText.text = "";
        isGameOver = false;
    }

    void Update()
    {
        if (!isGameOver)
        {
            int score = 0;

            for (int i = 0; i < responsiveCharacters.Length; i++)
            {
                score += responsiveCharacters[i].counter;
            }

            SetScoreText(score);

            if (score <= 0)
            {
                isGameOver = true;
                gameOverText.text = "Game Over";
            }
        }
    }

    private string GetScoreText(int currentScore)
    {
        return "Score: " + currentScore;
    }

    private void SetScoreText(int currentScore)
    {
        scoreText.text = GetScoreText(currentScore);
    }
}
