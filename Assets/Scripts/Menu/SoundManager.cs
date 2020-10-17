using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static bool mute;
    public AudioSource[] aSources;
    public float[] volumes;
    public static float volume=1;
    public static float savedVolume;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
    
        //DontDestroyOnLoad(GameObject.Find("BackgroundMusic"));
        aSources = GameObject.FindObjectsOfType<AudioSource>();
        volumes = new float[aSources.Length];
        for(int i=0; i < volumes.Length; i++)
        {
            volumes[i] = aSources[i].volume;
        }
        for (int i = 0; i < volumes.Length; i++)
        {
           // if (!aSources[i].gameObject.name.Equals("BackgroundMusic"))
            //{
                aSources[i].volume *= volume;
           // }
        }
        slider = GameObject.FindObjectOfType<Slider>();
        if (slider != null&&!mute)
        {
            slider.value = volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //slider = GameObject.FindObjectOfType<Slider>();
    }




    public void ChangeVolume()
    {
        Debug.Log("Change");
        volume = slider.value;
        for (int i = 0; i < volumes.Length; i++)
        {
            aSources[i].volume = volumes[i]* volume;
        }
    }

    public void PressMuteButton()
    {
        if (mute)
        {
            mute = false;
            volume = savedVolume;
            slider.value = volume;

            for (int i = 0; i < volumes.Length; i++)
            {
                aSources[i].volume = volumes[i]*volume;
            }

        }
        else
        {
            mute = true;
            savedVolume= volume;
            volume = 0;
            for (int i = 0; i < volumes.Length; i++)
            {
                aSources[i].volume = 0;
            }
        }


    }


}
