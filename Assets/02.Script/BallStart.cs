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
    public int stageNum =0;
    // Start is called before the first frame update
    
    public bool Copy;
    //private ParticleSystem ParticleSystem;

    [SerializeField]
    private AudioClip collisionSound;
    AudioSource audioSource;

    StageManager stageManager;
    
    private float frictionforce;
    private void Awake()
    {
        stageManager = GameObject.FindGameObjectWithTag("STAGEMANAGER").GetComponent<StageManager>();
        stageNum = stageManager.selectStageNum;
        stageManager.stageFrictionForce.TryGetValue(stageNum, out frictionforce);
    }
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.velocity = startVelocity;
        this.gameObject.GetComponent<Collider>().material.dynamicFriction = frictionforce;
        turnManager = GameObject.FindGameObjectWithTag("TURNMANAGER").GetComponent<TurnManager>();
        turnManager.playerTurnOff();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        if(GameObject.FindGameObjectWithTag("OPTIONOBJECT").GetComponent<SelectOptionManager>().isOnEffectSound == false)
        {
            audioSource.volume = 0;
        }
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

        /*        if (rb.velocity.x<0)
                {
                    rb.velocity = rb.velocity - rb.velocity * 0.02f * Time.deltaTime;
                    velocity = rb.velocity;

                }
                else if (rb.velocity.x>0)
                {
                    rb.velocity = velocity + rb.velocity * 0.02f * Time.deltaTime;
                    velocity = rb.velocity;
                }*/

        if (Math.Abs(velocity.x) < 0.05f  &&  Math.Abs(velocity.z) < 0.05f)
        {
            Invoke("TurnOn", 1.4f);
            Destroy(this.gameObject, 1.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.audioSource.Play();
    }

}
