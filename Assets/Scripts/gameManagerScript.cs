using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameManagerScript : MonoBehaviour
{
    private bool gameOver = false;
    public static bool gameWon = false;
    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    public Text gameOverScoreValue;
    public Text gameWonScoreValue;
    private  int totalNumberOfEnemies = WaveSpawner.wavesLeft*(WaveSpawner.wavesLeft+1)/2;
    public static int enemiesDestroyed = 0;
    public static int livesLeft = 5;
    public static int score = 0;
    // Update is called once per frame
    void Update()
    {
        if(gameOver || gameWon)
        {
            return;
        }
        if(livesLeft <= 0)
        {
            EndGame();
        }
        if(enemiesDestroyed>=totalNumberOfEnemies)
        {
            WinGame();
        }
    }
    private void ResetVars() 
    {
        enemiesDestroyed = 0;
        gameWon = false;
        gameOver = false;
        score = 0;
        livesLeft = 5;
        gameWonScreen.SetActive(false);    
        gameOverScreen.SetActive(false);    
        WaveSpawner.wavesLeft = 3;        
    }
    private void WinGame()
    {
        gameWonScoreValue.text = score.ToString();
        gameWon = true;
        gameWonScreen.SetActive(true);   
    }
    public void RestartGame()
    {
        ResetVars(); 
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    public void LeaveGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }
    private void EndGame()
    {
        gameOverScoreValue.text = score.ToString();
        gameOver = true;
        gameOverScreen.SetActive(true);
    }
}
