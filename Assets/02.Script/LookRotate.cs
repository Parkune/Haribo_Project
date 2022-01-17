using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookMouseCursor();
    
    }


    public void LookMouseCursor()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if(Physics.Raycast(ray, out hitResult))
        {
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            print(mouseDir);
            float rotateDegree = Mathf.Atan2(-hitResult.point.z, hitResult.point.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotateDegree, 0);

           
        }
    }
}

