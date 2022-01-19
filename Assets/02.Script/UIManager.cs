using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Playershooter shooterScript;
    public Text displayBall;
    public GameObject timebtnon;
    public GameObject timebtnoff;
    public int displayBallCount
    {
        get { return shooterScript.ballLimit; }

        set { shooterScript.ballLimit = value; }
    }

    private void Awake()
    {
        
    }

    public void TimebtnOn()
    {
        timebtnon.SetActive(false);
        Time.timeScale = 2f;
        timebtnoff.SetActive(true);
    }
    public void TimebtnOff()
    {
        timebtnon.SetActive(true);
        Time.timeScale = 1f;
        timebtnoff.SetActive(false);
    }


    void Start()
    {
        shooterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>();
        int a = displayBallCount;
        displayBallCT();
        timebtnoff.SetActive(false);
        print(a);
        
    }

    public void displayBallCT()
    {
        displayBall.text = displayBallCount.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
