using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int lives = 3; //declaring amount of lives
    public GameObject deathUI;
    public GameObject winUI;
    public Text lifeAmount;
    public Text brickCount;
    public int brickNum;
    bool gameOver; //these check to see if game is won or if game is over
    bool gameWon;

    private void Awake()
    {
        lifeAmount.text = "Lives: " + lives.ToString(); //showing lives
        brickNum = GameObject.FindGameObjectsWithTag("Wall").Length;
        brickCount.text = "Bricks Left: " + brickNum.ToString();
        gameOver = false;
        gameWon = false;
    }

    void Win()
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
        gameWon = true;
    }

   

    public void HitBrick()
    {
        brickNum--;
        brickCount.text = "Bricks Left: " + brickNum.ToString();
        if(brickNum <= 0)
        {
   
            Win();
        }

    }

    public void loseLife()
    {
        lives--;
        lifeAmount.text = "Lives: " + lives.ToString();
        if(lives <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (gameWon)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space ))
            {
                Restart();
            }
        }
    }
    void Die()
    {
        Time.timeScale = 0f;
        deathUI.SetActive(true);
        gameOver = true;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
