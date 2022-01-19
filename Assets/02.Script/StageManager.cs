using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{


    public Dictionary<int, int> Ballct = new Dictionary<int, int>();
    public Dictionary<int, float> stageFrictionForce = new Dictionary<int, float>();


    private void Awake()
    {
        AddData( );
        FrictionForceData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FrictionForceData()
    {
        stageFrictionForce.Add(1, 0.1f);
        stageFrictionForce.Add(2, 0.2f);
        stageFrictionForce.Add(3, 0.3f);
        stageFrictionForce.Add(4, 0.4f);
        stageFrictionForce.Add(5, 0.5f);
        stageFrictionForce.Add(6, 0.6f);
        stageFrictionForce.Add(7, 0.7f);
        stageFrictionForce.Add(8, 0.8f);
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
