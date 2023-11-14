using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
  public int plusPoints = 1; //количество добавляемых печенькой очков
  public GameObject transparenCookiePrefab=null; //указатель на префаб призрачной печеньки
  
  GameController gameController = null;

  void Start()
  {
    gameController = FindObjectOfType<GameController>();
  }

  void OnMouseDown()
  {
    gameController.AddScore(plusPoints);
    gameController.HandleGrannyAppearance(this);
    createShadowCookieInRandomPosition();
  }

  public Vector3 getPosition() { return transform.position; }

  public void setVisible(bool isVisible) { GetComponent<SpriteRenderer>().enabled = isVisible; }


  void createShadowCookieInRandomPosition()
  {
    float coordX = Random.Range(-10f, 10f);
    float coordY = Random.Range(-1f, 1f);

    Instantiate(transparenCookiePrefab, new Vector2(coordX, coordY), Quaternion.identity);
  }
}
