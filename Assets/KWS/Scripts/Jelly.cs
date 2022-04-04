using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public GameObject plain;
    public GameObject pain;
    public ParticleSystem particle;
    private WaitForSeconds jellyPainDeley = new WaitForSeconds(0.3333f);


    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
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

    public void OnTriggerEnter(Collider other)
    {
            pain.SetActive(true);
            particle.Play();
            plain.SetActive(false);
            StartCoroutine("jellyPain");  
    }

    IEnumerator jellyPain()
    {
        yield return jellyPainDeley;
        pain.SetActive(false);
        plain.SetActive(true);
    }
}
