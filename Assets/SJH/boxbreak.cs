using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxbreak : MonoBehaviour
{
    public Mesh[] meshes; // �ټ��� �޽��� ���� �迭
    private int currentMeshIndex = 0; // ���� �޽� �ε���

    void Start()
    {
        SetMesh(currentMeshIndex); // �ʱ� �޽� ����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CycleMesh(); // K Ű�� ������ �޽��� �����ϴ� �Լ� ȣ��
        }
    }

    void CycleMesh()
    {
        currentMeshIndex = (currentMeshIndex + 1) % meshes.Length; // ���� �޽� �ε��� ���
        SetMesh(currentMeshIndex); // ���ο� �޽� ����
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
        if (collision.gameObject.CompareTag("weapon")) // 'weapon' �±׸� ���� ������Ʈ�� �浹 Ȯ��
        {
            CycleMesh(); // �浹 �� �޽� ����
        }
    }
}
