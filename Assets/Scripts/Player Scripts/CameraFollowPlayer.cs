using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

  public GameObject player;
  public Vector3 thirdPerson = new Vector3(-1, 2, 2);

  private Vector3 offset;

  // Use this for initialization
  void Start()
  {
    //set offset to difference in camera position to the player position
    offset = transform.position - player.transform.position;
  }

  // Update is called once per frame
  void LateUpdate()
  {
    //set position to players position + offset

    transform.position = player.transform.position + offset;
    if (Input.GetKeyDown(KeyCode.C))
    {
      Camera.main.transform.position = player.transform.position + offset ;
    }
  }
}