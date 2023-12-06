using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballhit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            // 충돌한 오브젝트의 위치와 충돌 지점을 얻어옵니다.
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 oppositeDirection = transform.position - collisionPoint;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(oppositeDirection.normalized * 30f, ForceMode.Impulse);
                // 만약에 오브젝트가 회전하면서 날아가길 원한다면, 아래 코드를 추가합니다.
                // rb.AddTorque(Vector3.up * 500f, ForceMode.Impulse);
            }
        }
    }
}
