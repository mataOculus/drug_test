using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lsd_Scene : MonoBehaviour
{
    public string sceneToLoad = "SceneTest"; // �̵��� ���� �̸�

    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� ���� ī�޶����� Ȯ��
        if (other.CompareTag("MainCamera"))
        {
            // �� �̵�
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}