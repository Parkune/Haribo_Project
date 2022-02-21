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
        StartCoroutine("SoundCheack");
    }
    
    IEnumerator SoundCheack()
    {
        yield return new WaitForSeconds(0.1f);
        if (GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound == false)
        {
            soundPlayer.volume = 0;
        }
    }

    void soundOff()
    {
        if (GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnSound == false)
        {
            soundPlayer.volume = 0;
        }
    }
}
