using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAI : StateMachineBehaviour {
  public float moveSpeed;
  public GameObject agent;
  public bool alive = true;
  public Transform target;
  private PlayerMove speed;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    agent.GetComponent<NavMeshAgent>();
    moveSpeed = speed.walkSpeed + .5f;
  }


  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    if (alive == true)
    {
      agent.GetComponent<NavMeshAgent>().SetDestination(target.position * moveSpeed);
    }
  }

}
