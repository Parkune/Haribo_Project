using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //����Ű�� �翷����(Vertical)������ ĳ���Ͱ� �� �Ʒ��� �̵�
    //����Ű�� ���Ʒ��� (horizental)������ ĳ������ �߻� ������ ����


    [Range(-45,45)]
    public float yRotation = 0f;

    public float minRT = -45f;
    public float maxRT = 45f;
    

    public float rtationSpeed = 100f;

    public float zPosition = 0f;
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Transform tr = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

        zPosition += Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        transform.position = new Vector3(transform.position.x, 0, Mathf.Clamp(zPosition, -15, 15));
    }
    //ȸ���� �ٸ� ������� �����Ѵ�.
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

 

