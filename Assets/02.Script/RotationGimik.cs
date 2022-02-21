using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGimik : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
    }
}
