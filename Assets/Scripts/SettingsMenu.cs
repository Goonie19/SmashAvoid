﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void setGeneralVolume(float v)
    {
        audioMixer.SetFloat("GeneralVolume", Mathf.Log10(v) * 20);
    }

    public void setMusicVolume(float v)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(v) * 20);
    }

    public void setEffectVolume(float v)
    {
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(v) * 20);
    }

}
