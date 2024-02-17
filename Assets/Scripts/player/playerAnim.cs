using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] Animator anim;
    [SerializeField] playerMotor pm;
    playerType type;

    void Start(){
        if(anim == null) anim = GetComponent<Animator>();
        if(pm == null) pm = GameObject.Find("Player").GetComponent<playerMotor>();

        if (type == null) type = GameObject.Find("GlobalVariables").GetComponent<playerType>();
    }

    void Update(){
        resetBools();

        if(pm.getMove() != Vector3.zero && pm.getGroundCheck()){
            anim.SetBool("isWalking", true);
            anim.SetFloat("movementSpeed", (pm.currSpeed() - type.getSpeed(pm.currType()))/(type.getSprintSpeed(pm.currType()) - type.getSpeed(pm.currType())));
        }
        if(pm.getGroundCheck()){
            anim.SetBool("isGrounded", true);
        }
        if(pm.getMove() != Vector3.zero && pm.isSprinting()) anim.SetBool("isRunning", true);
        if(!pm.getGroundCheck()){
            anim.SetBool("isGrounded", false);
            anim.SetFloat("yVel", pm.getYVel());
        }
    }

    public void resetBools(){
        anim.SetBool("isWalking", false);
        anim.SetBool("isGrounded", false);
        anim.SetBool("isRunning", false);
    }
}
