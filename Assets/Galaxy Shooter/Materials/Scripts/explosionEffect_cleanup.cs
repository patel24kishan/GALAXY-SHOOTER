﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionEffect_cleanup : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject, 4f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
