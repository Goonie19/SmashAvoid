using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakePosition(1f, 4).SetLoops(-1).SetEase(Ease.Linear).Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
