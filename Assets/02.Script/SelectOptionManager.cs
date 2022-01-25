using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectOptionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int StagrNum;
    public int characterNum = 0;
    public bool isOnSound = true;
    public bool isOnEffectSound = true;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SelectStageBtn()
    {
        GameObject clickBtn = EventSystem.current.currentSelectedGameObject;
        print(clickBtn.name);
        StagrNum = clickBtn.GetComponent<BtnStageNum>().stageNum;
        print(StagrNum);
        if (clickBtn.GetComponent<BtnStageNum>().isClear == true)
        {
            SceneManager.LoadScene("01Stage_Final");
        }
    }
    public void selectCharacter()
    {

    }
}
