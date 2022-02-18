using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoobyManager : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
        DataController.Instance.LoadGameData();
        Time.timeScale = 1f;
    }
}
