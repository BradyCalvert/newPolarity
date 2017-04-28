using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootAI : StateMachineBehaviour {
  public GameObject agent;
  public GameObject player;
  public Transform target;
  public float shootForce;
  public float waitTime;
  public GameObject bullet;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    agent.GetComponent<NavMeshAgent>();
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    GameObject tempBullet = Instantiate(bullet, agent.transform.position, Quaternion.identity);
    tempBullet.transform.LookAt(player.transform);
    tempBullet.GetComponent<Rigidbody>().AddRelativeForce(tempBullet.transform.position * shootForce);
  }
}
