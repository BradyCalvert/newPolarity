using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

  public float walkSpeed = 6f;
  public float jumpSpeed = 4f;
  public float runSpeed = 12f;
  public float gravity = 9.8f;
  public bool useGravity = true;


  Vector3 moveDirection = Vector3.zero;
  CharacterController charController;

  void Start()
  {
    charController = GetComponent<CharacterController>();

    LockCurser();

  }

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.R))
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    if (charController.isGrounded == true)
    {
      moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

      moveDirection = transform.TransformDirection(moveDirection);

      moveDirection *= GetSpeed();

      if (Input.GetButtonDown("Jump"))
      {
        moveDirection.y = jumpSpeed;
      }
      if (Input.GetKeyDown(KeyCode.C))
      {
        CrouchButton();
      }
    }

    if (useGravity == true)
    {
      moveDirection.y -= (gravity) * Time.deltaTime;
    }

    charController.Move(moveDirection * Time.deltaTime);

    if (Input.GetKeyDown(KeyCode.Escape))
    {
      LockCurser();
    }
  }

  float GetSpeed()
  {
    return walkSpeed;
  }
  void LockCurser()
  {
    if (Cursor.lockState == CursorLockMode.Locked)
    {
      Cursor.lockState = CursorLockMode.None;
    }
    else
    {

      Cursor.lockState = CursorLockMode.Locked;
    }
    Cursor.visible = !Cursor.visible;
  }
  void PauseButton()
  {

  }
  void CrouchButton()
  {
    if (charController.height != .0000001f)
    {
      charController.height = .0000001f;
    }
    else if (charController.height == .0000001f)
    {
      charController.height = 2f;
    }
  }
}
