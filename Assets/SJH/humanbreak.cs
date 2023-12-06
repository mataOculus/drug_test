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

            Rigidbody selfRigidbody = GetComponent<Rigidbody>();
            if (selfRigidbody != null)
            {
                selfRigidbody.isKinematic = false; // 자기 자신의 Rigidbody의 isKinematic을 해제

                BoxCollider boxCollider = GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }

            }

            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.isKinematic = false; // 자식들의 Rigidbody의 isKinematic을 해제

                MeshCollider meshCollider = rb.GetComponent<MeshCollider>();
                if (meshCollider != null)
                {
                    meshCollider.enabled = true;
                }
            }

        }
    }

}