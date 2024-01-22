using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] Animator anim;
    [SerializeField] playerMotor pm;

    void Start(){
        if(anim == null) anim = GetComponent<Animator>();
        if(pm == null) pm = GameObject.Find("Player").GetComponent<playerMotor>();
    }

    void Update(){
        resetBools();

        if(pm.getMove() != Vector3.zero) anim.SetBool("isWalking", true);
        if(pm.getMove() != Vector3.zero && pm.isSprinting()) anim.SetBool("isRunning", true);
    }

    public void resetBools(){
        anim.SetBool("isWalking", false);
        anim.SetBool("isRunning", false);
    }
}
