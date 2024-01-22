using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerCam : MonoBehaviour
{
    [SerializeField] InputActionAsset actions;
    
    [SerializeField] Transform player;
    [SerializeField] float sensitivity = 100f;

    float rotX = 0f;
    float rotY = 0f;

    [SerializeField] float minClamp = 90f;
    [SerializeField] float maxClamp = -90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playerRot(InputAction.CallbackContext context){
        Vector2 input = context.ReadValue<Vector2>();
        rotX += input.x * sensitivity * Time.deltaTime;
        rotY += input.y * sensitivity * Time.deltaTime;

        rotY = Mathf.Clamp(rotY, maxClamp, minClamp);

        transform.localRotation = Quaternion.Euler(rotY, 0f, 0f);
        player.Rotate(Vector3.up * rotX);
    }
}
