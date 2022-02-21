using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnStageNum : MonoBehaviour
{
    // Start is called before the first frame update

    public int stageNum;
    public bool isClear;
    private Button btn;
  
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => IT());
    }
    public void IT()
    {
        GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().SelectStageBtn();
    }
    public void StageBtn(int i)
    {
        stageNum = i;
    }
}
