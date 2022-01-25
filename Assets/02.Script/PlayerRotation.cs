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
        if(Application.platform == RuntimePlatform.WindowsEditor)
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
      
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        //print(target);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitResult;
        if (Physics.Raycast(ray, out hitResult))
        {
            if(hitResult.collider.gameObject.CompareTag("STAGE"))
            { 
                float dy = hitResult.point.z - oPosition.z;
                float dx = hitResult.point.x - oPosition.x;
                float rotateDegree = Mathf.Atan2(-dy, dx) * Mathf.Rad2Deg;
                rotateDegree = Mathf.Clamp(rotateDegree, -170, -20 );
                transform.rotation = Quaternion.Euler(0f, rotateDegree, 0);
            }
        }
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;
                Vector3 mPosition = new Vector3(touchPosition.x, touchPosition.y, 0);
                Vector3 oPosition = transform.position;

                mPosition.z = oPosition.x - Camera.main.transform.position.x;
                Ray ray = Camera.main.ScreenPointToRay(mPosition);
                RaycastHit hitResult;
                if (Physics.Raycast(ray, out hitResult))
                {
                    if (hitResult.collider.gameObject.CompareTag("STAGE"))
                    {
                        float dy = hitResult.point.z - oPosition.z;
                        float dx = hitResult.point.x - oPosition.x;
                        float rotateDegree = Mathf.Atan2(-dy, dx) * Mathf.Rad2Deg;
                        rotateDegree = Mathf.Clamp(rotateDegree, -170, -20);
                        transform.rotation = Quaternion.Euler(0f, rotateDegree, 0);
                    }
                }
            }
        }

            //다음은 아크탄젠트(arctan, 역탄젠트)로 게임 오브젝트의 좌표와 마우스 포인트의 좌표를
            //이용하여 각도를 구한 후, 오일러(Euler)회전 함수를 사용하여 게임 오브젝트를 회전시키기
            //위해, 각 축의 거리차를 구한 후 오일러 회전함수에 적용시킵니다.

            //우선 각 축의 거리를 계산하여, dy, dx에 저장해 둡니다.


            //오릴러 회전 함수를 0에서 180 또는 0에서 -180의 각도를 입력 받는데 반하여
            //(물론 270과 같은 값의 입력도 전혀 문제없습니다.) 아크탄젠트 Atan2()함수의 결과 값은
            //라디안 값(180도가 파이(3.141592654...)로)으로 출력되므로
            //라디안 값을 각도로 변화하기 위해 Rad2Deg를 곱해주어야 각도가 됩니다.


            //구해진 각도를 오일러 회전 함수에 적용하여 z축을 기준으로 게임 오브젝트를 회전시킵니다.

    }
}
