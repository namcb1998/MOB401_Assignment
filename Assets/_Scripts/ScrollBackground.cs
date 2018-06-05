﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	[SerializeField] private float speedScroll;

	private Renderer _renderer;
	// Use this for initialization
	void Start ()
	{
		_renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset =new Vector2(Time.time*speedScroll,0);
		_renderer.material.mainTextureOffset = offset;
	}
}
