using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cocaine_Scene : MonoBehaviour
{
    public string sceneToLoad = "SceneTest"; // 이동할 씬의 이름

    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 메인 카메라인지 확인
        if (other.CompareTag("MainCamera"))
        {
            // 씬 이동
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
