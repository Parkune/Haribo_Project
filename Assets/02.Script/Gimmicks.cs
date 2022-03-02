using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmicks : MonoBehaviour
{

    public int GimmickNum;
    public SM_DicStageGM GimmickManager;
    public GameObject CopyBall;

    [SerializeField]
    public bool SpeedUp = false;
    [SerializeField]
    public bool SpeedDown = false;

    private string myFuction;
    // Start is called before the first frame update
    private void Awake()
    {
        // GimmickManager = GameObject.FindGameObjectWithTag("STAGEMANAGER").GetComponent<SM_DicStageGM>();

    }
    Vector3 calculateReflect(Vector3 a, Vector3 z, Vector3 n)
    {
        Vector3 p = -Vector3.Dot(a, n) / n.magnitude * n / n.magnitude;
        Vector3 b = a + 2 * p;
        return b;
        //유니티의 내장함수 reflect와 동일한 효과를 지닌다.
    }

    void Start()
    {
        gimmickAnimation.SetActive(false);
        // GimmickManager.gimicDic.TryGetValue(GimmickNum, out myFuction);
        // print(myFuction);
        if (GimmickNum == 7)
        {
            Material mat = this.gameObject.GetComponentInChildren<Renderer>().material;
            Color color = mat.color;
            color.a = 0.3f;
            mat.color = color;
        }
    }

    void Reflect(Collision collision)
    {
        // print("반사함수 실행");
        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 velocity = collision.gameObject.GetComponent<BallStart>().velocity;
        ballRB.velocity = calculateReflect(velocity, Vector3.zero, -collision.GetContact(0).normal);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            if (GimmickNum == 6)
            {
                BoxCollider box = this.gameObject.GetComponent<BoxCollider>();
                Reflect(collision);
                box.isTrigger = true;
                Material mat = this.gameObject.GetComponent<Renderer>().material;
                Color color = mat.color;
                color.a = 0.4f;
                mat.color = color;
                gimmickAnimation.SetActive(true);
            }
            else if (GimmickNum == 7)
            {
                Reflect(collision);
                gimmickAnimation.SetActive(true);
            }
        }

    }
    public GameObject gimmickAnimation;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("BALL"))
        {
            if (GimmickNum == 1)
            {
                other.gameObject.transform.localScale = other.gameObject.transform.localScale * 1.5f;
                gimmickAnimation.SetActive(true);
            }
            else if (GimmickNum == 2)
            {
                other.gameObject.transform.localScale = other.gameObject.transform.localScale * 0.5f;
                gimmickAnimation.SetActive(true);
            }
            else if (GimmickNum == 3)
            {
                Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
                ballRB.velocity = ballRB.velocity * 1.5f;
                gimmickAnimation.SetActive(true);
            }
            else if (GimmickNum == 4)
            {
                Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
                ballRB.velocity = ballRB.velocity * 0.5f;
                gimmickAnimation.SetActive(true);
            }
            else if (GimmickNum == 5)
            {
                Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
                ballRB.velocity = ballRB.velocity * 0;
                gimmickAnimation.SetActive(true);
            }
            else if (GimmickNum == 8)
            {
                Vector3 velo = other.gameObject.GetComponent<BallStart>().velocity;
                Vector3 trPosition = other.gameObject.GetComponent<Transform>().position;
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                Vector3 vr = trPosition - this.gameObject.transform.position;
                vr.Normalize();
                float speed = -velo.magnitude;
                Vector3 reflectVelocity = Vector3.Reflect(velo, vr);
                rb.velocity = reflectVelocity * Mathf.Max(speed, 1f);

                if (other.gameObject.GetComponent<BallStart>().Copy == false)
                {
                    other.gameObject.GetComponent<BallStart>().Copy = true;
                    GameObject copy = Instantiate(CopyBall, trPosition, Quaternion.identity);
                    copy.GetComponent<BallStart>().Copy = true;

                    Rigidbody copyrb = copy.GetComponent<Rigidbody>();
                    copyrb.velocity = reflectVelocity * Mathf.Max(speed, 1f);
                }
            }
        }
        else if (other.gameObject.CompareTag("ENEMY"))
        {
            if (GimmickNum == 5)
            {
                other.gameObject.GetComponent<Enemy>().Damage(5);
            }
        }
    }
}
