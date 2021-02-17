using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleSpawner : MonoBehaviour
{

    private GameObject lastInstantiatedFloor;
    private GameObject lastInstantiatedObstacle;

    [Header("Pools")]
    public List<GameObject> floorAssets;
    [SerializeField] private List<Transform> Roads;
    [SerializeField] private List<GameObject> walls;

    [Header("Referencias")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;
    [SerializeField] private Text score;

    [Header("Cronometro")]
    [SerializeField]private float timer;
    [SerializeField]private float mark;
    public float speed;
    public Text crono;

    [Header("SpawnFrecuencies")]
    [SerializeField] private int[] frecuencyLeft;
    [SerializeField] private int[] frecuencyCenter;
    [SerializeField] private int[] frecuencyRight;
    private int index;



    // Start is called before the first frame update
    void Start()
    {
        lastInstantiatedFloor = GameObject.Find("Floor");

        player = GameObject.Find("Peonza");
        cam = GameObject.Find("Camera parent");

        
        lastInstantiatedObstacle = getFreeObjectWall();
        getFreeObjectWall().transform.rotation = transform.rotation;
        getFreeObjectWall().transform.position = new Vector3(Roads[2].position.x, Roads[2].position.y, transform.position.z);
        getFreeObjectWall().GetComponent<Obstacle>().speed = lastInstantiatedFloor.GetComponent<FloorMovement>().getSpeed();
        getFreeObjectWall().SetActive(true);



    }

    // Update is called once per frame
    void Update()
    {
        if (lastInstantiatedFloor.transform.position.z <= 1219)
        {
            lastInstantiatedFloor = getFreeObjectFloor();
            getFreeObjectFloor().transform.rotation = transform.rotation;
            getFreeObjectFloor().transform.position = transform.position  + new Vector3(66,0,1000);
            getFreeObjectFloor().SetActive(true);
            
        }

        if(lastInstantiatedObstacle.transform.position.z <= 300 )
        {
            int r1;
            r1 = Random.Range(0, 100);

            lastInstantiatedObstacle = getFreeObjectWall();
            lastInstantiatedObstacle.transform.rotation = transform.rotation;
            lastInstantiatedObstacle.GetComponent<Obstacle>().speed = lastInstantiatedFloor.GetComponent<FloorMovement>().getSpeed();
            if (index < 2)
                ++index;
            else
                index = 0;
            

            if (player.GetComponent<PeonzaScript>().getActualTarget() == 0)
            {

                lastInstantiatedObstacle.transform.position = new Vector3(Roads[frecuencyLeft[index]].position.x, Roads[frecuencyLeft[index]].position.y, transform.position.z);
                lastInstantiatedObstacle.SetActive(true);

            } else
            {
                if (player.GetComponent<PeonzaScript>().getActualTarget() == 2)
                {

                    lastInstantiatedObstacle.transform.position = new Vector3(Roads[frecuencyRight[index]].position.x, Roads[frecuencyRight[index]].position.y, transform.position.z);

                    lastInstantiatedObstacle.SetActive(true);
                } else
                {
                    lastInstantiatedObstacle.transform.position = new Vector3(Roads[frecuencyCenter[index]].position.x, Roads[frecuencyCenter[index]].position.y, transform.position.z);

                    lastInstantiatedObstacle.SetActive(true);
                }

            }
            if (index < 2)
                ++index;
            else
                index = 0;
        }

        playTimer();

        accelerate();
    }

    public GameObject getFreeObjectFloor()
    {
        return floorAssets.Find(item => item.activeInHierarchy == false);
    }


    public GameObject getFreeObjectWall()
    {
        return walls.Find(item => item.activeInHierarchy == false);
    }

    public void accelerate()
    {
        if (timer - mark >= 15)
        {
            mark = timer;
            speed = Mathf.Sqrt(speed);
            cam.GetComponent<CameraMove>().playSpeedEffect();

            lastInstantiatedFloor.GetComponent<FloorMovement>().addSpeed(speed - 1);

        }
    }

    void playTimer()
    {
        if (!player.GetComponent<PeonzaScript>().crashed)
        {
            timer += Time.deltaTime;

            if (timer > 10)
                crono.text = timer.ToString().Substring(0, 5);
            else
                crono.text = timer.ToString().Substring(0, 4);


            score.text = "Your time was:\n \n" + crono.text + " s";
        } else
        {
            timer = 0f;
        }

    }
}
