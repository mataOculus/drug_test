using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesshader : MonoBehaviour
{
    // Start is called before the first frame update
    public Shader yourShader; // ����� ���̴�

    void Start()
    {
        Camera.main.SetReplacementShader(yourShader, null); // ī�޶� ���̴��� ����
    }
}
