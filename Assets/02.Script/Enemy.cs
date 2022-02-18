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
    public string enemyName { get; set; }
    public float enemyHealth { get; set; }
    public float enemyResist { get; set; }

    public Slider hpSlider;
    public void Initialize()
    {
        if (enemyNum == 1)
        {
            enemyName = "nature";
            enemyHealth = 1;
            enemyResist = 0.4f;
        }
        else if (enemyNum == 2)
        {
            enemyName = "ice";
            enemyHealth = 2;
            enemyResist = 0.5f;
        }
        else if (enemyNum == 3)
        {
            enemyName = "lava";
            enemyHealth = 2;
            enemyResist = 0.6f;
        }
        else if (enemyNum == 4)
        {
            enemyName = "desert";
            enemyHealth = 3;
            enemyResist = 0.7f;
        }
        else if (enemyNum == 5)
        {
            enemyName = "space";
            enemyHealth = 4;
            enemyResist = 0.7f;
        }
    }
    public void Damage(float damage)
    {
        enemyHealth -= damage;
        hpSlider.value -= damage;
        if (enemyHealth <= 0)
        {
            stageManager.GetComponent<ClearManager>().enemyDie(this.gameObject.name);
            //print(this.gameObject.name);
            enemyAnimation.GetComponent<EnemyAnimation>().SetActiveAllFalse();
            Destroy(this.gameObject, 10.0f);
        }
    }
    public void Resist(float resist)
    {
        physics.dynamicFriction = resist;
    }

    [SerializeField]
    private GameObject stageManager;
    private Component enemyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        physics = this.gameObject.GetComponent<Collider>().material;
        hpSlider.maxValue = enemyHealth;
        hpSlider.minValue = 0;
        hpSlider.value = hpSlider.maxValue;
        stageManager = GameObject.FindGameObjectWithTag("STAGEMANAGER");
        enemyAnimation = gameObject.GetComponent<EnemyAnimation>();
        Resist(enemyResist);
        //Damage(damage);
    }
}
