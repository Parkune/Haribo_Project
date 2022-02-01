using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    Vector3 calculateReflect(Vector3 a, Vector3 z, Vector3 n)
    {
        Vector3 p = -Vector3.Dot(a, n) / n.magnitude * n / n.magnitude;
        Vector3 b = a + 2 * p;
        return b;
        //유니티의 내장함수 reflect와 동일한 효과를 지닌다.
    }

    GameObject stageManager;
    bool isBallActiveFalse;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BALL"))
        {

            other.transform.position = Vector3.Lerp(other.transform.position , new Vector3(0.5f,5, -5), Time.deltaTime);
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            ballRB.velocity = ballRB.velocity * 0;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>().turn = true;

            print("닿았다");

        } else if(other.CompareTag("ENEMY"))
        {
            Destroy(other.gameObject);
           stageManager = GameObject.FindGameObjectWithTag("STAGEMANAGER");
           stageManager.GetComponent<ClearManager>().enemyDie(other.gameObject.name);
        }
    }
}
