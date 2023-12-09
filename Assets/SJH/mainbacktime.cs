using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainbacktime : MonoBehaviour
{
    public float time = 30f;
    public CameraEffect CameraEffect;
    void Update()
    {
        if(time < 6)
        {
            CameraEffect.enabled = true;
        }

        if (time > 0)
        {
            time -= Time.deltaTime; 
        }
        else
        {
            LoadMainScene(); 
        }
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("Drug_Main"); 
    }
}
