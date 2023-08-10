using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefeatScript : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartButtonPressed);
    }

    private void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
