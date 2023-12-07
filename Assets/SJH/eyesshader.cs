using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesshader : MonoBehaviour
{
    // Start is called before the first frame update
    public Shader yourShader; // 사용할 쉐이더

    void Start()
    {
        Camera.main.SetReplacementShader(yourShader, null); // 카메라에 쉐이더를 적용
    }
}
