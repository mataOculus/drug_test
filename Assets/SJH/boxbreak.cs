using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxbreak : MonoBehaviour
{
    public Mesh[] meshes; // 다수의 메쉬를 담을 배열
    private int currentMeshIndex = 0; // 현재 메쉬 인덱스
    private bool canCycleMesh = true; // 입력을 받을 수 있는 상태인지 여부

    public AudioClip breakSound;

    void Start()
    {
        SetMesh(currentMeshIndex); // 초기 메쉬 설정
    }

    void Update()
    {
        if (canCycleMesh && Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(DelayCycleMesh()); // K 키를 누르면 일정 시간 후 메쉬 변경하는 코루틴 실행
        }
    }

    IEnumerator DelayCycleMesh()
    {
        canCycleMesh = false; // 입력 받을 수 없는 상태로 변경
        CycleMesh(); // 메쉬 변경 함수 호출
        yield return new WaitForSeconds(0.5f); // 추가적인 입력 무시를 위해 0.5초 더 대기
        canCycleMesh = true; // 다시 입력 받을 수 있는 상태로 변경
    }

    void CycleMesh()
    {
        if (currentMeshIndex < 3)
        {
            currentMeshIndex = (currentMeshIndex + 1) % meshes.Length; // 다음 메쉬 인덱스 계산
            SetMesh(currentMeshIndex); // 새로운 메쉬 설정
        }
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
        if (collision.gameObject.CompareTag("weapon") && canCycleMesh) // 'weapon' 태그를 가진 오브젝트와 충돌 확인
        {
            StartCoroutine(DelayCycleMesh()); // 충돌 시 일정 시간 후 메쉬 변경하는 코루틴 실행
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
