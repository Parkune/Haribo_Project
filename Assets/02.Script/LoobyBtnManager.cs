using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoobyBtnManager : MonoBehaviour
{
    public GameObject[] stageBtn;
    public Dictionary<int, bool> BtnDic = new Dictionary<int, bool>();
    // Start is called before the first frame update
    void Start()
    {

        // stageBtn = GameObject.FindGameObjectsWithTag("STAGEBUTTON");
        /* for (int i = 0; i < stageBtn.Length; i++)
         {
             stageBtn[i].GetComponent<BtnStageNum>().StageBtn(i);
         } */
       if (GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnEffectSound == false)
       { effectSoundToggle.isOn = false; } 

       if(GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound == false)
        { soundToggle.isOn = false; }
        stageClear();

    }

    public void stageClear()
    {
        colorChange(0);
        stageBtn[0].GetComponent<BtnStageNum>().isClear = true;

        if (DataController.Instance._gameData.isClear1_1 == true)
        {
            colorChange(1);
            stageBtn[1].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear1_2 == true)
        {
            colorChange(2);
            stageBtn[2].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear1_3 == true)
        {
            colorChange(3);
            stageBtn[3].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear1_4 == true)
        {
            colorChange(4);
            stageBtn[4].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear1_5 == true)
        {
            colorChange(5);
            stageBtn[5].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear2_1 == true)
        {
            colorChange(6);
            stageBtn[6].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear2_2 == true)
        {
            colorChange(7);
            stageBtn[7].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear2_3 == true)
        {
            colorChange(8);
            stageBtn[8].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear2_4 == true)
        {
            colorChange(9);
            stageBtn[9].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear2_5 == true)
        {
            colorChange(10);
            stageBtn[10].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear3_1 == true)
        {
            colorChange(11);
            stageBtn[11].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear3_2 == true)
        {
            colorChange(12);
            stageBtn[12].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear3_3 == true)
        {
            colorChange(13);
            stageBtn[13].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear3_4 == true)
        {
            colorChange(14);
            stageBtn[14].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear3_5 == true)
        {
            colorChange(15);
            stageBtn[15].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear4_1 == true)
        {
            colorChange(16);
            stageBtn[16].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear4_2 == true)
        {
            colorChange(17);
            stageBtn[17].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear4_3 == true)
        {
            colorChange(18);
            stageBtn[18].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear4_4 == true)
        {
            colorChange(19);
            stageBtn[19].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear4_5 == true)
        {
            colorChange(20);
            stageBtn[20].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear5_1 == true)
        {
            colorChange(21);
            stageBtn[21].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear5_2 == true)
        {
            colorChange(22);
            stageBtn[22].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear5_3 == true)
        {
            colorChange(23);
            stageBtn[23].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear5_4 == true)
        {
            colorChange(24);
            stageBtn[24].GetComponent<BtnStageNum>().isClear = true;
        }
        if (DataController.Instance._gameData.isClear5_5 == true)
        {
            colorChange(25);
            stageBtn[25].GetComponent<BtnStageNum>().isClear = true;
        }
    }
  

    void colorChange(int i)
    {
        ColorBlock cor = stageBtn[i].GetComponent<Button>().colors;
        cor.normalColor = Color.white;
        stageBtn[i].GetComponent<Button>().colors = cor;
    }

    public GameObject likeBtn;
    public GameObject characterBtn;
    public GameObject optionBtn;
    public GameObject exitBtn;
    public void LoobyUIControoler()
    {
        GameObject selectLoobyUIBtn = EventSystem.current.currentSelectedGameObject;
        print(selectLoobyUIBtn.name);
        int selectNum = selectLoobyUIBtn.GetComponent<OptionUISelectNum>().selectUInum;
        print(selectNum);
        if (selectNum == 2)
        {
            likeBtn.SetActive(true);
            UIexitBtn(characterBtn);
        }
        if (selectNum == 3)
        {
            likeBtn.SetActive(true);
            UIexitBtn(optionBtn);
        }
        if (selectNum == 4)
        {
            likeBtn.SetActive(true);
            UIexitBtn(exitBtn);
        }
    }
    public GameObject[] characterList;
    
    public void characterChangeBtn(int i)
    {
        characterList[0].SetActive(false);
        characterList[1].SetActive(false);
        characterList[2].SetActive(false);
        characterList[3].SetActive(false);
        characterList[i].SetActive(true);
    }
    public int characterSelectNum;
    public void characterChange()
    {
        GameObject selectCharacterBtn = EventSystem.current.currentSelectedGameObject;
        characterSelectNum = selectCharacterBtn.GetComponent<CharacterSelectNum>().characterBtnNum;
        characterChangeBtn(characterSelectNum);
        GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().characterNum = characterSelectNum;
    }
    public void UIexitBtn(GameObject Panel)
    {
        characterBtn.SetActive(false);
        optionBtn.SetActive(false);
        exitBtn.SetActive(false);
        Panel.SetActive(true);
    }
    public void ReturnLobby()
    {
        characterBtn.SetActive(false);
        optionBtn.SetActive(false);
        exitBtn.SetActive(false);
        likeBtn.SetActive(false);
    }


    public Toggle effectSoundToggle;
    public Toggle soundToggle;
    public void effectSoundOnToggle()
    {
        if(effectSoundToggle.isOn)
        {
            GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnEffectSound = true;
        } else
        {
            GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnEffectSound = false;
        }
  
    }

    public void soundOnToggle()
    {
        if (soundToggle.isOn)
        {
            GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound = true;
        }
        else
        {
            GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound = false;
        }
        print(GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound);
    }

    void StageClearData()
    {
        BtnDic.Add(1, DataController.Instance._gameData.isClear1_1);
        BtnDic.Add(2, DataController.Instance._gameData.isClear1_2);
        BtnDic.Add(3, DataController.Instance._gameData.isClear1_3);
        BtnDic.Add(4, DataController.Instance._gameData.isClear1_4);
        BtnDic.Add(5, DataController.Instance._gameData.isClear1_5);
        BtnDic.Add(6, DataController.Instance._gameData.isClear2_1);
        BtnDic.Add(7, DataController.Instance._gameData.isClear2_2);
        BtnDic.Add(8, DataController.Instance._gameData.isClear2_3);
        BtnDic.Add(9, DataController.Instance._gameData.isClear2_4);
        BtnDic.Add(10, DataController.Instance._gameData.isClear2_5);
        BtnDic.Add(11, DataController.Instance._gameData.isClear3_1);
        BtnDic.Add(12, DataController.Instance._gameData.isClear3_2);
        BtnDic.Add(13, DataController.Instance._gameData.isClear3_3);
        BtnDic.Add(14, DataController.Instance._gameData.isClear3_4);
        BtnDic.Add(15, DataController.Instance._gameData.isClear3_5);
        BtnDic.Add(16, DataController.Instance._gameData.isClear4_1);
        BtnDic.Add(17, DataController.Instance._gameData.isClear4_2);
        BtnDic.Add(18, DataController.Instance._gameData.isClear4_3);
        BtnDic.Add(19, DataController.Instance._gameData.isClear4_4);
        BtnDic.Add(20, DataController.Instance._gameData.isClear4_5);
        BtnDic.Add(21, DataController.Instance._gameData.isClear5_1);
        BtnDic.Add(22, DataController.Instance._gameData.isClear5_2);
        BtnDic.Add(23, DataController.Instance._gameData.isClear5_3);
        BtnDic.Add(24, DataController.Instance._gameData.isClear5_4);
        BtnDic.Add(25, DataController.Instance._gameData.isClear5_5);
        
    }

    public void extiGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }


}
