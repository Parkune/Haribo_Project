using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private bool playerTurn;

    private bool enemyTurn;


    [SerializeField]
    private Playershooter playerST;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        //일단은 좋은 생각이 날 때 까지 사용하지 말자.
        enemyTurn = false;
        playerST = GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>();
    }
    // 방법 1. 크리에이트한 볼은 벨로시티가 0이될 때 이 친구에게 신호를 보낸다.
    //         몇초 후 이 녀석은 턴 함수를 온으로 변경한다.
    //         플레이어 캐릭터는 발사 시 이 친구를 참조하여 발사 여부를 결정한다.
    //
    public void playerTurnOn()
    {
        playerTurn = true;
        playerST.turn = true;
    }
    public void playerTurnOff()
    {
        playerTurn = false;
        playerST.turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //볼이 벨로시티 0되었을 때 알려줘!
    }
}
