using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour
{

  public GameObject cookiePrefab; // Префаб печеньки
  public int numberOfCookies = 1; // Количество печенек для текущего уровня
  GameObject[] cookieArray;

  void Start()
  {
    cookieArray = new GameObject[10];
  }
  public void SpawnCookies()
  {
    for (int index = 0; index < numberOfCookies; index++)
    {
      // Создаем печеньку и устанавливаем ее позицию
      cookieArray[index] = Instantiate(cookiePrefab, GetCookiePosition(index), Quaternion.identity);
      if (index > 0)
        cookieArray[index].GetComponent<CookieController>().plusPoints = 10 * index;
    }
  }

  public void DestroyCookies()
  {
    for (int index = 0; index < numberOfCookies; index++)
    {
      Destroy(cookieArray[index]);
    }
  }

  Vector3 GetRandomPosition()
  {
    return new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
  }

  Vector3 GetCookiePosition(int cookieNumber = 0)
  {
    Vector3 position;
    if (numberOfCookies == 1)
      position = new Vector3(0, 0, 0);
    else if (numberOfCookies == 2)
    {
      float x = -3f + 6f * cookieNumber;
      position = new Vector3(x, 0, 0);
    }
    else if (numberOfCookies == 3)
    {
      float x = cookieNumber < 2 ? (- 3f + 6f * cookieNumber) : 0;
      float y = cookieNumber < 2 ? 2 : -2;
      position = new Vector3(x, y, 0);
    }
    else 
      position = GetRandomPosition();
    
    return position;
  }
}
