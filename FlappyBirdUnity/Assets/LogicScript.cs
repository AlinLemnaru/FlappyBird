using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;

    public float moveSpeed = 5f;

    [SerializeField]
    private Text scoreText;

    public GameObject gameOverScreen;

    public AudioSource scoreSound;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore++;
        scoreText.text = playerScore.ToString();

        if (playerScore % 5 == 0 && playerScore != 0)
        {
            scoreSound.Play();
            moveSpeed += 1f;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
