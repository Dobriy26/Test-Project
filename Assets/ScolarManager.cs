using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // ������ �� ��������� ������� UI
    private int score; // ������� ����

    private void Start()
    {
        score = 0; // ������������� ����� �����
        UpdateScoreText(); // ���������� ������ �� ������
    }

    public void EnemyKilled()
    {
        score += 1; // ����������� ����
        UpdateScoreText(); // ��������� ����� �� ������
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // ������������� �����, ������������ ������� ����
    }
}
