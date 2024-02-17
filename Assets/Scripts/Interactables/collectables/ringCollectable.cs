using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringCollectable : MonoBehaviour
{
    public List<ParticleSystem> particleSystems;
    [SerializeField] float destroyTimer;

    public void Triggered(){
        foreach (var system in particleSystems)
        {
            system.Stop();
        }

        Destroy(this.gameObject, destroyTimer);
    }
}
