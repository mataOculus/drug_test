using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug_UI : MonoBehaviour
{
    public Transform cube;      // 큐브의 Transform 컴포넌트를 연결
    public Camera mainCamera;   // 메인 카메라를 연결
    public GameObject panel;    // 활성화할 패널을 연결

    public float activationDistance = 7f; // 활성화 거리

    void Update()
    {
        // 큐브와 메인 카메라 간의 거리 계산
        float distance = Vector3.Distance(cube.position, mainCamera.transform.position);

        // 거리가 지정된 거리 이하이면 패널 활성화
        if (distance <= activationDistance)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
