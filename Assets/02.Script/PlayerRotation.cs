using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerRotation : MonoBehaviour
{
    public float zPosition;
    public bool Left,Right;
    public float moveSpeed = 10f;
    public Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
        Mathf.Clamp(position.x, -2.75f, 2.75f) , this.transform.position.y, this.transform.position.z
        );
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform tr = this.gameObject.transform;
        zPosition = tr.transform.position.x;
        toAction = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
     
     
        UpdateForUnityEditor();

        
        //zPosition += Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        //zPosition =  Mathf.Clamp(zPosition, -2.5f, 2.5f);
    //    transform.position = new Vector3(zPosition, this.gameObject.transform.position.y, transform.position.z);

        toMove();

#else
        toMove();
          if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
	      {  
             return;
	      }
          UpdateForAndroid();
        

#endif
    }

    void UpdateForUnityEditor()
    {
        if(EventSystem.current.IsPointerOverGameObject())
	    {  
        return;
	         //Ŭ�� ó��
	    }
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

    public void toMove()
    {
        transform.localPosition = ClampPosition(transform.localPosition);
       
        if(Right)
        {
             transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if(Left)
        {
             transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

    }

    public void pressRightUp()
    {
        Invoke("toRight", 0.05f);
        print(Left + "����Ʈ�޽�");
    }
    void toRight()
    {
        Right = false;
    }
        public void pressRightDown()
    {
        Right = true;
        print(Left + "����ƮƮ��");
    }
        public void pressLeftUp()
    {
        Invoke("toLeft", 0.05f);
        print(Left + "����Ʈ�޽�");
    }
    void toLeft()
    {
        Left = false;
    }
    public void pressLeftDown()
    {
        Left = true;
        print(Left + "����Ʈ Ʈ��");
    }


bool isTouchDrag;
    Vector2 myTouchPos;
   public bool toAction;
    void UpdateForAndroid()
    {


            if (isTouchDrag)
            {
            Touch touch = Input.GetTouch(0);
                RaycastHit hitInfo;

                Ray ray = Camera.main.ScreenPointToRay(touch.position);

                if(Physics.Raycast(ray, out hitInfo, 500f))
                {
                    if (hitInfo.collider.gameObject.CompareTag("STAGE"))
                    {
                        Vector3 playerToMouse = hitInfo.point - this.transform.position;
                        playerToMouse.y = 0;
                        playerToMouse.Normalize();

                        transform.right = playerToMouse;
                    }
                }
            }

            if(toAction == false && Right == false && Left ==false)
            { 
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        isTouchDrag = true;
                        this.gameObject.GetComponent<Playershooter>().powerLimit();
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        this.gameObject.GetComponent<Playershooter>().PowerCharge();
                    }
                    else if (touch.phase == TouchPhase.Stationary)
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
}
