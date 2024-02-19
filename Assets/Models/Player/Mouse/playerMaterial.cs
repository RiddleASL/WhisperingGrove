using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMaterial : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float offsetSpeed;

    void Start()
    {
        if(material == null) material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += new Vector2(offsetSpeed * Time.deltaTime, 0);
    }
}
