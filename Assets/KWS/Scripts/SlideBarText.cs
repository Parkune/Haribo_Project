using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideBarText : MonoBehaviour
{

    public GameObject max;
    public GameObject mid;
    public GameObject min;
    // Start is called before the first frame update
    void Start()
    {
        min.SetActive(false);
        mid.SetActive(false);
        max.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangedValue(float value)
    {
        if (value <= 20 && value > 3)
        {
            min.SetActive(true);
        }
        else
        {
            min.SetActive(false);
        }
        if (value <= 30 && value > 20)
        {
            mid.SetActive(true);
        }
        else
        {
            mid.SetActive(false);
        }
        if (value <= 35 && value > 30)
        {
            max.SetActive(true);
        }
        else
        {
            max.SetActive(false);

        }
        //print(value);
    }
}
