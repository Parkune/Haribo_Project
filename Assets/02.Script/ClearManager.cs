using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> enemyPos = new List<GameObject>();
    public GameObject ClearPanel;
    [SerializeField]
    public GameObject[] enemys;
    public Transform[] enemyParticles;
    public int selectStageNum;
    public GameObject[] particles;
    // Start is called before the first frame update
    void Start()
    {
        ClearPanel.SetActive(false);
        StartCoroutine("FindEnemy");
        selectStageNum = GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().StagrNum;
    }

    IEnumerator FindEnemy()
    {

        yield return new WaitForSeconds(0.8f);
        enemys = GameObject.FindGameObjectsWithTag("ENEMY");
        for (int i = 0; i < enemys.Length; i++)
        {
            enemyList.Add(enemys[i]);
        }
    }


    void findEnemy()
    {
        enemys = GameObject.FindGameObjectsWithTag("ENEMY");
        for (int i = 0; i < enemys.Length; i++)
        {
            enemyList.Add(enemys[i]);
        }
    }
    public void enemyDie(string enemyName)
    {

        //에너미가 죽으면 리스트의 오브젝트들을 비교한다.
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemyList[i].name == enemyName)
            {
                enemyList.RemoveAt(i);
                enemys = enemyList.ToArray();
                if (enemyList.Count == 0)
                {
                    print("게임종료");
                    Time.timeScale = 0.0001f;
                    ClearPanel.SetActive(true);
                    stageClear(selectStageNum);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>().turn = false;
                    DataController.Instance.SaveGameData();
                }
                return;

            }

        }
        //내 이름과 리스트에 담긴 이름이 같다면 리스트에서 제거한다.

        //if 리스트의 카운트가 0이 되면 클리어를 프린트한다.
    }

    public void stageClear(int selectStageNum)
    {

        if (selectStageNum == 0)
        {
            DataController.Instance._gameData.isClear1_1 = true;
        }
        if (selectStageNum == 1)
        {
            DataController.Instance._gameData.isClear1_2 = true;
        }
        if (selectStageNum == 2)
        {
            DataController.Instance._gameData.isClear1_3 = true;
        }
        if (selectStageNum == 3)
        {
            DataController.Instance._gameData.isClear1_4 = true;
        }
        if (selectStageNum == 4)
        {
            DataController.Instance._gameData.isClear1_5 = true;
        }
        if (selectStageNum == 5)
        {
            DataController.Instance._gameData.isClear2_1 = true;
        }
        if (selectStageNum == 6)
        {
            DataController.Instance._gameData.isClear2_2 = true;
        }
        if (selectStageNum == 7)
        {
            DataController.Instance._gameData.isClear2_3 = true;
        }
        if (selectStageNum == 8)
        {
            DataController.Instance._gameData.isClear2_4 = true;
        }
        if (selectStageNum == 9)
        {
            DataController.Instance._gameData.isClear2_5 = true;
        }
        if (selectStageNum == 10)
        {
            DataController.Instance._gameData.isClear3_1 = true;
        }
        if (selectStageNum == 11)
        {
            DataController.Instance._gameData.isClear3_2 = true;
        }
        if (selectStageNum == 12)
        {
            DataController.Instance._gameData.isClear3_3 = true;
        }
        if (selectStageNum == 13)
        {
            DataController.Instance._gameData.isClear3_4 = true;
        }
        if (selectStageNum == 14)
        {
            DataController.Instance._gameData.isClear3_5 = true;
        }
        if (selectStageNum == 15)
        {
            DataController.Instance._gameData.isClear4_1 = true;
        }
        if (selectStageNum == 16)
        {
            DataController.Instance._gameData.isClear4_2 = true;
        }
        if (selectStageNum == 17)
        {
            DataController.Instance._gameData.isClear4_3 = true;
        }
        if (selectStageNum == 18)
        {
            DataController.Instance._gameData.isClear4_4 = true;
        }
        if (selectStageNum == 19)
        {
            DataController.Instance._gameData.isClear4_5 = true;
        }
        if (selectStageNum == 20)
        {
            DataController.Instance._gameData.isClear5_1 = true;
        }
        if (selectStageNum == 21)
        {
            DataController.Instance._gameData.isClear5_2 = true;
        }
        if (selectStageNum == 22)
        {
            DataController.Instance._gameData.isClear5_3 = true;
        }
        if (selectStageNum == 23)
        {
            DataController.Instance._gameData.isClear5_4 = true;
        }
        if (selectStageNum == 24)
        {
            DataController.Instance._gameData.isClear5_5 = true;
        }
    }
}