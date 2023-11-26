using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
  public int plusPoints = 1; //количество добавляемых печенькой очков
  public GameObject transparenCookiePrefab=null; //указатель на префаб призрачной печеньки
  
  GameController gameController = null;
  AudioSource plusSound = null;

  void Start()
  {
    gameController = FindObjectOfType<GameController>();
    plusSound = GetComponent<AudioSource>();
  }

  void OnMouseDown()
  {
    Debug.Log("CookieClick");
    gameController.AddScore(plusPoints);
    gameController.HandleGrannyAppearance(this);
    createShadowCookieInRandomPosition();
    plusSound.Play();
    //Animate();
  }

  public void Click()
  {
    OnMouseDown();
  }

  public Vector3 getPosition() { return transform.position; }

  public void setVisible(bool isVisible) {
    GetComponent<SpriteRenderer>().enabled = isVisible;
    GetComponent<CircleCollider2D>().enabled = isVisible;
  }


  private void createShadowCookieInRandomPosition()
  {
    float coordX = Random.Range(-10f, 10f);
    float coordY = Random.Range(-1f, 1f);

    Instantiate(transparenCookiePrefab, new Vector2(coordX, coordY), Quaternion.identity);
  }

  private void Animate()
  {
    // Уменьшаем размер исходного объекта, на который добавлен скрипт, (печеньки) со 100% до 80%
    transform.localScale *= 0.8f;
    // Командой Invoke() вызываем метод EnlargeCookie(), который увеличит размер печеньки через 0.1 секунду
    Invoke(nameof(EnlargeCookie), 0.1f);
  }

  private void EnlargeCookie()
  {
    // Увеличиваем размер печеньки до исходного значения
    transform.localScale /= 0.8f;
  }
}
