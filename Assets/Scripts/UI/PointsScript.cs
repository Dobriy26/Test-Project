using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;
    private int points;
    private void Start()
    {
        points = 0;
        UpdatePointsText();
    }

    public void EnemyKilled()
    {
        points += 1;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = "Score: " + points;
    }
}
