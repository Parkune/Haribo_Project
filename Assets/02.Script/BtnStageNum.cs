using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnStageNum : MonoBehaviour
{
    // Start is called before the first frame update

    public int stageNum;
    public bool isClear;
    public void StageBtn(int i)
    {
        stageNum = i;
    }
}
