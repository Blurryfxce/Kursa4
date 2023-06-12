using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;

    public Text highScoreText;

    public GameObject playButton;

    public GameObject gameoverImage;

    public Player player;

    private int score;

    private int highScore;

    public void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameoverImage.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Trees[] trees = FindObjectsOfType<Trees>();

        for (int i = 0; i < trees.Length; i++)
        {
            Destroy(trees[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameoverImage.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
        }
        highScoreText.text = highScore.ToString();
    }
}
