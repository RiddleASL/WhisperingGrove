using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerType : MonoBehaviour
{
    [Header("Debug Type")]
    int debugType = 0;

    [Header("Spirit")]
    public float spiritSpeed = 15;
    public float spiritSprintSpeed = 25;

    public float spiritConHeight = 1f;
    public float spiritConRadius = 0.5f;
    public Vector3 spiritConCenter = new Vector3(0, 1f, 0);

    [Header("Mouse")]
    public float mouseSpeed = 6;
    public float mouseSprintSpeed = 12;

    public float mouseConHeight = 2f;
    public float mouseConRadius = 0.5f;
    public Vector3 mouseConCenter = new Vector3(0, 1f, .5f);

    [Header("Bird")]
    public float birdSpeed = 10f;
    public float birdSprintSpeed = 20f;
    
    public float birdConHeight = 2f;
    public float birdConRadius = 0.5f;
    public Vector3 birdConCenter = new Vector3(0, 1f, 0);
}
