using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyController : MonoBehaviour
{
  public float visibleTime = 5f;
  private SpriteRenderer grannyRanderer = null;
  CookieController cookie = null;
  // Start is called before the first frame update
  void Start()
  {
    grannyRanderer = GetComponent<SpriteRenderer>();
    grannyRanderer.enabled = false;
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
    }
  }

  void setGrannyInvisible()
  {
    grannyRanderer.enabled = false;
    visibleTime = 5f;
    cookie.setVisible(!grannyRanderer.enabled);
    cookie = null;
  }

  void OnMouseDown()
  {

  }
}
