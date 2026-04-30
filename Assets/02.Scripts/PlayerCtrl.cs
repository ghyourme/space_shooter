using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;
    [SerializeField] private float moveSpeed = 5.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h:=" + h);
        Debug.Log("v:=" + v);

        //정규화 벡터를 사용한 코드
        tr.position += new Vector3(h, 0, v) * Time.deltaTime * moveSpeed;

        //정규화 벡터를 사용하지 않은 코드
        //transform.position += new Vector3(h, 0, v) *Time.deltaTime * 5.0f;

    }
}
