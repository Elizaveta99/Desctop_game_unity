﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyScript : MonoBehaviour
{
	void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
