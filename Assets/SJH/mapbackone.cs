using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mapbackone : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 30f;
    public float map = 1f;
    public CameraEffect CameraEffect;
    void Update()
    {
        if (time < 6)
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
        if (map == 1)
        {
            SceneManager.LoadScene("Drug_Main");
        }
        else
            SceneManager.LoadScene("Drug_Main_2");

    }
}
