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
            enemyHealth = 3;
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
           Destroy(this.gameObject, 0.4f);
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
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        physics = this.gameObject.GetComponent<Collider>().material;
            hpSlider.maxValue = enemyHealth;
            hpSlider.minValue = 0;
            hpSlider.value = hpSlider.maxValue;

        
        Resist(enemyResist);
        //Damage(damage);
    }
}
