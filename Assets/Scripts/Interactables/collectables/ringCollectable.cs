using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringCollectable : MonoBehaviour
{
    public List<ParticleSystem> particleSystems;
    [SerializeField] float destroyTimer;
    bool trigger;

    public void Triggered(){
        foreach (var system in particleSystems)
        {
            system.Stop();
        }

        if (!trigger){
            trigger = true;        
            GameObject.FindGameObjectWithTag("Collectables").GetComponent<CollectableTrackers>().removeCollectable(1);
        }
        Destroy(this.gameObject, destroyTimer);
    }
}
