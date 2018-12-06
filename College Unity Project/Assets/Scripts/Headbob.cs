﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{

    public Vector3 restPosition; 
    public float transitionSpeed = 20f; 
    public float bobSpeed = 4.8f; 
    public float bobAmount = 0.05f; 

    float timer = Mathf.PI / 2; 
    Vector3 camPos;

    void Awake()
    {
        camPos = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) 
        {
            timer += bobSpeed * Time.deltaTime;

           
            Vector3 newPosition = new Vector3(Mathf.Cos(timer) * bobAmount, restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), restPosition.z); 
            camPos = newPosition;
        }
        else
        {
            timer = Mathf.PI / 2;

            Vector3 newPosition = new Vector3(Mathf.Lerp(camPos.x, restPosition.x, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.y, restPosition.y, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.z, restPosition.z, transitionSpeed * Time.deltaTime)); 
            camPos = newPosition;
        }

        if (timer > Mathf.PI * 2)
            timer = 0;
    }
}
