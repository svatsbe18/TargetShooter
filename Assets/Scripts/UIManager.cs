using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [Range(0,100)]
    [SerializeField] int startingScore;
    int currentScore;

    [SerializeField] Text gameOver;
    [SerializeField] Text victory;
    [SerializeField] Text defeat;

    [SerializeField] Text instructionText;

    [SerializeField] GameObject gameStartMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        instructionText.gameObject.SetActive(false);
        gameStartMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        currentScore = startingScore;
        scoreText.text = "Score : " + currentScore.ToString();
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        defeat.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStartMenu.activeInHierarchy||pauseMenu.activeInHierarchy||gameOverMenu.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if(instructionText!=null)
            {
                instructionText.gameObject.SetActive(true);
            }
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale==0)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }

        if (currentScore <= 0)
        {
            Defeat();
        }
        if (currentScore >= 100)
        {
            Victory();
        }
    }

    public void ChangeScore(int changeScore)
    {
        currentScore += changeScore;
        scoreText.text = "Score : " + currentScore.ToString();
    }

    public void Defeat()
    {
        gameOver.gameObject.SetActive(true);
        defeat.gameObject.SetActive(true);
        gameOverMenu.SetActive(true);
        GameManager.gm.GameOver();
    }

    public void Victory()
    {
        gameOverMenu.SetActive(true);
        gameOver.gameObject.SetActive(true);
        victory.gameObject.SetActive(true);
        GameManager.gm.GameOver();
    }

    public void HandleResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void HandleExitButton()
    {
        Application.Quit();
    }

    public void HandlePlayAgainButton()
    {
        GameManager.gm.Restart();
        gameStartMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        currentScore = startingScore;
        scoreText.text = "Score : " + currentScore.ToString();
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        defeat.gameObject.SetActive(false);
    }
}