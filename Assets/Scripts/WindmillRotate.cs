﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (
			0 * Time.deltaTime,
			0 * Time.deltaTime,
			-45 * Time.deltaTime
		);
	}
}
