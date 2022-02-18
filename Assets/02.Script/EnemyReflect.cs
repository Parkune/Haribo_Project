using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReflect : MonoBehaviour
{
    (Vector3, Vector3) calculateBall2BallColision(Vector3 v1, Vector3 v2, Vector2 c1, Vector2 c2, float e = 1f)
    {
        Vector2 basisX = (c2 - c1).normalized;
        Vector2 basisY = Vector2.Perpendicular(basisX);
        float sin1, sin2, cos1, cos2;
        if (v1.magnitude < 0.0001f)
        {
            sin1 = 0;
            cos1 = 1;
        }
        else
        {
            cos1 = Vector2.Dot(v1, basisX) / v1.magnitude;
            Vector3 Cross = Vector3.Cross(v1, basisX);
            if (Cross.z > 0)
            {
                sin1 = Cross.magnitude / v1.magnitude;
            }
            else
            {
                sin1 = -Cross.magnitude / v1.magnitude;
            }
        }

        if (v2.magnitude > 0.0001f)
        {
            sin2 = 0;
            cos2 = 1;

        }
        else
        {
            cos2 = Vector2.Dot(v2, basisX) / v2.magnitude;
            Vector3 Cross = Vector3.Cross(v2, basisX);
            if (Cross.z > 0)
            {
                sin2 = Cross.magnitude / v2.magnitude;
            }
            else
            {
                sin2 = -Cross.magnitude / v2.magnitude;
            }
        }
        Vector3 u1, u2;
        u1 = ((1 - e) * v1.magnitude * cos1 + (1 + e) * v2.magnitude * cos2) / 2 * basisX - v1.magnitude * sin1 * basisY;
        u2 = ((1 + e) * v1.magnitude * cos1 + (1 - e) * v2.magnitude * cos2) / 2 * basisX - v2.magnitude * sin1 * basisY;

        return (u1, u2);
    }

    (Vector2, Vector2) calculateBall2BallColisionSimple(Vector2 V1, Vector2 V2)
    {
        return (V2, V1);
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            Rigidbody2D ballMeRb = this.gameObject.GetComponent<Rigidbody2D>();
            Rigidbody2D ballOtherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector3 v1 = this.gameObject.GetComponent<BallStart>().velocity;
            Vector3 v2 = collision.gameObject.GetComponent<BallStart>().velocity;
            (ballMeRb.velocity, ballOtherRb.velocity) = calculateBall2BallColision(v1, v2, ballMeRb.position, ballOtherRb.position);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            this.gameObject.GetComponent<Enemy>().Damage(1);
        }
    }


}
