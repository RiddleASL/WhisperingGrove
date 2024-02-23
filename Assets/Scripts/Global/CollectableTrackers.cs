using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectableTrackers : MonoBehaviour
{
    public int diamondCollectables;
    [SerializeField] TextMeshProUGUI diamondText;
    int totalDiamonds;

    public int ringCollectables;
    [SerializeField] TextMeshProUGUI ringText;
    int totalRings;

    [SerializeField] List<Transform> collectables; // 0 = diamond, 1 = ring

    // Start is called before the first frame update
    void Start()
    {
        getTotals();
        diamondCollectables = totalDiamonds;
        ringCollectables = totalRings;
    }

    // Update is called once per frame
    void Update()
    {
        diamondText.text = diamondCollectables + " / " + totalDiamonds;
        ringText.text = ringCollectables + " / " + totalRings;
    }

    public void removeCollectable(int collectableType)
    {
        if (collectableType == 0)
        {
            removeDiamond();
        }
        else if (collectableType == 1)
        {
            removeRing();
        }
    }

    public void removeDiamond()
    {
        diamondCollectables--;
    }

    public void removeRing()
    {
        ringCollectables--;
    }

    void getTotals()
    {
        totalDiamonds = collectables[0].childCount;
        totalRings = collectables[1].childCount;
    }
}
