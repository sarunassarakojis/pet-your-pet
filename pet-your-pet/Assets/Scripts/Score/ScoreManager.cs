using UnityEngine;

public class ScoreManager
{
    public static int numberOfHighscores = 3;

    private static string keyPrefix = "highscore";

    private static ScoreManager scoreManager;

    private ScoreManager()
    {
        for (int i = 0; i < numberOfHighscores; i++)
        {
            if (!PlayerPrefs.HasKey(keyPrefix + i))
            {
                SetHighscore(i, 0);
            }
        }
    }

    public static ScoreManager Instance
    {
        get
        {
            if (scoreManager == null)
            {
                scoreManager = new ScoreManager();
            }

            return scoreManager;
        }
    }

    public void SubmitNewHighscore(int newHighscore)
    {
        for (int i = 0; i < numberOfHighscores; i++)
        {
            int previousScore = GetHighscore(i);

            if (newHighscore > previousScore)
            {
                SetHighscore(i, newHighscore);
                SubmitNewHighscore(previousScore);
                break;
            }
        }
    }

    public int[] GetHighscores()
    {
        int[] highscores = new int[numberOfHighscores];

        for (int i = 0; i < numberOfHighscores; i++)
        {
            highscores[i] = GetHighscore(i);
        }

        return highscores;
    }

    public void DeleteAllHighscores()
    {
        for (int i = 0; i < numberOfHighscores; i++)
        {
            PlayerPrefs.DeleteKey(keyPrefix + i);
        }
    }

    private void SetHighscore(int highscoreIndex, int highscore)
    {
        PlayerPrefs.SetInt(keyPrefix + highscoreIndex, highscore);
    }

    private int GetHighscore(int highscoreIndex)
    {
        return PlayerPrefs.GetInt(keyPrefix + highscoreIndex);
    }
}
