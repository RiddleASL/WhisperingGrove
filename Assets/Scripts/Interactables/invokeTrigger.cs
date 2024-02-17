using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class invokeTrigger : MonoBehaviour
{
    [SerializeField] MonoBehaviour triggerScript;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            triggerScript.Invoke("Triggered", 0f);
        }
    }
}
