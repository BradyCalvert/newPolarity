using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{

  public GameObject posBall;
  public GameObject negBall;
  public Transform posBarrel;
  public Transform negBarrel;
  public float shootForce = 10f;
  public GameObject gun;
  public int maxPosBullets = 10;
  public int posBullets;
  public Material posMaterial;
  public Material negMaterial;
  public float playerHealth = 10f;

  public void Start()
  {
  }
  void Update()
  {
    if (Input.GetMouseButtonDown(0)&& posBullets>0)
    {

      Ray rayOrigin = new Ray(posBarrel.position, posBarrel.transform.forward);
      GameObject tempBall = Instantiate(posBall, rayOrigin.origin, Quaternion.identity);
      Physics.IgnoreCollision(posBall.GetComponent<Collider>(), GetComponent<Collider>());
      tempBall.GetComponent<Rigidbody>().AddRelativeForce(rayOrigin.direction * shootForce, ForceMode.Impulse);
      posBullets--;
    }
    if (Input.GetMouseButtonDown(1) && GameObject.FindGameObjectWithTag("Positive2")==true)
    {
      Ray rayOrigin2 = new Ray(negBarrel.position, negBarrel.transform.forward);
      GameObject tempNegBall = Instantiate(negBall, rayOrigin2.origin, Quaternion.identity);
      Physics.IgnoreCollision(negBall.GetComponent<Collider>(), GetComponent<Collider>());
      Physics.IgnoreCollision(gun.GetComponent<Collider>(), GetComponent<Collider>());
      tempNegBall.GetComponent<Rigidbody>().AddRelativeForce(rayOrigin2.direction * shootForce, ForceMode.Impulse);
      posBullets = 10;
    }
      }
}
