using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStart : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Vector3 startVelocity = new Vector3(0, 0, 0);
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = startVelocity;
    }

    // Update is called once per frame

//    private void FixedUpdate()
//    {
//        velocity = rb.velocity;
//    }

}
