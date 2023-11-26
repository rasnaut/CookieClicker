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
  public AudioClip levelPassAudio;
  public AudioClip levelFailAudio;

  GrannyController grannyController=null;
  CookieSpawner cookieSpawner = null;
  bool startGameFlag = true;
  AudioSource audioSource = null;

  // Start is called before the first frame update
  void Start()
  {
    grannyController = FindObjectOfType<GrannyController>();
    cookieSpawner = FindObjectOfType<CookieSpawner>();
    audioSource = GetComponent<AudioSource>();
    StartLevel();
  }

  public void AddScore(int points)
  {
    if (startGameFlag) 
      StartLevel();
    else
    {
      score += points * scoreCoeficent;

      if (score >= scoreToUpperValue) scoreCoeficent = 2;

      UpdateScoreText();
      CheckGameOver();
    }
  }

  public void HandleGrannyAppearance(CookieController cookie)
  {
    if (score >= scoreToGranny) grannyController.setGrannyVisible(cookie);
  }

  void UpdateScoreText()
  {
    if (scoreText) scoreText.text = "Score: " + score + "/" + scoreToWin;
  }

  void UpdateLevelText()
  {
    if (levelText) levelText.text = "Level " + level.ToString();
  }

  void CheckGameOver()
  {
    if (score == scoreToWin)
    {
      audioSource.PlayOneShot(levelPassAudio);
      scoreText.text = "Вы победили!";
      level++;
      scoreToWin *= 2;
      startGameFlag = true;
    }
    else if (score > scoreToWin)
    {
      audioSource.PlayOneShot(levelFailAudio);
      scoreText.text = "Вы проиграли :(";
      startGameFlag = true;
    }
  }

  void StartLevel()
  {
    cookieSpawner.DestroyCookies();
    score = 0;
    cookieSpawner.SpawnCookies(level);
    UpdateScoreText();
    UpdateLevelText();
    startGameFlag = false;
    grannyController.setGrannyInvisible();
  }

  public void TEST_ClickToAllCookies()
  {
    int old_score = score;
    int plusAllValue = cookieSpawner.OnClickOnAllCookies();
    if(score == (old_score + plusAllValue))
    {
      Debug.Log("TEST_ClickToAllCookies ....... PASS!");
    }
    else
    {
      Debug.Log("TEST_ClickToAllCookies ....... FAIL!");
      Debug.Log("Expected score: " + (old_score + plusAllValue) + " Observed score: " + score);
    }
  }

  void TEST_UpdateScoreText_Standart_Behaivior()
  {
    score = 2;
    scoreToWin = 20;

    UpdateScoreText();
    
    if(scoreText.text == "Score: 2/20")
    {
      Debug.Log("TEST_UpdateScoreText_Standart_Behaivior ..... PASS!");
    }
  }
}
