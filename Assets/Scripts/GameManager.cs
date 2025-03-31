using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseGameCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finalScore;
    [SerializeField] private Text finalHighScore;
    [SerializeField] Button instructionButton;
    private TextMesh textt;

    private void Awake()
    {
        Time.timeScale = 0;
        if (instance == null)
            instance = this;
    }
    public void OnEnterInsructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void PauseGame()
    {
        pauseGameCanvas.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseGameCanvas.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver(int score, int highScore)
    {
            finalScore.text = score.ToString();
            finalHighScore.text = highScore.ToString();
        gameOverCanvas.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void OnEnterRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
