using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainbacktime : MonoBehaviour
{
    public float time = 30f;
    public float map = 1f;

    void Update()
    {


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
        if (map == 5)
        {

        }
        else
            SceneManager.LoadScene("Drug_Main_2");

    }
}
