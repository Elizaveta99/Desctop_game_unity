﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptFullScreen : MonoBehaviour
{
    public float orthographicSize = 0.81f;
    public float aspect = 1.33333f;
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                GetComponent<Camera>().nearClipPlane, GetComponent<Camera>().farClipPlane);
    }
}
