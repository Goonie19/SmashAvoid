using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeonzaScript : MonoBehaviour
{

    public Transform speedEffect;

    private AudioSource soundMaker;

    [SerializeField] private List<Transform> Roads;

    [SerializeField] private int actualTarget;


    [Header("AudioClips")]
    public AudioClip move;
    public AudioClip dodge;
    public AudioClip smash;
    public AudioClip accelerate;

    [Header("Crashed")]
    public bool crashed;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        soundMaker = GetComponent<AudioSource>();
        actualTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)  && actualTarget > 0)
        {
            --actualTarget;
            soundMaker.pitch = Random.Range(2, 2.5f);
            soundMaker.PlayOneShot(dodge);

        }
        if (Input.GetKeyDown(KeyCode.D)  && actualTarget < Roads.Count - 1)
        {
            ++actualTarget;
            soundMaker.pitch = Random.Range(2, 2.5f);
            soundMaker.PlayOneShot(dodge);

        }
       

        if (Vector3.Distance(Roads[actualTarget].position, transform.position) > 5)
        {
            transform.Translate((Roads[actualTarget].position - transform.position).normalized * Time.deltaTime * 400);
            speedEffect.transform.Translate((new Vector3(Roads[actualTarget].position.x, speedEffect.position.y, speedEffect.position.z) - speedEffect.position).normalized * Time.deltaTime * 400);
        } else
        {
            transform.position = Roads[actualTarget].position;
            speedEffect.position = new Vector3(Roads[actualTarget].position.x, speedEffect.position.y, speedEffect.position.z);
        }

    }

     public int getActualTarget()
    {
        return actualTarget;
    }

    public void setActualTarget(int i) {
        actualTarget = i;
    }

    public void Die()
    {
        crashed = true;
        explosion.transform.position = new Vector3(transform.position.x, explosion.transform.position.y, explosion.transform.position.z);
        explosion.Play();
        gameObject.SetActive(false);
    }

    
}
