using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAutoSetting : MonoBehaviour
{

    public GameObject Stage;
    private void Awake()
    {
        Stage = GameObject.FindGameObjectWithTag("STAGE");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
