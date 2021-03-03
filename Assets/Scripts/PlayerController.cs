using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private CharacterController PlayerCon;
    private float movX, movZ, speed = 0.1f, gravity = -19.81f, jumpSpeed = 8f;
    private Vector3 xzMove, yMove;
    bool isSprinting = false;
    public static bool isCrouching = false;
    public UnityEvent OnSpacePressed, OnShiftKeepPressed, OnShiftReleased, OnCtrlKeepPressed, OnCtrlReleased;
    void Start()
    { 
        PlayerCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) OnSpacePressed?.Invoke();
        if (Input.GetKey(KeyCode.LeftShift)) OnShiftKeepPressed?.Invoke();
        if (Input.GetKeyUp(KeyCode.LeftShift)) OnShiftReleased?.Invoke();
        if (Input.GetKey(KeyCode.LeftControl)) OnCtrlKeepPressed?.Invoke();
        if (Input.GetKeyUp(KeyCode.LeftControl)) OnCtrlReleased?.Invoke();
    }
    void FixedUpdate()
    {
        MoveInAxis();
        Gravity();
    }

    private void MoveInAxis()
    {
        if (isSprinting) speed = 0.2f;
        else speed = 0.1f;

        movX = Input.GetAxisRaw("Horizontal");
        movZ = Input.GetAxisRaw("Vertical");
        xzMove = (transform.right * movX + transform.forward * movZ).normalized;

        PlayerCon.Move(xzMove * speed);
    }
    private void Gravity()
    {
        yMove.y += gravity * Time.deltaTime;
        PlayerCon.Move(yMove * Time.deltaTime);
        if (PlayerCon.isGrounded && yMove.y < 0) yMove.y = 0; 
    }

    #region EVENTS_METHODS
    public void Jump() 
    {
        if (PlayerCon.isGrounded)
        {
            yMove.y = jumpSpeed;            
        }
    }
    public void Sprint() 
    {
        isSprinting = true;
    }
    public void Walk()
    {
        isSprinting = false;
    }
    public void Crouch() 
    {
        isCrouching = true;
    }
    public void Stand() 
    {
        isCrouching = false;
    }
    #endregion

}
