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
                print(rotateDegree);
                rotateDegree = Mathf.Clamp(rotateDegree, -180, -90);
                transform.rotation = Quaternion.Euler(0f, rotateDegree, 0);
            }
        }

            //������ ��ũź��Ʈ(arctan, ��ź��Ʈ)�� ���� ������Ʈ�� ��ǥ�� ���콺 ����Ʈ�� ��ǥ��
            //�̿��Ͽ� ������ ���� ��, ���Ϸ�(Euler)ȸ�� �Լ��� ����Ͽ� ���� ������Ʈ�� ȸ����Ű��
            //����, �� ���� �Ÿ����� ���� �� ���Ϸ� ȸ���Լ��� �����ŵ�ϴ�.

            //�켱 �� ���� �Ÿ��� ����Ͽ�, dy, dx�� ������ �Ӵϴ�.
          

        //������ ȸ�� �Լ��� 0���� 180 �Ǵ� 0���� -180�� ������ �Է� �޴µ� ���Ͽ�
        //(���� 270�� ���� ���� �Էµ� ���� ���������ϴ�.) ��ũź��Ʈ Atan2()�Լ��� ��� ����
        //���� ��(180���� ����(3.141592654...)��)���� ��µǹǷ�
        //���� ���� ������ ��ȭ�ϱ� ���� Rad2Deg�� �����־�� ������ �˴ϴ�.
 

        //������ ������ ���Ϸ� ȸ�� �Լ��� �����Ͽ� z���� �������� ���� ������Ʈ�� ȸ����ŵ�ϴ�.
        
    }
}
