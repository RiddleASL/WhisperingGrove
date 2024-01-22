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
    [SerializeField] float jumpForce = 2f;
    [SerializeField] float gravity = -9.81f;
    float currentSpeed;
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

    int playerType; // 0 = spririt, 1 = mouse, 2 = bird

    private void Start() {
        if(con == null) con = GetComponent<CharacterController>();
        if(type == null) type = GameObject.Find("GlobalVariables").GetComponent<playerType>();

        handlePlayerType();
        currentSpeed = defaultSpeed;
    }

    private void Update() {
        handlePlayerType();
        handleMovement();
        handleGFX();
        handleGravity();
    }

    void handlePlayerType(){
        switch(playerType){
            case 0:
                defaultSpeed = type.spiritSpeed;
                sprintSpeed = type.spiritSprintSpeed;
                break;
            case 1:
                defaultSpeed = type.mouseSpeed;
                sprintSpeed = type.mouseSprintSpeed;
                break;
            case 2:
                defaultSpeed = type.birdSpeed;
                sprintSpeed = type.birdSprintSpeed;
                break;
        }
    }

    void handleMovement(){
        Vector3 movement = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * move * currentSpeed;
        movement.y = yVel;
        
        con.Move(movement * Time.deltaTime);
    }

    void handleGravity(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if(isGrounded && yVel < 0){
            yVel = -2f;
        }
        yVel += gravity * Time.deltaTime;
    }

    void handleGFX(){
        if(move != Vector3.zero){
            Quaternion rot = Quaternion.LookRotation(Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * move);
            GFX.rotation = Quaternion.Slerp(GFX.rotation, rot, turnSpeed/10);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        move = new Vector3(input.x, 0, input.y);
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.performed){
            currentSpeed = sprintSpeed;
        }
        if(context.canceled){
            currentSpeed = defaultSpeed;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump");
        if(context.performed){
            if(isGrounded){
                yVel = jumpForce;
            }
        }
    }

    // Public functions
    public Vector3 getMove(){ return move; }
    public bool isSprinting(){ return currentSpeed == sprintSpeed; }
}
