using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : StateMachineBehaviour {
  public float duration;
  public GameObject agent;
  public GameObject[] wayPoints = new GameObject[6];
  [HideInInspector]
  public int waypointID = 0;
  UnityEngine.Random random = new UnityEngine.Random();
  public bool alive = true;
  private AIController naveMeshController;

  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    naveMeshController.GetComponent<NavMeshAgent>();
  }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    if (alive == true)
    {
      if (waypointID <= wayPoints.Length - 1)
      {
        agent.transform.LookAt(wayPoints[waypointID].transform);
        agent.GetComponent<NavMeshAgent>().SetDestination(wayPoints[waypointID].transform.position);
      }
      else if (waypointID > wayPoints.Length - 1)
      {
        waypointID = 0;
      }
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Waypoint" && waypointID <= wayPoints.Length)
    {
      waypointID += 1;
      Debug.Log(waypointID);

      if (waypointID > wayPoints.Length)
      {
        waypointID = 0;
      }
    }
  }
}
