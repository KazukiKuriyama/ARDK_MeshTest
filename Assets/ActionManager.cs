using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float power = 2;

    [SerializeField]
    private float destroyTime = 10.0f;
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            FireBall();
        }
#else
        if (0 < Input.touchCount)
        {
            Touch touch0 = Input.GetTouch(0);
            if (touch0.phase == TouchPhase.Began)
            {
                FireBall();
            }
        }
#endif
    }

    private void FireBall()
    {
        GameObject ballObject = GameObject.Instantiate(ballPrefab, mainCamera.transform.position, Quaternion.identity);
        ballObject.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * power);
        Destroy(ballObject, 10.0f);
    }


}
