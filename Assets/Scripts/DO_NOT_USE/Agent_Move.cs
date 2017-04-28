using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;

public class Agent_Move : MonoBehaviour {
  public float duration;
  public GameObject agent;
  public GameObject[] wayPoints = new GameObject[6];
  [HideInInspector]
  public int waypointID = 0;
  UnityEngine.Random random = new UnityEngine.Random();
  public bool alive = true;
  public GameObject target;
 

  public enum State

  {
    PATROL,
    CHASE
  }
  public State state;

  void Start()
  {
    agent.transform.position=new Vector3(-101.6f,2f,-48.1f);
    state = Agent_Move.State.PATROL;
    StartCoroutine("FSM");
  }
  IEnumerator FSM()
  {
    while (alive)
    {
      switch (state)
      {
        case State.PATROL:
          Patrol();
          break;
        case State.CHASE:
          Chase();
          break;

      }
      yield return null;
    }
  }

  void Patrol()
  {
      agent.GetComponent<NavMeshAgent>().SetDestination(wayPoints[waypointID].transform.position);
      if (waypointID > wayPoints.Length)
      {
        waypointID = 0;
      }
    
    else
    {
      MoveAgent(wayPoints[waypointID]);
    }
}
  /*
   *  void Patrol()
  {
    agent.GetComponent<NavMeshAgent>().SetDestination(wayPoints[waypointID].transform.position);
    if (waypointID > wayPoints.Length)
    {
      waypointID = 0;
    }

    else
    {
      MoveAgent(wayPoints[waypointID]);
    }
  }

   * */

  void Chase()
  {
    agent.GetComponent<NavMeshAgent>().SetDestination(GameObject.FindWithTag("Player").transform.position);
    MoveAgentChase(target);
    if(GameObject.FindWithTag("Player").transform.position==agent.transform.position+new Vector3(5,0,5))
    {
      state = Agent_Move.State.PATROL;
    }
    //agent.GetComponent<Material>()= gameObject.GetComponent<sho>

  }

  private void OnTriggerEnter(Collider other)
  {
   // (other.GetComponent<SphereCollider>() && (other.tag == "Player"))
    if (other.tag=="Positive")
    {
      state = Agent_Move.State.CHASE;
      target = GameObject.FindWithTag("Player");
    }
    else if (other.tag=="Waypoint")
    {
      waypointID += 1;    
    }
    else if (other.tag == "Waypoint"&& waypointID>wayPoints.Length)
    {
      waypointID =0;
    }
  }

  public void MoveAgent(GameObject wayPoint)
  {
    agent.transform.position= Vector3.Lerp(agent.transform.position,wayPoint.transform.position,Time.deltaTime/duration);
  }
  public void MoveAgentChase(GameObject target)
  {
    agent.transform.position = Vector3.Lerp(agent.transform.position, target.transform.position, Time.deltaTime /( duration-4f));
  }
}
