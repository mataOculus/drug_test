using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxbreak : MonoBehaviour
{
    public Mesh[] meshes; // 다수의 메쉬를 담을 배열
    private int currentMeshIndex = 0; // 현재 메쉬 인덱스

    void Start()
    {
        SetMesh(currentMeshIndex); // 초기 메쉬 설정
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CycleMesh(); // K 키를 누르면 메쉬를 변경하는 함수 호출
        }
    }

    void CycleMesh()
    {
        currentMeshIndex = (currentMeshIndex + 1) % meshes.Length; // 다음 메쉬 인덱스 계산
        SetMesh(currentMeshIndex); // 새로운 메쉬 설정
    }

    void SetMesh(int index)
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>(); // MeshFilter 컴포넌트 가져오기

        if (meshFilter != null && meshes != null && index >= 0 && index < meshes.Length)
        {
            meshFilter.mesh = meshes[index]; // 해당 인덱스의 메쉬 할당
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon")) // 'weapon' 태그를 가진 오브젝트와 충돌 확인
        {
            CycleMesh(); // 충돌 시 메쉬 변경
        }
    }
}
