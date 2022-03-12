using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public static ShowCharacter instance;
    public GameObject[] characterSkin;
    public int selectCharacterNum;
    public GameObject playerSelectWhile;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("showCharacter", 0.1f);
    }

    public void showCharacter()
    {
        selectCharacterNum = GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().characterNum;
        showCt(selectCharacterNum);
    }
    public void showCt(int num)
    {
        for (int i = 0; i < characterSkin.Length; i++)
        {
            characterSkin[i].SetActive(false);
        }
        characterSkin[num].SetActive(true);
    }
}
