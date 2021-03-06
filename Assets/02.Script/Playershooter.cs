using System;
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
    public float MaxPower = 50f;
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

        float z = -PowerGage.value * Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad);
        float x = PowerGage.value * Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad);
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
                //Vector3 newEndPoint = new Vector3(hitPoint.point.x, hitPoint.point.y + 1, hitPoint.point.z - 1);
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point/* + hitPoint.normal.normalized*/;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (hitPoint.transform.CompareTag("JELLY"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point/* + hitPoint.normal.normalized*/;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (hitPoint.transform.CompareTag("ENEMY"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point/* + hitPoint.normal.normalized*/;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (hitPoint.transform.CompareTag("CUBE"))
            {
                lr.SetPosition(1, hitPoint.point);
                circleQuad.transform.position = hitPoint.point/* + hitPoint.normal.normalized*/;
                circleQuad.transform.rotation = Quaternion.Euler(90, 0, 0);
            }
            else
            {
                circleQuad.transform.position = hitPoint.point/* + hitPoint.normal.normalized*/;
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
            anim.SetTrigger("Shoot");
        }
        if (Input.GetKey(KeyCode.Space))
        {

            

            // nowPower += MaxPower * Mathf.Sin(Time.time * speed);
           // StopCoroutine("powerCorutain");
           
            nowPower += Time.deltaTime * 20;
            nowPower = Mathf.Clamp(nowPower, 0, 40);
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
            PowerGage.value = 0;
            posin.gameObject.SetActive(false);
            circleQuad.SetActive(false);
            anim.SetBool("Shooting", false);

        }

    }

    public void PowerCharge()
    {
        if (turn == false)
        {
            return;
        }
        if (ballLimit == 0)
        {
            return;
        }

                     nowPower += Time.deltaTime * 20;
                     nowPower = Mathf.Clamp(nowPower, 0, 40);
                     PowerGage.value = nowPower;
                     anim.SetBool("Shooting", true);
    }
    public void Shooting()
    {
        if (turn == false)
        {
            return;
        }
        if (ballLimit == 0)
        {
            return;
        }
                    float z = -PowerGage.value * Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad);
                    float x = PowerGage.value * Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad);
                    GameObject ball = Instantiate(whiteball, posin.position, Quaternion.Euler(Vector3.zero));
                    ball.GetComponent<BallStart>().startVelocity = new Vector3(x, 0, z);
                    PowerGage.value = PowerGage.minValue;
                    ballLimit -= 1;
                    uiManager.displayBallCT();
                    turn = false;
                    PowerGage.value = 0;
                    posin.gameObject.SetActive(false);
                    circleQuad.SetActive(false);
                    anim.SetBool("Shooting", false);
    }




    IEnumerator powerCorutain()
    {


        yield return null;
    }


}
