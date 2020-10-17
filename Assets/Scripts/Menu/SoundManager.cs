using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundManager : MonoBehaviour
{
    public static bool mute;
    public AudioSource[] aSources;
    public float[] volumes;

    // Start is called before the first frame update
    void Start()
    {
        aSources = GameObject.FindObjectsOfType<AudioSource>();
        volumes = new float[aSources.Length];
        for(int i=0; i < volumes.Length; i++)
        {
            volumes[i] = aSources[i].volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressMuteButton()
    {
        if (mute)
        {
            mute = false;

            for (int i = 0; i < volumes.Length; i++)
            {
                aSources[i].volume = volumes[i];
            }

        }
        else
        {
            mute = true;
            for (int i = 0; i < volumes.Length; i++)
            {
                aSources[i].volume = 0;
            }
        }


    }


}
