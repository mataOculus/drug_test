using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanbreak : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            // 'weapon' �±׸� ���� ������Ʈ�� �浹���� ��
            Rigidbody[] childRigidbodies = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.isKinematic = false; // �ڽĵ��� Rigidbody�� isKinematic�� ����
            }

            Rigidbody selfRigidbody = GetComponent<Rigidbody>();
            if (selfRigidbody != null)
            {
                selfRigidbody.isKinematic = false; // �ڱ� �ڽ��� Rigidbody�� isKinematic�� ����
            }
        }
    }

}