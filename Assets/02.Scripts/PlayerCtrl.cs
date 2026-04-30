using UnityEngine;
using UnityEngine.Android;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;
    //Animation 컴포넌트를 저장할 변수
    private Animation anim;
    //회전 속도 변수
    [SerializeField] private float turnSpeed = 100.0f;
    [SerializeField] private float moveSpeed = 5.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        
        //Translate (이동 방향 * 속력 * Time.deltaTime)
        tr.Translate(moveDir * moveSpeed * Time.deltaTime);

        //Vector3.up 축을 기준으로 TurnSpeed 만큼 속도로 회전
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        PlayerAnim(h, v);

    }

    void PlayerAnim(float h, float v)
    {
        //키보드 입력값을 기준으로 동작할 애니메이션 수행

        if (v >= 0.1f)
        {
            anim.CrossFade("RunF");
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB");
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("Right");
        }else if (v <= -0.1f)
        {
            anim.CrossFade("Left");
        }
        else
        {
            anim.CrossFade("Idle");
        }
    }
}
