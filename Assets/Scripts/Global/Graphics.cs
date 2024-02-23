using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graphics : MonoBehaviour
{
    int currentQuality;
    int maxParticles;

    // Start is called before the first frame update
    void Start()
    {
        currentQuality = QualitySettings.GetQualityLevel();
        maxParticles = 700;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentQuality);
        //max particles that can be rendered
        ParticleSystem[] systems = FindObjectsOfType<ParticleSystem>();
        foreach (ParticleSystem system in systems)
        {
            var main = system.main;
            main.maxParticles = maxParticles;
        }

        //lower the graphics quality
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (currentQuality > 0)
            {
                currentQuality--;
                QualitySettings.SetQualityLevel(currentQuality);
            }
            //decrease the max particles
            maxParticles -= 100;
        }

        //raise the graphics quality
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (currentQuality < 5)
            {
                currentQuality++;
                QualitySettings.SetQualityLevel(currentQuality);
            }
            maxParticles += 100;
        }

        //change the resolution
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Screen.SetResolution(1280, 720, true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Screen.SetResolution(800, 600, true);
        }
    }
}
