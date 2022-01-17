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
        //�ϴ��� ���� ������ �� �� ���� ������� ����.
        enemyTurn = false;
        playerST = GameObject.FindGameObjectWithTag("Player").GetComponent<Playershooter>();
    }
    // ��� 1. ũ������Ʈ�� ���� ���ν�Ƽ�� 0�̵� �� �� ģ������ ��ȣ�� ������.
    //         ���� �� �� �༮�� �� �Լ��� ������ �����Ѵ�.
    //         �÷��̾� ĳ���ʹ� �߻� �� �� ģ���� �����Ͽ� �߻� ���θ� �����Ѵ�.
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
        //���� ���ν�Ƽ 0�Ǿ��� �� �˷���!
    }
}
