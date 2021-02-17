using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{



    public static MusicManager instance = null;

    public AudioSource As;

    public AudioClip MenuMusic;

    public AudioMixerSnapshot menuSnapshot, gameSnapshot;

    public AudioClip GameMusic;

    private void Start()
    {
        
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMenuMusic()
    {
        menuSnapshot.TransitionTo(1f);
    }

    public void PlayGameMusic()
    {
        gameSnapshot.TransitionTo(1f);
    }
}
