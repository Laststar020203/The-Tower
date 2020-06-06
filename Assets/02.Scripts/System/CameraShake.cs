using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    private Camera mainCamera;
    private Vector3 originalPos;
    [SerializeField]
    private bool isShake;

    private void Start()
    {
        mainCamera = Camera.main;
        isShake = false;
        originalPos = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            originalPos = gameObject.transform.position;
            StartCoroutine(Shake());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShake = false;
        }

        if (isShake)
            Shake();
    }

    private IEnumerator Shake()
    {
        mainCamera.transform.position = new Vector3(Random.Range(originalPos.x, originalPos.x + 0.3f), Random.Range(originalPos.y, originalPos.y + 0.3f), transform.localPosition.z);
        yield return new WaitForSeconds(0.09f);
        mainCamera.transform.position = new Vector3(Random.Range(originalPos.x, originalPos.x + 0.3f), Random.Range(originalPos.y, originalPos.y + 0.3f), transform.localPosition.z);
        yield return new WaitForSeconds(0.09f);
        mainCamera.transform.position = new Vector3(Random.Range(originalPos.x, originalPos.x + 0.3f), Random.Range(originalPos.y, originalPos.y + 0.3f), transform.localPosition.z);
        yield return new WaitForSeconds(0.09f);
        mainCamera.transform.position = originalPos;

    }
}
