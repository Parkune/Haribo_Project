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
        //먼저 계산을 위해 마우스와 게임 오브젝트의 현재의 좌표를 임시로 저장합니다.
        Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
        Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장

        //카메라가 앞면에서 뒤로 보고 있기 때문에, 마우스 position의 z축 정보에
        //게임 오브젝트와 카메라와의 z축의 차이를 입력시켜줘야 합니다.
        mPosition.z = oPosition.x - Camera.main.transform.position.x;
        /*      mPosition.z = oPosition.z - Camera.main.transform.position.z;
                mPosition.x = oPosition.x - Camera.main.transform.position.x;*/

        //화면의 픽셀별로 변화되는 마우스의 좌표를 유니티의 좌표로 변화해 줘야 합니다.
        //그래야, 위치를 찾아갈 수 있겠습니다.
    
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
