using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM_DicStageGM : MonoBehaviour
{
    // Start is called before the first frame update
    //��ͳѹ�,����̸�(�̰� �ʿ��ұ�? ��Ϳ����� ó���ϸ�Ǵ°� �ƴұ�?)
    public Dictionary<int, string> gimicDic = new Dictionary<int, string>();

    private void Awake()
    {
        addGimicData();
    }
    void addGimicData()
    {
        gimicDic.Add(1, "BigCube");
        gimicDic.Add(2, "SmallCube");
        gimicDic.Add(3, "SpeedUpCube");
        gimicDic.Add(4, "SpeedDownCube");
        gimicDic.Add(5, "BlackHoleCube");
        gimicDic.Add(6, "ShieldCube");
        gimicDic.Add(7, "HideCube");
        gimicDic.Add(8, "CrossBombCube");
    }
}
