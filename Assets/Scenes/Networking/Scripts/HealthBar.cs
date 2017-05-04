﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform health;
    public Transform background;

    private bool initialized = false;
    private float maxHelth = 1;
    private float currentHealth = 1;

    private Vector3 originalScale;

    private void Update()
    {
        //transform.LookAt(Camera.main.transform);
        var fwd = Camera.main.transform.forward * -10;
        fwd.y = 0.0f;
        transform.rotation = Quaternion.LookRotation(fwd);
    }

    public void Init(float max)
    {
        maxHelth = max;
        currentHealth = max;
        originalScale = health.localScale;

        initialized = true;
    }

    public void AdjustHealth(float delta)
    {
        if(!initialized)
            Debug.LogError("HealthBar: Initialize me first");

        currentHealth += delta;

        if (currentHealth < 0)
            currentHealth = 0;
        if (currentHealth > maxHelth)
            currentHealth = maxHelth;

        var relevantDelta = currentHealth / maxHelth;
        health.localScale = Vector3.Scale(originalScale, new Vector3(1, relevantDelta, 1));

        health.transform.localPosition = new Vector3(1 - relevantDelta, 0, 0);
    }
}
