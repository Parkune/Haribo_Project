using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();
    public GameObject ClearPanel;
    [SerializeField]
    public GameObject[] enemys;
    // Start is called before the first frame update
    void Start()
    {
        ClearPanel.SetActive(false);
        findEnemy();
        for (int i = 0; i < enemys.Length; i++)
        {
            enemyList.Add(enemys[i]);
        }
    }
    void findEnemy()
    {
        enemys = GameObject.FindGameObjectsWithTag("ENEMY");
    }
    public void enemyDie(string enemyName)
    {
        //에너미가 죽으면 리스트의 오브젝트들을 비교한다.
        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemyList[i].name == enemyName)
            {
                
                enemyList.RemoveAt(i);
                
                if (enemyList.Count == 0)
                {
                    print("게임종료");
                    Time.timeScale = 0.01f;
                    ClearPanel.SetActive(true);
                    
                }
                Invoke("findEnemy", 0.9f);
                return;

            }
        
        }
        //내 이름과 리스트에 담긴 이름이 같다면 리스트에서 제거한다.

        //if 리스트의 카운트가 0이 되면 클리어를 프린트한다.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
