using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    public int stage;
    public int ball;

    public Dictionary<int, int> Ballct = new Dictionary<int, int>();


    private void Awake()
    {
        AddData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddData()
    {
        Ballct.Add(1,3);
        Ballct.Add(2,3);
        Ballct.Add(3,3);
        Ballct.Add(4,5);
        Ballct.Add(5,5);
        Ballct.Add(6,3);
    }

}
