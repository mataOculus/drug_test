using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieaction : MonoBehaviour
{
    public GameObject objectToRotate;
    public float rotationSpeed = 30f; // ȸ�� �ӵ�

    private bool isRotating = false; // ȸ�� �� ���� Ȯ��
    private float rotationTarget = 0f; // ��ǥ ȸ�� ����
    private float rotationAmount = 0f; // ���� ȸ�� ����

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            isRotating = true;

            // ȸ���� ���� ����
            if (rotationAmount == 0f)
            {
                rotationTarget = 30f; // z ������ 30�� ȸ��
            }
            else if (rotationAmount == 30f)
            {
                rotationTarget = -30f; // -z ������ 60�� ȸ��
            }
        }

        // ȸ�� ���� ��
        if (isRotating)
        {
            RotateObject();
        }
    }

    void RotateObject()
    {
        if (objectToRotate != null)
        {
            // ȸ�� ���� ����
            float direction = (rotationTarget > 0f) ? 1f : -1f;

            // ȸ��
            float rotationStep = rotationSpeed * Time.deltaTime;
            rotationAmount += rotationStep * direction;

            // ��ǥ ȸ�� ������ �����ϸ� ȸ�� ����
            if ((direction == 1f && rotationAmount >= rotationTarget) || (direction == -1f && rotationAmount <= rotationTarget))
            {
                rotationAmount = rotationTarget;
                isRotating = false; // ȸ�� ����
            }

            // ����� ȸ������ ����
            objectToRotate.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        }
        else
        {
            Debug.LogWarning("ȸ���� ������Ʈ�� �������� �ʾҽ��ϴ�!");
        }
    }
}
