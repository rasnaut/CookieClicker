using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyController : MonoBehaviour
{
  public float visibleTime = 5f;
  int minusPoints = -5;
  private SpriteRenderer grannyRanderer = null;
  private PolygonCollider2D collider2D = null;
  CookieController cookie = null;
  GameController gameController = null;
  // Start is called before the first frame update
  void Start()
  {
    grannyRanderer = GetComponent<SpriteRenderer>();
    grannyRanderer.enabled = false;
    collider2D = GetComponent<PolygonCollider2D>();
    collider2D.enabled = false;

    gameController = FindObjectOfType<GameController>();
  }

  // Update is called once per frame
  void Update()
  {
    if(grannyRanderer.enabled)
    {
      visibleTime -= Time.deltaTime;
      if(visibleTime<=0)
      {
        setGrannyInvisible();
      }
    }
  }

  public void setGrannyVisible(CookieController _cookie)
  {
    //GetComponent<Transform>().position = position;
    if(!cookie)
    {
      cookie = _cookie;
      transform.position = cookie.getPosition();

      grannyRanderer.enabled = true;
      cookie.setVisible(!grannyRanderer.enabled);
      collider2D.enabled = true;
    }
  }

  void setGrannyInvisible()
  {
    grannyRanderer.enabled = false;
    collider2D.enabled = false;
    visibleTime = 5f;
    cookie.setVisible(!grannyRanderer.enabled);
    cookie = null;
  }

  void OnMouseDown()
  {
    gameController.AddScore(minusPoints);
  }
}
