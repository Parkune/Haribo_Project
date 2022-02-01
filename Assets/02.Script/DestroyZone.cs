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
        //����Ƽ�� �����Լ� reflect�� ������ ȿ���� ���Ѵ�.
    }

    GameObject stageManager;
    bool isBallActiveFalse;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BALL"))
        {
            Destroy(other.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>().turn = true;
            print("��Ҵ�");
        } else if(other.CompareTag("ENEMY"))
        {
            Destroy(other.gameObject);
           stageManager = GameObject.FindGameObjectWithTag("STAGEMANAGER");
           stageManager.GetComponent<ClearManager>().enemyDie(other.gameObject.name);
        }
    }
}
