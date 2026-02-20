using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverCanvas;

    void Awake()
    {
        // singleton safety
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;   // pause game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;   // resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}