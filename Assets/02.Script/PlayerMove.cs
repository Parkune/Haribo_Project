using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //방향키를 양옆으로(Vertical)누르면 캐릭터가 위 아래로 이동
    //방향키를 위아래로 (horizental)누르면 캐릭터의 발사 각도가 조절


    [Range(-45,45)]
    public float yRotation = 0f;

    public float minRT = -45f;
    public float maxRT = 45f;
    

    public float rtationSpeed = 100f;

    public float zPosition;
    public float moveSpeed = 10f;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        Transform tr = this.gameObject.transform;
        zPosition = tr.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        
        zPosition += Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        zPosition =  Mathf.Clamp(zPosition, 1, 7);
        transform.position = new Vector3(zPosition, this.gameObject.transform.position.y, transform.position.z);
    }
    //회전을 다른 방식으로 제어한다.
    /*        if (zPosition >= 12)
            {
                maxRT = 0;
            }
            else if (zPosition <= -12)
            {
                minRT = 0;
            }
            else
            {
                minRT = -45;
                maxRT = 45;
            }
                yRotation += Input.GetAxisRaw("Vertical") * Time.deltaTime * rtationSpeed;
                transform.eulerAngles = new Vector3(0, -Mathf.Clamp(yRotation, minRT, maxRT), 0);  
    */
}

 

