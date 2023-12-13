using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class camereffet2 : MonoBehaviour
{
    public CameraEffect cameraEffect;
    public mainbacktime mainbacktime;
    public PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;
    private AudioSource audioSource;
    private bool policeSoundPlayed = false;
    private bool isChanging = false;
    private float startTime;
    private float changeDuration = 5f;
    private float startFocalLength = 100f;
    private float targetFocalLength = 300f;

    public AudioClip policeSound;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGetSettings(out depthOfField);
            if (depthOfField != null)
            {
                //StartCoroutine(ChangeFocalLengthOverTime());
            }
            else
            {
                Debug.LogError("Depth of Field settings not found in the Post Processing Profile!");
            }
        }
        else
        {
            Debug.LogError("Post Process Volume not found on the camera!");
        }
    }

    IEnumerator ChangeFocalLengthOverTime()
    {
        isChanging = true;
        startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < changeDuration)
        {
            float t = elapsedTime / changeDuration;
            depthOfField.focalLength.value = Mathf.Lerp(startFocalLength, targetFocalLength, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        depthOfField.focalLength.value = targetFocalLength;
        PlayPoliceSound();
    }

    void Update()
    {
        if (!isChanging && mainbacktime.time < 6)
        {
            cameraEffect.enabled = true;
            Debug.Log(mainbacktime.time);
            if (!policeSoundPlayed)
            {
                StartCoroutine(ChangeFocalLengthOverTime());
                policeSoundPlayed = true;
            }
            
        }
    }
    void PlayPoliceSound()
    {
        if (audioSource != null && policeSound != null)
        {
            audioSource.PlayOneShot(policeSound);
        }
    }
}
