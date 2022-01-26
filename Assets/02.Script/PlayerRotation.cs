using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        UpdateForUnityEditor();
#else
        UpdateForAndroid();
#endif
    }

    void UpdateForUnityEditor()
    {
        //���� ����� ���� ���콺�� ���� ������Ʈ�� ������ ��ǥ�� �ӽ÷� �����մϴ�.
        Vector3 mPosition = Input.mousePosition; //���콺 ��ǥ ����
        Vector3 oPosition = transform.position; //���� ������Ʈ ��ǥ ����

        //ī�޶� �ո鿡�� �ڷ� ���� �ֱ� ������, ���콺 position�� z�� ������
        //���� ������Ʈ�� ī�޶���� z���� ���̸� �Է½������ �մϴ�.
        mPosition.z = oPosition.x - Camera.main.transform.position.x;
        /*      mPosition.z = oPosition.z - Camera.main.transform.position.z;
                mPosition.x = oPosition.x - Camera.main.transform.position.x;*/

        //ȭ���� �ȼ����� ��ȭ�Ǵ� ���콺�� ��ǥ�� ����Ƽ�� ��ǥ�� ��ȭ�� ��� �մϴ�.
        //�׷���, ��ġ�� ã�ư� �� �ְڽ��ϴ�.
    
        //Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        //print(target);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult))
        {
            if(hitResult.collider.gameObject.CompareTag("STAGE"))
            { 
                Vector3 playerToMouse = hitResult.point - this.transform.position;
                playerToMouse.y = 0;
                playerToMouse.Normalize();

                transform.right = playerToMouse ;
            }
        }

    }

bool isTouchDrag;
    Vector2 myTouchPos;
    void UpdateForAndroid()
    {
        if (isTouchDrag)
        {
            Touch touch = Input.GetTouch(0);
                RaycastHit hitInfo;

                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if(Physics.Raycast(ray, out hitInfo, 500f))
                {
                    Vector3 playerToMouse = hitInfo.point - this.transform.position;
                    playerToMouse.y = 0;
                    playerToMouse.Normalize();

                    transform.right = playerToMouse;
                }
        }

        if (Input.touchCount >  0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isTouchDrag = true;
                this.gameObject.GetComponent<Playershooter>().PowerCharge();
            }else if(touch.phase == TouchPhase.Moved)
            {
                this.gameObject.GetComponent<Playershooter>().PowerCharge();
            }else if(touch.phase == TouchPhase.Stationary)
            {
               this.gameObject.GetComponent<Playershooter>().PowerCharge();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isTouchDrag = false;
                this.gameObject.GetComponent<Playershooter>().Shooting();

            }
        }
    }
}
