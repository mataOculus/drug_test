using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drug_UI : MonoBehaviour
{
    public Transform cube;      // ť���� Transform ������Ʈ�� ����
    public Camera mainCamera;   // ���� ī�޶� ����
    public GameObject panel;    // Ȱ��ȭ�� �г��� ����

    public float activationDistance = 7f; // Ȱ��ȭ �Ÿ�

    void Update()
    {
        // ť��� ���� ī�޶� ���� �Ÿ� ���
        float distance = Vector3.Distance(cube.position, mainCamera.transform.position);

        // �Ÿ��� ������ �Ÿ� �����̸� �г� Ȱ��ȭ
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
