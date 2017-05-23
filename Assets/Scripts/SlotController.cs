using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour {

	string actionCase;

	// Use this for initialization
	void Start () {
		actionCase = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		transform.parent.GetComponent<PanelController>().selectedSlot = this.transform;
	}


}
