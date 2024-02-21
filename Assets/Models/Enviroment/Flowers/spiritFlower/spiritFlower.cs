using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritFlower : MonoBehaviour
{
    playerMotor pm;

    [SerializeField] private float spiritRadius = 30f;

    // Start is called before the first frame update
    void Start()
    {
        if(pm == null) pm = GameObject.Find("Player").GetComponent<playerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spiritRadius);
    }
}
