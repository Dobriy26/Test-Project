using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Ссылка на текстовый элемент UI
    private int score; // Текущий счет

    private void Start()
    {
        score = 0; // Инициализация счета нулем
        UpdateScoreText(); // Обновление текста на экране
    }

    public void EnemyKilled()
    {
        score += 1; // Увеличиваем счет
        UpdateScoreText(); // Обновляем текст на экране
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Устанавливаем текст, отображающий текущий счет
    }
}
