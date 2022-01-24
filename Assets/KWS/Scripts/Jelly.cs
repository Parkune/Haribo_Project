using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject plain;
    public GameObject pain;
    public ParticleSystem particle;


    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
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
            particle.Play();
            plain.SetActive(false);
            StartCoroutine("jellyPain");
        }
    }


    IEnumerator jellyPain()
    {
        yield return new WaitForSeconds(0.3333f);
        print("SSIPAL");
        pain.SetActive(false);
        plain.SetActive(true);
    }
}
