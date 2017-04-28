using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

  const string S_PATROL = "Patrol";
  const string S_CHASE = "Chase";
  const string S_SHOOT = "Shoot";


  const string E_IF_ATTACKED = "isAttacked";
  const string P_IF_PLAYER_CLOSE = "ifPlayerClose";
  const string P_PLAYER_TOO_FAR = "playerTooFar";
  const string P_PLAYER_DEAD = "playerDead";
  const string P_PLAYER_VERY_CLOSE = "playerVeryClose";
  const string P_PLAYER_NOT_CLOSE_ENOUGH = "playerNotCloseEnough";

  public Enemy_0Health health;

  public GameObject player;
  Animator anim;
  public float chaseRange;


  public float checkFrequency;


  public void Awake()
  {

    anim = GetComponent<Animator>();
    InvokeRepeating("CheckForPlayerDeath", checkFrequency, checkFrequency);
  }


  void Update()
  {
    CheckForPlayerDeath();
    CheckForPlayerShootRange();
#if UNITY_EDITOR
    Ray ray = new Ray(transform.position, transform.forward);
    Debug.DrawRay(ray.origin, ray.direction.normalized * chaseRange);
#endif
  }

  void CheckIfPlayerIsClose()
  {
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;
    if (Physics.Raycast(ray.origin, ray.direction, out hit, chaseRange))
    {
      if (hit.transform.CompareTag("Player"))
      {
        anim.SetBool(P_IF_PLAYER_CLOSE, true);
        CheckForPlayerShootRange();
      }

      else

        anim.SetBool(P_IF_PLAYER_CLOSE, false);
    }
    else
    {

      anim.SetBool(P_IF_PLAYER_CLOSE, false);
    }

  }



  public void CheckForPlayerShootRange()
  {

    float distance = Vector3.Distance(player.transform.position, transform.position);
    {
      if (distance < chaseRange)
      {
        anim.SetBool(P_PLAYER_VERY_CLOSE, true);

      }
      else
      {
        anim.SetBool(P_PLAYER_VERY_CLOSE, false);
      }
    }
  }





  void CheckForPlayerDeath()
  {
    if (health.enemy_health>0)
    {
      anim.SetBool(P_PLAYER_DEAD, false);
    }
    else
      anim.SetBool(P_PLAYER_DEAD, true);
  }


  void OnDrawGizmos()
  {
    if (chaseRange > 0)
    {

      Gizmos.color = Color.cyan;
    }
    Gizmos.DrawWireSphere(transform.position, chaseRange);

  }
}
