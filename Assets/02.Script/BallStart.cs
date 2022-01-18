using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public Vector3 startVelocity = new Vector3(10f,0, 10f);
    public Vector3 velocity;
    public TurnManager turnManager;
    // Start is called before the first frame update
    [SerializeField]
    //private ParticleSystem ParticleSystem;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = startVelocity;
        turnManager = GameObject.FindGameObjectWithTag("TURNMANAGER").GetComponent<TurnManager>();
        turnManager.playerTurnOff();
    }

    void TurnOn()
    {
        turnManager.playerTurnOn();
        print("지금 턴온 합니다,");
    }

    public void zeroVelocity()
    {
        Invoke("TurnOn", 0.2f);
        Destroy(this.gameObject, 0.3f);
    }
    // Update is called once per frame

    private void FixedUpdate()
    {
        velocity = rb.velocity;
        if(Math.Abs(velocity.x) < 0.05f  && Math.Abs(velocity.y) < 0.05f)
        {
            Invoke("TurnOn", 3f);
            Destroy(this.gameObject, 3.1f);
        }
    }




    void Update()
    {

    }
}
