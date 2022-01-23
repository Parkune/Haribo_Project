using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playershooter : MonoBehaviour
{
    public GameObject whiteball;
    public Transform posin;
    public float speed = 5f;
    public Animator anim;



    //파워게이지를 제어하는 함수
    public float nowPower = 1;
    public float MaxPower = 30f;
    public float gageSpeed = 30f;
    public Slider PowerGage;

    public int stageNum = 1;
    public int ballLimit = 0;
    private StageManager stageManager;
    private UIManager uiManager;
    public bool turn;

    //조준선을 그리기 위한 함수
    [SerializeField]
    private LineRenderer lr;
    public float maxDistance = 40;
    public GameObject circleQuad;
    private void Awake()
    {
        stageManager = GameObject.FindGameObjectWithTag("STAGEMANAGER").GetComponent<StageManager>();
        stageManager.Ballct.TryGetValue(stageNum, out ballLimit);
        uiManager = GameObject.FindGameObjectWithTag("UIMANAGER").GetComponent<UIManager>();
        turn = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        nowPower = PowerGage.value;
        PowerGage.maxValue = MaxPower;
        PowerGage.minValue = 0;

        lr = posin.GetComponent<LineRenderer>();
        anim = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        float z = -PowerGage.value * Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad) / 3f;
        float x = PowerGage.value * Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad) / 3f;
        Ray ray;
        RaycastHit hitPoint;

        // print(v);
        if (turn == false)
        {
            return;
        }
        if (ballLimit == 0)
        {
            return;
        }
        posin.gameObject.SetActive(true);
        circleQuad.SetActive(true);
        lr.SetPosition(0, posin.position);
        if (Physics.Raycast(posin.position, posin.right, out hitPoint, maxDistance, 1))
        {
            if (hitPoint.transform.CompareTag("WALL"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (hitPoint.transform.CompareTag("JELLY"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (hitPoint.transform.CompareTag("ENEMY"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (hitPoint.transform.CompareTag("CUBE"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                circleQuad.transform.position = hitPoint.point;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
                lr.SetPosition(1, posin.position + posin.right * maxDistance);
            }
        }
        else
        {
            lr.SetPosition(1, posin.position + posin.right * maxDistance);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        if (Input.GetKey(KeyCode.Space))
        {

            // nowPower += MaxPower * Mathf.Sin(Time.time * speed);
            // PowerGage.value = nowPower;
            nowPower += Time.deltaTime*10;
            nowPower = Mathf.Clamp(nowPower, 0, 30);
            PowerGage.value = nowPower;
            anim.SetBool("Shooting", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject ball = Instantiate(whiteball, posin.position, Quaternion.Euler(Vector3.zero));
            ball.GetComponent<BallStart>().startVelocity = new Vector3(x, 0, z);
            PowerGage.value = PowerGage.minValue;
            ballLimit -= 1;
            uiManager.displayBallCT();
            turn = false;
            posin.gameObject.SetActive(false);
            circleQuad.SetActive(false);
            anim.SetBool("Shooting", false);
        }

    }

    IEnumerator powerCorutain()
    {
        if (PowerGage.value >= 1)
        {
            PowerGage.value = PowerGage.value = Mathf.Lerp(PowerGage.maxValue, PowerGage.value, PowerGage.minValue);
        }
        else if (PowerGage.value == 100)
        {
            PowerGage.value = PowerGage.value = Mathf.Lerp(PowerGage.minValue, PowerGage.value, PowerGage.maxValue);
        }

        PowerGage.value = Mathf.Lerp(PowerGage.minValue, PowerGage.value, PowerGage.maxValue);
        print(PowerGage.value);
        yield return new WaitForSeconds(0.2f);
    }


}
