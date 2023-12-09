using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{

    public mainbacktime mainbacktime;

    [SerializeField] Material effectMat;
    private float[] blinkValues = { 0f, 1f, 0.3f, 1f, 0.5f, 0.7f, 1f };
    private float blinkDuration = 5.0f;
    private float currentBlinkTime = 0.0f;
    private int currentIndex = 0;

    void OnRenderImage(RenderTexture _src, RenderTexture _dest)
    {
        if (effectMat == null)
            return;

        Graphics.Blit(_src, _dest, effectMat);
    }

    private void Update()
    {
        
        currentBlinkTime += Time.deltaTime;


        float timePerStep = blinkDuration / (blinkValues.Length - 1);
        int previousIndex = Mathf.FloorToInt(currentBlinkTime / timePerStep);
        int nextIndex = Mathf.CeilToInt(currentBlinkTime / timePerStep);

        if (nextIndex < blinkValues.Length)
        {
            float lerpValue = Mathf.InverseLerp(previousIndex * timePerStep, nextIndex * timePerStep, currentBlinkTime);
            float newBlinkValue = Mathf.Lerp(blinkValues[previousIndex], blinkValues[nextIndex], lerpValue);
            effectMat.SetFloat("_Blink", newBlinkValue);
        }
        else
        {
            effectMat.SetFloat("_Blink", blinkValues[blinkValues.Length - 1]);
        }
    }
}