using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject plain;
    public GameObject pain;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            pain.SetActive(true);
            plain.SetActive(false);
            StartCoroutine("jellyPain");
        }
    }


    IEnumerator jellyPain()
    {
        yield return new WaitForSeconds(1.5f);
        print("SSIPAL");
        pain.SetActive(false);
        plain.SetActive(true);
    }
}
