using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieaction : MonoBehaviour
{
    public GameObject objectToRotate;
    public float rotationSpeed = 30f; // 회전 속도

    private bool isRotating = false; // 회전 중 여부 확인
    private float rotationTarget = 0f; // 목표 회전 각도
    private float rotationAmount = 0f; // 현재 회전 각도

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            isRotating = true;

            // 회전할 각도 설정
            if (rotationAmount == 0f)
            {
                rotationTarget = 30f; // z 축으로 30도 회전
            }
            else if (rotationAmount == 30f)
            {
                rotationTarget = -30f; // -z 축으로 60도 회전
            }
        }

        // 회전 중일 때
        if (isRotating)
        {
            RotateObject();
        }
    }

    void RotateObject()
    {
        if (objectToRotate != null)
        {
            // 회전 방향 결정
            float direction = (rotationTarget > 0f) ? 1f : -1f;

            // 회전
            float rotationStep = rotationSpeed * Time.deltaTime;
            rotationAmount += rotationStep * direction;

            // 목표 회전 각도에 도달하면 회전 멈춤
            if ((direction == 1f && rotationAmount >= rotationTarget) || (direction == -1f && rotationAmount <= rotationTarget))
            {
                rotationAmount = rotationTarget;
                isRotating = false; // 회전 종료
            }

            // 변경된 회전값을 적용
            objectToRotate.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        }
        else
        {
            Debug.LogWarning("회전할 오브젝트가 설정되지 않았습니다!");
        }
    }
}
