using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMotor : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] InputActionAsset actions;
    [SerializeField] CharacterController con;
    [SerializeField] playerType type;

    [Header("Global Movement")]
    [SerializeField] float defaultSpeed = 0f;
    [SerializeField] float sprintSpeed = 0f;
    [SerializeField] float accelSpeed = 0f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float gravMod = 2f;
    float currentSpeed;
    bool sprintCheck;
    Vector3 move;
    float yVel;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.4f;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    [Header("GFX")]
    [SerializeField] Transform GFX;
    [SerializeField] float turnSpeed = 1f;

    public int playerType; // 0 = spririt, 1 = mouse, 2 = bird

    private void Start()
    {
        if (con == null) con = GetComponent<CharacterController>();
        if (type == null) type = GameObject.Find("GlobalVariables").GetComponent<playerType>();

        handlePlayerType();
        currentSpeed = defaultSpeed;
    }

    private void Update()
    {
        handleMovement();
        handleAcceleration();
        handleGFX();
        handleGravity();
    }

    void handlePlayerType()
    {
        accelSpeed = type.getAccel(playerType);

        switch (playerType)
        {
            case 0:
                defaultSpeed = type.spiritSpeed;
                sprintSpeed = type.spiritSprintSpeed;
                break;
            case 1:
                defaultSpeed = type.mouseSpeed;
                sprintSpeed = type.mouseSprintSpeed;
                jumpForce = type.mouseJumpForce;
                break;
            case 2:
                defaultSpeed = type.birdSpeed;
                sprintSpeed = type.birdSprintSpeed;
                break;
        }

        //GFX Handle
        for (int i = 0; i < GFX.transform.childCount; i++)
        {
            if(i == playerType){
                GFX.transform.GetChild(i).gameObject.SetActive(true);
            } else{
                GFX.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    void handleMovement()
    {
        Quaternion camInfluence;
        Vector3 movement = new Vector3();
        if (playerType == 1)
        {
            camInfluence = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            movement = camInfluence * move * currentSpeed;
            movement.y = yVel;
        }
        else
        {
            camInfluence = Quaternion.Euler(Camera.main.transform.eulerAngles);
            movement = camInfluence * move * currentSpeed;
        }

        con.Move(movement * Time.deltaTime);
    }

    void handleAcceleration()
    {
        if (sprintCheck && move != Vector3.zero)
        {
            if (currentSpeed < sprintSpeed)
            {
                currentSpeed += accelSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (currentSpeed > defaultSpeed)
            {
                currentSpeed -= accelSpeed * 3 * Time.deltaTime;
            }
        }
    }

    void handleGravity()
    {
        if (playerType != 1) return;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (isGrounded && yVel < 0)
        {
            yVel = -2f;
        }
        yVel += gravity * gravMod * Time.deltaTime;
    }

    void handleGFX()
    {

        if (playerType != 0) GFX.transform.localPosition = new Vector3(0, 0, 0);
        else if (playerType == 0) GFX.transform.localPosition = new Vector3(0, (Mathf.Sin(Time.time * 5) / 2) + 1, 0);

        if (move != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * move);
            GFX.rotation = Quaternion.Slerp(GFX.rotation, rot, turnSpeed / 10);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        move = new Vector3(input.x, 0, input.y);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            sprintCheck = true;
        }
        if (context.canceled)
        {
            sprintCheck = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        if (context.performed)
        {
            if (isGrounded)
            {
                yVel = jumpForce;
            }
        }
    }

    // Public functions
    public Vector3 getMove() { return move; }
    public bool isSprinting() { return sprintCheck; }
    public bool getGroundCheck() { return isGrounded; }
    public float getYVel() { return yVel; }
    public LayerMask getGroundMask() { return groundMask; }
    public int currType() { return playerType; }
    public float currSpeed() { return currentSpeed; }
}
