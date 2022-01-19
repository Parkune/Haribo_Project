using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IenemyStatus
{
    [SerializeField]
    private PhysicMaterial physics;

    public int enemyNum;
    public int damage = 1;
    public string enemyName{get; set;}
    public float enemyHealth{get; set;}
    public float enemyResist{get; set;}

    public Slider hpSlider;
    public void Initialize()
    {
        if(enemyNum == 1)
        {
            enemyName = "apple";
            enemyHealth = 1;
            enemyResist = 0.3f;
        } 
        else if(enemyNum == 2)
        {
            enemyName = "mellon";
            enemyHealth = 5;
            enemyResist =  0.8f;
        }
    }
    public void Damage(float damage)
    {
       enemyHealth -= damage;
       hpSlider.value -= damage;
       if(enemyHealth <= 0)
       {
            stageManager.GetComponent<ClearManager>().enemyDie(this.gameObject.name);
            print(this.gameObject.name);
           Destroy(this.gameObject, 0.8f);
       }
    }
    public void Resist(float resist)
    {
       //resist = enemyResist;
       physics.dynamicFriction = resist;
    }

    void Awake()
    {

    }
    [SerializeField]
    private GameObject stageManager;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        physics = this.gameObject.GetComponent<Collider>().material;
            hpSlider.maxValue = enemyHealth;
            hpSlider.minValue = 0;
            hpSlider.value = hpSlider.maxValue;
        stageManager = GameObject.FindGameObjectWithTag("STAGEMANAGER");
        
        Resist(enemyResist);
        //Damage(damage);
    }
}
