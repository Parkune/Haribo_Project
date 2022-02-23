using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Playershooter shooterScript;
    public Text displayBall;
    public GameObject timebtnon;
    public GameObject timebtnoff;
    public GameObject loobyBtn;
    public int displayBallCount
    {
        get { return shooterScript.ballLimit; }

        set { shooterScript.ballLimit = value; }
    }

    public void TimebtnOn()
    {
        timebtnon.SetActive(false);
        rotationScript.toAction = true;
        Time.timeScale = 2f;
        timebtnoff.SetActive(true);
        Invoke("toActions", 0.001f);
    }
    public void toActions()
    {
        rotationScript.toAction = false;
    }

    public void TimebtnOff()
    {
        timebtnon.SetActive(true);
        Time.timeScale = 1f;
        rotationScript.toAction = true;
        timebtnoff.SetActive(false);
        Invoke("toActions", 0.01f);
    }

    public GameObject player;
    public PlayerRotation rotationScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shooterScript = player.GetComponent<Playershooter>();
        rotationScript = player.GetComponent<PlayerRotation>();
        // int a = displayBallCount;
        timebtnoff.SetActive(false);
        stopMenuUI.SetActive(false);
        fairUI.SetActive(false);
        Time.timeScale = 1f;
        Invoke("displayBallCT",0.2f);
        System.GC.Collect();
#if UNITY_EDITOR

#else
        Application.targetFrameRate = 60;
        System.GC.Collect();
#endif
    }

    public void ReturnGame()
    {
        Time.timeScale = 1f;
        stopMenuUI.SetActive(false);
        Invoke("toActions", 0.05f);
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("LOOBY");
    }

    public GameObject stopMenuUI;
    public void stopButton()
    {
        Time.timeScale = 0f;
        stopMenuUI.SetActive(true);
        rotationScript.toAction = true;
    } 

    public GameObject fairUI;
    public void failButton()
    {
        Time.timeScale = 0f;
        fairUI.SetActive(true);
        rotationScript.toAction = true;
    }
    public void displayBallCT()
    {
        displayBall.text = displayBallCount.ToString();
    }
    public void OnRetry()
    {
        // 현재 씬 다시 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnLooby()
    {
        SceneManager.LoadScene("LOBBY");
    }
    float rotinTime = 0;
    // Update is called once per frame
    void Update()
    {
        if(displayBallCount == 0)
        {
            rotinTime += Time.deltaTime;
           
            if(rotinTime > 3f)
            {
                if(GameObject.FindGameObjectWithTag("BALL") == null)
                {
                   failButton();
                }
                rotinTime = 0;
            }
        }
    }
}
