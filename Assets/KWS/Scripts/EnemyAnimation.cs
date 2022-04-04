using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject plain;
    public GameObject pain;
    public ParticleSystem particle;
    public ParticleSystem deathParticle;
    Collider collider;
    private Component enemy;
    private WaitForSeconds painDeley = new WaitForSeconds(0.3333f);

    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
        deathParticle.Stop();
        collider = gameObject.GetComponent<Collider>();
        enemy = gameObject.GetComponent<Enemy>();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("BALL") && 0 < enemy.GetComponent<Enemy>().enemyHealth)
        {
            pain.SetActive(true);
            particle.Play();
            plain.SetActive(false);
            StartCoroutine("jellyPain");
        }
    }


    IEnumerator jellyPain()
    {
        yield return painDeley;
        pain.SetActive(false);
        plain.SetActive(true);
    }


    public void SetActiveAllFalse()
    {
        pain.SetActive(false);
        plain.SetActive(false);
        collider.enabled = false;
        particle.Stop();
        deathParticle.Play();
    }
}
