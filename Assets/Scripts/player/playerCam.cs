using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCam : MonoBehaviour
{    
    [Header("Dependancies")]
    [SerializeField] Transform player;
    [SerializeField] Transform playerCamera;
    [SerializeField] playerType type;
    playerMotor pm;
    int playerType;
    

    [Header("FOV")]
    [SerializeField] float normalFOV = 80;
    [SerializeField] float sprintFOV = 130;
    [SerializeField] float FOVLerpSpeed;

    [Header("Rotation Info")]
    [SerializeField] float sensitivity = 100f;
    float rotX = 0f;
    float rotY = 0f;
    [SerializeField] float minClamp = 90f;
    [SerializeField] float maxClamp = -90f;

    [Header("Location Info")]
    [SerializeField] float lerpSpeed = 2;

    void Start(){
        if(type == null) type = GameObject.Find("GlobalVariables").GetComponent<playerType>();
        pm = GameObject.Find("Player").GetComponent<playerMotor>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update(){
        playerType = player.GetComponent<playerMotor>().playerType;
        handleClamp();
        handleLocation();

        rotX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY += Input.GetAxis("Mouse X") * sensitivity;

        rotX = Mathf.Clamp(rotX, minClamp, maxClamp);

        transform.localRotation = Quaternion.Euler(rotX, rotY, 0f);
        playerCamera.localRotation = transform.localRotation;

        if(pm.isSprinting() && pm.getMove() != Vector3.zero){
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, sprintFOV, FOVLerpSpeed/100);
        } else {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, normalFOV, FOVLerpSpeed/100);
        }

    }
    
    void handleLocation(){
        Vector3 target = handleTargetLoc().position;

        RaycastHit hit;
        Vector3 rayDir = target - transform.position;
        float rayDist = Vector3.Distance(transform.position, target);
        if(Physics.Raycast(transform.position, rayDir.normalized, out hit, rayDist, pm.getGroundMask())){
            target = hit.point;
        }

        playerCamera.position = Vector3.Slerp(playerCamera.position, target, lerpSpeed/100);
    }

    Transform handleTargetLoc(){
        switch(playerType){
            case(0):
                lerpSpeed = 5f;
                return transform.Find("HardPositions").GetChild(0).transform;
            case(1):
                lerpSpeed = 10f;
                return transform.Find("HardPositions").GetChild(1).transform;
            default:
                lerpSpeed = 5f;
                return transform.Find("HardPositions").GetChild(0).transform;
        }
    }

    void handleClamp(){
        switch(playerType){
            case(0):
                minClamp = type.GetSpiritClamp(0);
                maxClamp = type.GetSpiritClamp(1);
                break;
            case(1):
                minClamp = type.GetMouseClamp(0);
                maxClamp = type.GetMouseClamp(1);
                break;
        }
    }
}
