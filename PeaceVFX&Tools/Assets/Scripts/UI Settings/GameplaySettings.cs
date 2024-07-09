using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySettings : MonoBehaviour
{
    [Range(30.0f, 160.0f)]
    [SerializeField] float FOV = 60.0f;
    [Range(0.1f, 10.0f)]
    [SerializeField] float mouseSpeed = 4.0f;


    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        mainCam.fieldOfView = FOV;
    }
}
