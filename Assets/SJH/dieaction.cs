using System.Collections;
using UnityEngine;

public class dieaction : MonoBehaviour
{

    public mainbacktime mainbacktime;
    public float[] rotationAmountsZ = { 20f, -50f, 80f, -140f }; 
    public float[] rotationAmountsX = { 10f, -30f, 70f, -100f };
    public float rotationDuration = 1f; 

    private bool isRotating = false; 
    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isRotating)
        {
            StartCoroutine(StartMultipleRotations());
        }

        if (!isRotating && mainbacktime.time < 6)
        {
            StartCoroutine(StartMultipleRotations());
        }
    }

    IEnumerator StartMultipleRotations()
    {
        isRotating = true;

        for (int i = 0; i < 4; i++) 
        {
            yield return StartCoroutine(RotateObject()); 
        }

        isRotating = false;
    }

    IEnumerator RotateObject()
    {
        float targetRotationZ = rotationAmountsZ[currentIndex];
        float targetRotationX = rotationAmountsX[currentIndex];
        float startRotationZ = transform.rotation.eulerAngles.z;
        float startRotationX = transform.rotation.eulerAngles.x;
        float progress = 0f;

        while (progress < 1f)
        {
            progress += Time.deltaTime / rotationDuration;

            float newRotationZ = Mathf.LerpAngle(startRotationZ, startRotationZ + targetRotationZ, progress);
            float newRotationX = Mathf.LerpAngle(startRotationX, startRotationX + targetRotationX, progress);

            transform.rotation = Quaternion.Euler(0f, 0f, newRotationZ);
            transform.Rotate(newRotationX - transform.rotation.eulerAngles.x, 0f, 0f, Space.Self);

            yield return null;
        }

        currentIndex = (currentIndex + 1) % rotationAmountsZ.Length; 
    }
}