using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDisplayer : MonoBehaviour
{

    public AudioSource As;
    [SerializeField] private AudioClip dodge;


    // Start is called before the first frame update
    void Start()
    {
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            As.pitch = Random.Range(1f, 1.3f);
            As.PlayOneShot(dodge);
        }
    }

}
