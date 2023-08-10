using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText; 
    private int score;
    private void Start()
    {
        score = 0; 
        UpdateScoreText(); 
    }

    public void EnemyKilled()
    {
        score += 1;
        UpdateScoreText(); 
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; 
    }
}
