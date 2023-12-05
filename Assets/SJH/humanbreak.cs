using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanbreak : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            // 'weapon' 태그를 가진 오브젝트와 충돌했을 때
            Rigidbody[] childRigidbodies = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.isKinematic = false; // 자식들의 Rigidbody의 isKinematic을 해제
            }
        }
    }

}