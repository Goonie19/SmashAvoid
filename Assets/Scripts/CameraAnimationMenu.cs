using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraAnimationMenu : MonoBehaviour
{

    public GameObject mainCanvas;

    public GameObject Sala;

    public MusicManager musicManager;

    public Transform playExit;
    public Transform exitExit;

    private void Start()
    {
        

    }

    public void playButton(string name)
    {

        Sala.GetComponent<MenuRotation>().enabled = false;

        Sequence camSeq = DOTween.Sequence();

        camSeq.Append(mainCanvas.GetComponent<CanvasGroup>().DOFade(0f, .5f).SetEase(Ease.InQuad));

        camSeq.Append(transform.DOLookAt(playExit.position, 2f).SetEase(Ease.InQuad));

        camSeq.Append(transform.DOMove(playExit.position, 2f).SetEase(Ease.InQuad));

        camSeq.Play();

        StartCoroutine(playScene(name));

    }

    public void ExitButton()
    {
        Sequence camSeq = DOTween.Sequence();

        camSeq.Append(mainCanvas.GetComponent<CanvasGroup>().DOFade(0f, .5f).SetEase(Ease.InQuad));

        camSeq.Append(transform.DOLookAt(exitExit.position, 2f).SetEase(Ease.InQuad));

        camSeq.Append(transform.DOMove(exitExit.position, 2f).SetEase(Ease.InQuad));

        PlaySceneManager.Exit();
    }
    

    IEnumerator playScene(string name)
    {


        yield return new WaitForSeconds(5f);

        mainCanvas.transform.GetChild(mainCanvas.transform.childCount -1).GetComponent<Animator>().SetBool("Change", true);


        musicManager.PlayGameMusic();


        DOTween.KillAll();
        PlaySceneManager.MainMenuButton(name);
        
    }
}
