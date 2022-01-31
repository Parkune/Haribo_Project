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
        // GimmickManager.gimicDic.TryGetValue(GimmickNum, out myFuction);
        // print(myFuction);
        if (GimmickNum == 7)
        {
            Material mat = this.gameObject.GetComponent<Renderer>().material;
            Color color = mat.color;
            color.a = 0.3f;
            mat.color = color;
        }
    }

    void Reflect(Collision collision)
    {
        print("반사함수 실행");
        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 velocity = collision.gameObject.GetComponent<BallStart>().velocity;
        ballRB.velocity = calculateReflect(velocity, Vector3.zero, -collision.GetContact(0).normal);
        
/*        else if (SpeedUp == true)
        {
            ballRB.velocity = calculateReflect(velocity, Vector3.zero, -collision.GetContact(0).normal) * 1.5f;
        }
        else if (SpeedDown == true)
        {
            ballRB.velocity = calculateReflect(velocity, Vector3.zero, -collision.GetContact(0).normal) / 1.5f;
        }*/
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            //  외부에서 부딪힌 대상 못가져와서 패스
            //  매개변수를 다시 한 번 지정해줘야하는데 그게 불가
            //Invoke(myFuction, 0.5f);

            if (GimmickNum == 2)
            {
                collision.gameObject.transform.localScale = collision.gameObject.transform.localScale / 1.5f;
                print("큐브작아짐");
                Reflect(collision);
                //GimmickNum=SmallCube

            }
           
            else if (GimmickNum == 6)
            {
                BoxCollider box = this.gameObject.GetComponent<BoxCollider>();
                Reflect(collision);
                box.isTrigger = true;
                Material mat = this.gameObject.GetComponent<Renderer>().material;
                Color color = mat.color;
                color.a = 0.4f;
                mat.color = color;
                //GimmickNum=HideCube 1회 부딪히면 부서지는 큐브
            }
            else if (GimmickNum == 7)
            {
                Reflect(collision);
                //GimmickNum=XVelocity10Cube
            }
/*            else if (GimmickNum == 8)
            {

                //GimmickNum=CrossBombCube
                //Reflect(collision);
                
                Vector3 velo = collision.gameObject.GetComponent<BallStart>().velocity;
                Vector3 trPosition = collision.gameObject.GetComponent<Transform>().position;
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                float speed = -velo.magnitude;
                Vector3 reflectVelocity  = Vector3.Reflect(velo, collision.contacts[0].normal);
                rb.velocity = reflectVelocity * Mathf.Max(speed, 1f);
                //Vector3 vec = new Vector3(trPosition.x * reflectVelocity.x, transform.position.z * reflectVelocity.y, trPosition.z * reflectVelocity.z); ;
                //collision.contacts[0].point
                if (collision.gameObject.GetComponent<BallStart>().Copy == false)
                { 
                    GameObject copy = Instantiate(CopyBall, trPosition , Quaternion.identity);
                    copy.GetComponent<BallStart>().Copy = true;
                    Rigidbody copyrb = copy.GetComponent<Rigidbody>();
                    copyrb.velocity = reflectVelocity * Mathf.Max(speed, 1f);
                }
            }*/
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GimmickNum == 1)
        {
            //GimmickNum=BigCube
            other.gameObject.transform.localScale = other.gameObject.transform.localScale * 1.5f;
            print("큐브커짐");
            //Reflect(collision);
        }
        if (GimmickNum == 3)
        {
            //GimmickNum=SpeedUpCube
            //SpeedUp = true;
           // Reflect(collision);

            print("큐브속도 빨라짐");
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            ballRB.velocity = ballRB.velocity * 1.5f;
            //SpeedUp = false;
        }
        if (GimmickNum == 4)
        {
            //GimmickNum=SpeedDownCube
            //SpeedDown = true;
            //Reflect(collision);
            Rigidbody ballRB = other.gameObject.GetComponent<Rigidbody>();
            ballRB.velocity = ballRB.velocity * 0.5f;
            print("큐브속도 느려짐");
            //SpeedDown = false;
        }
        if (GimmickNum == 5)
        {
            //GimmickNum=BlackHoleCube
            //Reflect(collision);
            other.gameObject.GetComponent<BallStart>().zeroVelocity();
            print("블랙홀에 먹혔습니다.");
        }
        if (GimmickNum == 8)
        {

            //GimmickNum=CrossBombCube
            //Reflect(collision);

            Vector3 velo = other.gameObject.GetComponent<BallStart>().velocity;
            Vector3 trPosition = other.gameObject.GetComponent<Transform>().position;
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 vr = trPosition - this.gameObject.transform.position;
            vr.Normalize();
            float speed = -velo.magnitude;
            Vector3 reflectVelocity = Vector3.Reflect(velo, vr);
            rb.velocity = reflectVelocity * Mathf.Max(speed, 1f);
            //Vector3 vec = new Vector3(trPosition.x * reflectVelocity.x, transform.position.z * reflectVelocity.y, trPosition.z * reflectVelocity.z); ;
            //collision.contacts[0].point
            if (other.gameObject.GetComponent<BallStart>().Copy == false)
            {
                GameObject copy = Instantiate(CopyBall, trPosition, Quaternion.identity);
                copy.GetComponent<BallStart>().Copy = true;
                Rigidbody copyrb = copy.GetComponent<Rigidbody>();
                copyrb.velocity = reflectVelocity * Mathf.Max(speed, 1f);
            }
        }
    }

    float rotSpeed = 30f;

    void Update()
    {
        if(GimmickNum == 9)
        {
            print("기믹9들어옴");
           this.gameObject.transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
        }
    }
}
