using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;



public class PlaySceneManager : MonoBehaviour
{

    private int timeOfCallings;

    private Text count;
    private float timer;

    [Header("AssetsToActivate")]
    public GameObject peonza;
    public GameObject floor;
    public GameObject spawner;
    public GameObject cronom;

    [Header("AnimatorsToPlay")]
    public Animator fadeAnimator;
    public Animator RedScreenAnimator;

    [Header("Panels")]
    public GameObject CountDownPanel;
    public GameObject crashedPanel;

    [Header("Camera")]

    public AudioSource Ascamera;
    public AudioSource AScount;




    // Start is called before the first frame update
    void Start()
    {

        count = GetComponent<Text>();
        timer = 4f;

        

        StartCoroutine(countDown());
        Invoke("playCountDown", 0f);
        AScount.Play();
        Invoke("ActivateGame", 4f);

    }

    // Update is called once per frame
    void Update()
    {
        if(peonza.GetComponent<PeonzaScript>().crashed && timeOfCallings <= 0)
        {
            RedScreenAnimator.SetBool("crashed", true);
            Ascamera.pitch = 0.21f;
            playCrashAudio();

            Invoke("playCrashedAnimation", 1f);
            ++timeOfCallings;
            
        }

    }

    void ActivateGame()
    {
        peonza.SetActive(true);
        floor.GetComponent<FloorMovement>().enabled = true;
        spawner.SetActive(true);
        cronom.SetActive(true);
    }

    private void playCountDown()
    {

        Sequence countSeq = DOTween.Sequence();

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z), 1f).SetEase(Ease.InQuad));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z), 0.001f).SetEase(Ease.Linear));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z), 1f).SetEase(Ease.InQuad));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z), 0.001f).SetEase(Ease.Linear));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z), 1f).SetEase(Ease.InQuad));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z), 0.001f).SetEase(Ease.Linear));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z), 1f).SetEase(Ease.InQuad));

        countSeq.Append(CountDownPanel.transform.GetChild(0).DOScale(new Vector3(transform.localScale.x / 1.5f, transform.localScale.y / 1.5f, transform.localScale.z), 0.001f).SetEase(Ease.Linear));

        countSeq.Play();

    }

    IEnumerator countDown()
    {
        while(timer >0)
        {
            if(timer > 1)
            {
                switch(timer - 1)
                {
                    case 3: CountDownPanel.transform.GetChild(0).GetComponent<Text>().text = (timer - 1).ToString().Substring(0, 1) + "\n \n Move with \"A\" and \"D\" ";break;
                    case 2: CountDownPanel.transform.GetChild(0).GetComponent<Text>().text = (timer - 1).ToString().Substring(0, 1) + "\n \n Avoid the walls";break;
                    case 1: CountDownPanel.transform.GetChild(0).GetComponent<Text>().text = (timer - 1).ToString().Substring(0, 1) + "\n \n Good Luck ;)";break;
                }
            }
            else
            {
                CountDownPanel.transform.GetChild(0).GetComponent<Text>().text = "GO!";

                Invoke("deactivate", 1f);
            }

            timer -= 1;

            yield return new WaitForSeconds(1f);
        }
    }

    private void playCrashedAnimation()
    {


        crashedPanel.transform.GetChild(0).gameObject.SetActive(true);

        Sequence countSeq = DOTween.Sequence();

        Ascamera.pitch = 1f;

        Invoke("playCrashAudio", .5f);

        countSeq.Append(crashedPanel.transform.DOScale(new Vector3(099,099,0), .5f).SetEase(Ease.Linear).From());

        

        countSeq.Append(crashedPanel.transform.GetChild(0).GetChild(0).DOShakePosition(3f, 5).SetLoops(9999).SetEase(Ease.Linear));

        countSeq.Insert(.2f,crashedPanel.transform.GetChild(0).GetComponent<CanvasGroup>().DOFade(1F, 0.5f).SetEase(Ease.Linear));

        countSeq.Play();
    }

    void deactivate()
    {
        CountDownPanel.SetActive(false);

    }

    public void RetryButton() {

        DOTween.KillAll();

        StartCoroutine(Fade(SceneManager.GetActiveScene().name));


    }

    public void goToMain(string name)
    {

        GameObject.FindObjectOfType<MusicManager>().PlayMenuMusic();

        DOTween.KillAll();

        StartCoroutine(Fade(name));
    }

    IEnumerator Fade(string name)
    {
        fadeAnimator.SetBool("Change", true);

        yield return new WaitForSeconds(1f);

        MainMenuButton(name);

    }

    public static void MainMenuButton(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void Exit()
    {
        Application.Quit();
    }

    void playCrashAudio()
    {
        Ascamera.Play();
    }
}
