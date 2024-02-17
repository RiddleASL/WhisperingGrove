using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalCollectable : MonoBehaviour
{
    public List<GameObject> hideOnTrigger;
    public List<GameObject> showOnTrigger;
    public float destroyTimer;

    public void Triggered()
    {
        if (hideOnTrigger.Count != 0)
        {
            foreach (var obj in hideOnTrigger)
            {
                obj.SetActive(false);
            }
        }

        if (showOnTrigger.Count != 0)
        {
            foreach (var obj in showOnTrigger)
            {
                obj.SetActive(true);
            }
        }

        Destroy(this.gameObject, destroyTimer);
    }
}
