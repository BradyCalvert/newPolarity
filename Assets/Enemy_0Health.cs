using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_0Health : MonoBehaviour {
  public int enemy_health;

  private void OnTriggerEnter(Collider other)
  {
    if(other.CompareTag("Bullet")==true)
    {
      enemy_health = enemy_health - 1;
    }
  }
}
