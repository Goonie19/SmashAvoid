using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{

    [SerializeField]private Transform target;
    [SerializeField]private Animator anima;
    [SerializeField] private Camera cam;

    public float smoothSpeed;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        anima = transform.GetChild(0).GetComponent<Animator>();
        cam = transform.GetChild(0).GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    public void playSpeedEffect()
    {

        anima.SetTrigger("SpeedUp");

        target.gameObject.GetComponent<AudioSource>().pitch = 0.6f;

        target.gameObject.GetComponent<AudioSource>().PlayOneShot(target.gameObject.GetComponent<PeonzaScript>().accelerate);

        target.gameObject.GetComponent<AudioSource>().pitch = 1f;


        cam.DOShakePosition(1f, 5)
            .SetEase(Ease.InQuad)
            .SetRelative().Play();

    }

}
