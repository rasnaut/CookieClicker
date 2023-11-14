//Cтарый контроллер

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickCookie : MonoBehaviour
{
  Text scoreText = null;
  public int plusValue = 1;
  bool flag1 = false;
  bool flag2 = false;
  static int score = 0;
  public GameObject cookiePrf;

  public GameObject granny = null;
  private bool grannyVisible = false;
  private SpriteRenderer grannyRanderer = null;

  // Start is called before the first frame update
  void Start()
  {
    scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    if(granny)
    {
      grannyRanderer = granny.GetComponent<SpriteRenderer>();
      grannyRanderer.enabled = false;
    }
  }

  // Update is called once per frame
  void Update()
  {
  }

  void OnMouseDown()
  {
    scoreIncrement();

    uptadeScoreText();

    createShadowCookieInRandomPosition();
  }

  void uptadeScoreText()
  {
    if (scoreText)
    {
      scoreText.text = "Score: " + score.ToString();
    
      if (score == 100)
      {
        scoreText.text = "Вы победили!";
      }
      else if(score>100)
        scoreText.text = "Вы проиграли :(";
    }
  }

  int scoreIncrement()
  {
    if (score < 100)
    {
      if (!flag1 && score > 20)
      {
        plusValue *= 2;
        flag1 = true;
      }
      else if (!flag2 && score > 50)
      {
        plusValue += 20;
        flag2 = true;
      }
      score += plusValue;
    }
    else
    {
      resetVarabels();
    }
    return score;
  }
  
  void resetVarabels()
  {
    flag1 = false;
    flag2 = false;
    score = 0;
    plusValue = (plusValue - 20) / 2;
  }

  void createShadowCookieInRandomPosition()
  {
    float coordX = Random.Range(-10f, 10f);
    float coordY = Random.Range(-1f, 1f);

    Instantiate(cookiePrf, new Vector2(coordX, coordY), Quaternion.identity);
  }
}
