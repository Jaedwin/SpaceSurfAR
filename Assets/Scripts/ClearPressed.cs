﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
 
public class ClearPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
	public bool buttonPressed;
	TrailScript script;

	GameObject Renderer;
	bool test;

	void Start () {
		Renderer = GameObject.FindGameObjectsWithTag("renderer")[0];
		script = Renderer.GetComponent<TrailScript>();
	}

	public void OnPointerDown(PointerEventData eventData){
		buttonPressed = true;
		script.clearPressed = true;
	}
	 
	public void OnPointerUp(PointerEventData eventData){
	  buttonPressed = false;
		script.clearPressed = false;
	}
}