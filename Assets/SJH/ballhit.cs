using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballhit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            // �浹�� ������Ʈ�� ��ġ�� �浹 ������ ���ɴϴ�.
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 oppositeDirection = transform.position - collisionPoint;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(oppositeDirection.normalized * 30f, ForceMode.Impulse);
                // ���࿡ ������Ʈ�� ȸ���ϸ鼭 ���ư��� ���Ѵٸ�, �Ʒ� �ڵ带 �߰��մϴ�.
                // rb.AddTorque(Vector3.up * 500f, ForceMode.Impulse);
            }
        }
    }
}
