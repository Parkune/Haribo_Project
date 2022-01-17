using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Playershooter shooterScript;
    public Text displayBall;

    public int displayBallCount
    {
        get { return shooterScript.ballLimit; }

        set { shooterScript.ballLimit = value; }
    }

    private void Awake()
    {

    }


    void Start()
    {
        shooterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>();
        int a = displayBallCount;
        displayBallCT();
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
