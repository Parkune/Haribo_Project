using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{


    public Dictionary<int, int> Ballct = new Dictionary<int, int>();
    public Dictionary<int, float> stageFrictionForce = new Dictionary<int, float>();
    public GameObject[] stage;
    public Transform spwanPosition;
    public int selectStageNum;
    public GameObject[] particle;
    Vector3 ballOriginPos;

    private void Awake()
    {
        AddData();
        FrictionForceData();

        //stageList[selectStageNum].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        selectStageNum = GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().StagrNum;
        print(selectStageNum);
        Instantiate(stage[selectStageNum], spwanPosition);
    }



    

    bool isBallExist;
   
    // Update is called once per frame
    void Update()
    {
/*        if (BallStart.instance.isBallActive == true)
        {
            print("RBVelocity");
            findBall();
        }*/
    }

/*    void findBall()
    {
        if (GameObject.Find("Ball(Clone)") == true)
        {
            //print("Game");
            Vector3 ballPos = GameObject.Find("Ball(Clone)").transform.position;
            ballOriginPos = ballPos;
            isBallExist = false;
            BallStart.instance.isBallActive = true;
        }
        else if (GameObject.Find("Ball(Clone)") == false && isBallExist == false)
        {
            //print("NonGame");
            Instantiate(particle[0], ballOriginPos, Quaternion.Euler(Vector3.zero));
            //print(ballOriginPos);
            isBallExist = true;
            BallStart.instance.isBallActive = false;
        }
    }*/
    void FrictionForceData()
    {
        stageFrictionForce.Add(0, 0.3f);
        stageFrictionForce.Add(1, 0.3f);
        stageFrictionForce.Add(2, 0.3f);
        stageFrictionForce.Add(3, 0.3f);
        stageFrictionForce.Add(4, 0.3f);
        stageFrictionForce.Add(5, 0.2f);
        stageFrictionForce.Add(6, 0.2f);
        stageFrictionForce.Add(7, 0.2f);
        stageFrictionForce.Add(8, 0.2f);
        stageFrictionForce.Add(9, 0.2f);
        stageFrictionForce.Add(10, 0.4f);
        stageFrictionForce.Add(11, 0.4f);
        stageFrictionForce.Add(12, 0.4f);
        stageFrictionForce.Add(13, 0.4f);
        stageFrictionForce.Add(14, 0.4f);
        stageFrictionForce.Add(15, 0.5f);
        stageFrictionForce.Add(16, 0.5f);
        stageFrictionForce.Add(17, 0.5f);
        stageFrictionForce.Add(18, 0.5f);
        stageFrictionForce.Add(19, 0.5f);
        stageFrictionForce.Add(20, 0.0f);
        stageFrictionForce.Add(21, 0.0f);
        stageFrictionForce.Add(22, 0.0f);
        stageFrictionForce.Add(23, 0.0f);
        stageFrictionForce.Add(24, 0.0f);
    }

    void AddData()
    {
        Ballct.Add(0, 3);
        Ballct.Add(1, 3);
        Ballct.Add(2, 3);
        Ballct.Add(3, 4);
        Ballct.Add(4, 3);
        Ballct.Add(5, 3);
        Ballct.Add(6, 3);
        Ballct.Add(7, 3);
        Ballct.Add(8, 4);
        Ballct.Add(9, 3);
        Ballct.Add(10, 4);
        Ballct.Add(11, 3);
        Ballct.Add(12, 4);
        Ballct.Add(13, 4);
        Ballct.Add(14, 5);
        Ballct.Add(15, 4);
        Ballct.Add(16, 4);
        Ballct.Add(17, 4);
        Ballct.Add(18, 3);
        Ballct.Add(19, 4);
        Ballct.Add(20, 5);
        Ballct.Add(21, 4);
        Ballct.Add(22, 5);
        Ballct.Add(23, 5);
        Ballct.Add(24, 10);
    }

}
