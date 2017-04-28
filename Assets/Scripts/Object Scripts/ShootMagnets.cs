using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMagnets : MonoBehaviour
{
  public float bounce;
  public Material posMaterial;
  public Material negMaterial;
  public Material neutralMaterial;
  private MagnetManager magMan;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Positive"))
    {
      gameObject.GetComponent<Renderer>().material = posMaterial;
      gameObject.tag = "Positive2";
      Destroy(other.gameObject);
    }
    if (other.gameObject.CompareTag("Negative"))
    {
      gameObject.GetComponent<Renderer>().material = negMaterial;
      gameObject.tag = "Negative2";
      Destroy(other.gameObject);
    }
  }
  private void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.CompareTag("Positive2")&& gameObject.tag=="Negative2")
    {
      Destroy(col.gameObject);
      if (GameObject.FindGameObjectsWithTag("Positive2") == null)
      {
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(gameObject.transform.position, ForceMode.Impulse);
        gameObject.tag = "Untagged";
        gameObject.GetComponent<Renderer>().material.color = (Color.white);
      }
    }
  }
}
