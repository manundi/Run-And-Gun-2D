﻿using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    public float speed = 0.5f;

    private Renderer rend;

    private void Start()
    {
        //  renderer = GetComponent<MeshRenderer>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2 (Time.time * speed, 0);

        rend.material.mainTextureOffset = offset;
    }
}