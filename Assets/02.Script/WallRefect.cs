using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRefect : MonoBehaviour
{
    Vector3 calculateReflect(Vector3 a ,Vector3 z ,Vector3 n)
    {
        Vector3 p = -Vector3.Dot(a, n) / n.magnitude * n / n.magnitude;
        Vector3 b = a+ new Vector3(0.1f, 0, 0.1f) + 2 * p;
        return b;
        //유니티의 내장함수 reflect와 동일한 효과를 지닌다.
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            /*            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
                        Vector3 velocity = collision.gameObject.GetComponent<BallStart>().velocity;
                        ballRB.velocity = calculateReflect(velocity, Vector3.zero, -collision.GetContact(0).normal);*/
            Vector3 velo = collision.gameObject.GetComponent<BallStart>().velocity;
            Vector3 trPosition = collision.gameObject.GetComponent<Transform>().position;
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            float speed = -velo.magnitude;
            Vector3 reflectVelocity = Vector3.Reflect(velo, collision.contacts[0].normal);
            rb.velocity = reflectVelocity * Mathf.Max(speed, 1f);

        }
        else if(collision.gameObject.CompareTag("ENEMY"))
        {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 velocity = collision.gameObject.GetComponent<EnemyStart>().velocity;
            ballRB.velocity = calculateReflect(velocity, Vector3.zero, -collision.GetContact(0).normal);
        }

    }
}
