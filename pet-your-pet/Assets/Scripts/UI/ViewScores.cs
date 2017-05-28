using UnityEngine;
using UnityEngine.UI;


public class ViewScores : MonoBehaviour
{
    public Text scoreContents;

    void Start()
    {
        int[] scores = ScoreManager.Instance.GetHighscores();
        scoreContents.text = "Current Highscores:\n";

        for (int i = 0; i < scores.Length; i++)
        {
            scoreContents.text += i + 1 + ". " + scores[i] + "\n";
        }
    }

}
