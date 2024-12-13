using System.Collections;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    // 물고기의 이동 범위 (앞뒤로 얼마나 움직일지)
    public float moveDistance = 5f;
    // 물고기의 이동 속도 (얼마나 빠르게 움직일지)
    public float moveSpeed = 2f;

    // 물고기의 위아래 이동 속도 (위아래 움직임 주기 조정)
    public float moveUpDownSpeed = 3f;  // 이 값을 더 크게 설정하면 위아래 이동이 더 빨라짐

    // 시작 위치 저장
    private Vector3 startPosition;
    private Transform fishBody;

    // 물고기가 위아래로 움직일지 여부
    public bool moveUpDown = true;
    // 물고기가 뒤로 갈 때 회전할지 여부
    public bool rotateWhenMovingBackwards = true;

    // 이동 방향을 추적하는 변수
    private float lastMoveDirection = 1f; // 1은 앞으로, -1은 뒤로

    void Awake()
    {
        // 시작 위치 저장 (Transform의 초기 위치)
        fishBody = transform.GetChild(0);
        startPosition = this.transform.position;
        
        // 위아래 움직임 코루틴 시작
        if (moveUpDown)
        {
            StartCoroutine(MoveUpDown());
        }
        
        // Z축 움직임 코루틴 시작
        StartCoroutine(MoveZAxis());
    }

    void Update()
    {
        // 물고기의 이동 범위와 속도에 맞춰 사인파 기반으로 앞뒤로 이동
        float move = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // 물고기가 뒤로 갈 때 회전할지 여부 체크


        // 물고기 위치 갱신
        //transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z + move);

    }

    // 물고기의 Z축 움직임을 담당하는 코루틴
    IEnumerator MoveZAxis()
    {
        while (true) // Z축 움직임은 계속 반복되므로 무한루프
        {
            float move = Mathf.Sin(Time.time * moveSpeed) * moveDistance;

            // Z축으로 물고기 이동
            transform.position = new Vector3(startPosition.x, transform.position.y, startPosition.z + move);
            //fishBody.transform.rotation = Quaternion.Euler(-90f, 0, fishBody.transform.rotation.z);

            if (rotateWhenMovingBackwards)
            {
                // 물고기의 Cos 값이 0 이하일 때 방향이 뒤로 바뀐다면
                if (Mathf.Cos(Time.time * moveSpeed) < 0)
                {
                    // 로컬 좌표계에서 180도 회전
                    fishBody.transform.rotation = Quaternion.Euler(-90f, 0, 180);
                }
                else
                {
                    // 원래 상태로 회전 (앞으로 가는 상태)
                    fishBody.transform.rotation = Quaternion.Euler(-90f, 0, 0);
                }
            }
            //fishBody.transform.rotation = Quaternion.Euler(-90f, 0, fishBody.transform.rotation.z);

            yield return null; // 한 프레임 대기 후 계속
        }
    }

    // 물고기의 Y축 위아래 움직임을 담당하는 코루틴
    IEnumerator MoveUpDown()
    {
        while (moveUpDown) // 위아래 움직임이 true일 때 계속 반복
        {
            // moveUpDownSpeed에 의해 주기 조정 (이 값이 클수록 더 빠르게 위아래로 움직임)
            float move = Mathf.Sin(Time.time * moveUpDownSpeed) * moveDistance*0.5f;
            fishBody.transform.rotation = Quaternion.Euler(-90f, 0, fishBody.transform.rotation.z);

            // Y축으로 물고기 이동
            transform.position = new Vector3(startPosition.x, startPosition.y + move, transform.position.z);

            yield return null; // 한 프레임 대기 후 계속
        }
    }
}
