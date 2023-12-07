using System.Collections;
using UnityEngine;

public class dieaction : MonoBehaviour
{
    public float[] rotationAmountsZ = { 20f, -50f, 80f, -140f }; // Z 축 회전량 배열
    public float[] rotationAmountsX = { 10f, -30f, 70f, -100f }; // X 축 회전량 배열
    public float rotationDuration = 1f; // 회전 지속 시간

    private bool isRotating = false; // 회전 중 여부 확인
    private int currentIndex = 0; // 현재 회전할 각도의 인덱스

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isRotating) // O 버튼이 눌리고 회전 중이 아닐 때
        {
            StartCoroutine(StartMultipleRotations()); // 연속된 회전 시작
        }
    }

    IEnumerator StartMultipleRotations()
    {
        isRotating = true;

        for (int i = 0; i < 4; i++) // 4번의 회전 실행
        {
            yield return StartCoroutine(RotateObject()); // 오브젝트 회전 코루틴 실행
        }

        isRotating = false;
    }

    IEnumerator RotateObject()
    {
        float targetRotationZ = rotationAmountsZ[currentIndex];
        float targetRotationX = rotationAmountsX[currentIndex];
        float startRotationZ = transform.rotation.eulerAngles.z;
        float startRotationX = transform.rotation.eulerAngles.x;
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime / rotationDuration;

            float newRotationZ = Mathf.LerpAngle(startRotationZ, startRotationZ + targetRotationZ, progress);
            float newRotationX = Mathf.LerpAngle(startRotationX, startRotationX + targetRotationX, progress);

            transform.rotation = Quaternion.Euler(0f, 0f, newRotationZ);
            transform.Rotate(newRotationX - transform.rotation.eulerAngles.x, 0f, 0f, Space.Self);

            yield return null;
        }

        currentIndex = (currentIndex + 1) % rotationAmountsZ.Length; // 다음 회전 각도 인덱스로 업데이트
    }
}