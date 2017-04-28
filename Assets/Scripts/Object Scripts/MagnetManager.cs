using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetManager : MonoBehaviour
{
  public float duration = 1;
  public float bounceForce = 1;
  private GameObject[] posObj;

  void Update()
  {
        GameObject[] posObj = GameObject.FindGameObjectsWithTag("Positive2");

        if (posObj != null & GameObject.FindWithTag("Negative2") != null)
        {
            MoveObj(posObj);

        }

    }
  void MoveObj(GameObject[] objectsTocheck)
  {

        for (int i=0;i< objectsTocheck.Length;i++)
        {

            objectsTocheck[i].GetComponent<Rigidbody>().useGravity = false;
            objectsTocheck[i].transform.position =
            Vector3.Lerp(objectsTocheck[i].transform.position,
            (GameObject.FindWithTag("Negative2").transform.position), Time.deltaTime / duration);
        }
  }
}
