using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxbreak : MonoBehaviour
{
    public Mesh[] meshes; // �ټ��� �޽��� ���� �迭
    private int currentMeshIndex = 0; // ���� �޽� �ε���
    private bool canCycleMesh = true; // �Է��� ���� �� �ִ� �������� ����

    public AudioClip breakSound;

    void Start()
    {
        SetMesh(currentMeshIndex); // �ʱ� �޽� ����
    }

    void Update()
    {
        if (canCycleMesh && Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(DelayCycleMesh()); // K Ű�� ������ ���� �ð� �� �޽� �����ϴ� �ڷ�ƾ ����
        }
    }

    IEnumerator DelayCycleMesh()
    {
        canCycleMesh = false; // �Է� ���� �� ���� ���·� ����
        CycleMesh(); // �޽� ���� �Լ� ȣ��
        yield return new WaitForSeconds(0.5f); // �߰����� �Է� ���ø� ���� 0.5�� �� ���
        canCycleMesh = true; // �ٽ� �Է� ���� �� �ִ� ���·� ����
    }

    void CycleMesh()
    {
        if (currentMeshIndex < 3)
        {
            currentMeshIndex = (currentMeshIndex + 1) % meshes.Length; // ���� �޽� �ε��� ���
            SetMesh(currentMeshIndex); // ���ο� �޽� ����
        }
    }

    void SetMesh(int index)
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>(); // MeshFilter ������Ʈ ��������

        if (meshFilter != null && meshes != null && index >= 0 && index < meshes.Length)
        {
            meshFilter.mesh = meshes[index]; // �ش� �ε����� �޽� �Ҵ�
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon") && canCycleMesh) // 'weapon' �±׸� ���� ������Ʈ�� �浹 Ȯ��
        {
            StartCoroutine(DelayCycleMesh()); // �浹 �� ���� �ð� �� �޽� �����ϴ� �ڷ�ƾ ����
            PlayHitSound();
        }
    }

    void PlayHitSound()
    {
        if (breakSound != null)
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
    }
}
