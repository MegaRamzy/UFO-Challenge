﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}