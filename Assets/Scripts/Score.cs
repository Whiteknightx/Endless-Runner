using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the Text component used to display the score
    private int score; // Variable to store the score

    void Start()
    {
        score = 0; // Initialize the score to 0
        AddScore();
    }

    public void AddScore()
    {
        score++; // Add points to the score
        UpdateScoreText(); // Update the score text display
        Invoke("AddScore", 1f);
    }

    void UpdateScoreText()
    {
        scoreText.text = "" + score; // Update the score text with the current score value
    }
}