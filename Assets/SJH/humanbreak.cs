using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanbreak : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {

            Rigidbody[] childRigidbodies = GetComponentsInChildren<Rigidbody>();

            Rigidbody selfRigidbody = GetComponent<Rigidbody>();
            if (selfRigidbody != null)
            {
                selfRigidbody.isKinematic = false; 

                BoxCollider boxCollider = GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }

            }

            foreach (Rigidbody rb in childRigidbodies)
            {
                rb.isKinematic = false; 

                MeshCollider meshCollider = rb.GetComponent<MeshCollider>();
                if (meshCollider != null)
                {
                    meshCollider.enabled = true;
                }
            }

        }
    }

}