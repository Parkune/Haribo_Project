using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IenemyStatus
    {
        public string enemyName {get; set;}  

        public float enemyHealth {get; set;}

        public float enemyResist {get; set;}

        public void Initialize();

        public void Damage(float damage);
        
        public void Resist(float resist);
    }

public class EnemyStatus : MonoBehaviour
{


}
