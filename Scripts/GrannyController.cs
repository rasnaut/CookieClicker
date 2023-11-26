using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyController : MonoBehaviour
{
  public float visibleTime = 5f;
  int minusPoints = -5;
  private SpriteRenderer grannyRanderer = null;
  private CapsuleCollider2D collider2D = null;
  CookieController cookie = null;
  GameController gameController = null;
  AudioSource audioSource = null;
  bool grannySleep = false;
  // Start is called before the first frame update
  void Start()
  {
    grannyRanderer = GetComponent<SpriteRenderer>();
    grannyRanderer.enabled = false;
    collider2D = GetComponent<CapsuleCollider2D>();
    collider2D.enabled = false;

    gameController = FindObjectOfType<GameController>();
    audioSource = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if(grannyRanderer.enabled)
    {
      animateMove();
      visibleTime -= Time.deltaTime;
      if(visibleTime<=0)
      {
        setGrannyInvisible();
        grannySleep = true;
      }
    }
    else if(grannySleep)
    {
      visibleTime -= Time.deltaTime;
      if (visibleTime <= 0)
      {
        grannySleep = false;
        visibleTime = 5f;
      }
    }
  }

  public void setGrannyVisible(CookieController _cookie)
  {
    //GetComponent<Transform>().position = position;
    if(!cookie && !grannySleep)
    {
      cookie = _cookie;
      transform.position = cookie.getPosition();

      grannyRanderer.enabled = true;
      cookie.setVisible(!grannyRanderer.enabled);
      collider2D.enabled = true;
    }
  }

  public void setGrannyInvisible()
  {
    grannyRanderer.enabled = false;
    collider2D.enabled = false;
    visibleTime = 5f;
    if(cookie)
    {
      cookie.setVisible(true);
      cookie = null;
    }
  }

  void OnMouseDown()
  {
    Debug.Log("GrannyClick");
    gameController.AddScore(minusPoints);
    audioSource.Play();
    Animate();
  }

  private void Animate()
  {
    // Уменьшаем размер исходного объекта, на который добавлен скрипт, (печеньки) со 100% до 80%
    transform.localScale *= 0.8f;
    // Командой Invoke() вызываем метод EnlargeCookie(), который увеличит размер печеньки через 0.1 секунду
    Invoke(nameof(Enlarge), 0.1f);
  }

  private void Enlarge()
  {
    transform.localScale /= 0.8f;
  }

  private void animateMove()
  {
      float xPosition = transform.position.x + Mathf.Sin(Time.time) * 0.005f;
      transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z);
  }
}
