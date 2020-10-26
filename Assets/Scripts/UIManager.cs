using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int currentScore = 50;

    [SerializeField] Text gameOver;
    [SerializeField] Text victory;
    [SerializeField] Text defeat;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + currentScore.ToString();
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        defeat.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        GameManager.gm.GameOver();
    }

    public void Victory()
    {
        gameOver.gameObject.SetActive(true);
        victory.gameObject.SetActive(true);
        GameManager.gm.GameOver();
    }
}
