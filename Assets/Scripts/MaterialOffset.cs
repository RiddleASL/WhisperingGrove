using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class MaterialOffset : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float offsetSpeed;
    [SerializeField] Vector2 offsetBools;

    void Start()
    {
        if (material == null) material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += new Vector2(offsetSpeed * Time.deltaTime * offsetBools.x, offsetSpeed * Time.deltaTime * offsetBools.y);
        material.SetVector("_mainTextureOffset", material.mainTextureOffset);
    }
}
