﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCameraFollow : MonoBehaviour
{

    public bool lockX = false;
    private Transform target;

    void Start()
    {
        target = FindObjectOfType<Hero>().transform;
    }

    void Update()
    {
        if (target)
        {
            Vector3 newPosition = target.position;
            newPosition.z = transform.position.z;
            if (lockX)
                newPosition.x = 0;

            transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Cant find hero!!!!!");
        }
    }
}