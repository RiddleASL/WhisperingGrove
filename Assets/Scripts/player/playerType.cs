using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class playerType : MonoBehaviour
{
    [Header("Debug Type")]
    int debugType = 0;

    public float getAccel(int parm){
        switch(parm){
            case(0):
                return 10;
            case(1):
                return 5;
            default:
                return 10;
        }
    }

    [Header("Spirit")]
    public float spiritSpeed = 5;
    public float spiritSprintSpeed = 10;

    public float spiritConHeight = 1f;
    public float spiritConRadius = 0.5f;
    public Vector3 spiritConCenter = new Vector3(0, 1f, 0);

    public float GetSpiritClamp(int parm){
        switch(parm){
            case(0):
                return -90;
            case(1):
                return 90;
            default:
                return 0;
        }
    }

    [Header("Mouse")]
    public float mouseSpeed = 6;
    public float mouseSprintSpeed = 12;
    public float mouseJumpForce = 20;

    public float mouseConHeight = 2f;
    public float mouseConRadius = 0.5f;
    public Vector3 mouseConCenter = new Vector3(0, 1f, .5f);

    public float GetMouseClamp(int parm){
        switch(parm){
            case(0):
                return -35;
            case(1):
                return 25;
            default:
                return 0;
        }
    }

    [Header("Bird")]
    public float birdSpeed = 10f;
    public float birdSprintSpeed = 20f;
    
    public float birdConHeight = 2f;
    public float birdConRadius = 0.5f;
    public Vector3 birdConCenter = new Vector3(0, 1f, 0);

    //Public Functions

    public float getSpeed(int parm){
        switch(parm){
            case(0):
                return spiritSpeed;
            case(1):
                return mouseSpeed;
            default:
                return spiritSpeed;
        }
    }

    public float getSprintSpeed(int parm){
        switch(parm){
            case(0):
                return spiritSprintSpeed;
            case(1):
                return mouseSprintSpeed;
            default:
                return spiritSprintSpeed;
        }
    }
}
