using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public AudioSource soundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        Invoke("soundOff", 0.1f);
    }

    void soundOff()
    {
        if (GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound == false)
        {
            soundPlayer.volume = 0;
        }
    }
}
