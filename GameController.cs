using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
  public int score = 0, level = 1, scoreToGranny = 20, scoreToUpperValue=40;
  int scoreCoeficent = 1;
  public int scoreToWin = 30; // количество очков для победы
  public Text scoreText=null, levelText=null;
  GrannyController grannyController=null;
  CookieSpawner cookieSpawner = null;

  // Start is called before the first frame update
  void Start()
  {
    grannyController = FindObjectOfType<GrannyController>();
    UpdateScoreText();
    UpdateLevelText();

    cookieSpawner = FindObjectOfType<CookieSpawner>();
    cookieSpawner.numberOfCookies = level;
    cookieSpawner.SpawnCookies();
  }

  public void AddScore(int points)
  {
     score += points * scoreCoeficent;

    if (score >= scoreToUpperValue) scoreCoeficent = 2;

    UpdateScoreText();
    CheckGameOver();
  }

  public void HandleGrannyAppearance(CookieController cookie)
  {
    if (score >= scoreToGranny)
    {
      grannyController.setGrannyVisible(cookie);
    }
  }

  void UpdateScoreText()
  {
    if (scoreText)
      scoreText.text = "Score: " + score + "/" + scoreToWin;
  }

  void UpdateLevelText()
  {
    if (levelText)
      levelText.text = "Level " + level.ToString();
  }

  void CheckGameOver()
  {
    if (score == scoreToWin)
    {
      scoreText.text = "Вы победили!";
      cookieSpawner.DestroyCookies();

      level++;
      score = 0;
      scoreToWin *= 2;
      UpdateScoreText();
      UpdateLevelText();
      cookieSpawner.numberOfCookies = level;
      cookieSpawner.SpawnCookies();
    }
    else if (score > scoreToWin)
    {
      scoreText.text = "Вы проиграли :(";
      cookieSpawner.DestroyCookies();
      score = 0;
      
      cookieSpawner.SpawnCookies();
    }
  }
}
