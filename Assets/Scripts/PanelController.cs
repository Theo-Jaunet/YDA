using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {

	public Transform selectedItem, selectedSlot, originalSlot;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && selectedItem != null)
		{
			originalSlot = selectedItem.parent;
			selectedItem.GetComponent<Collider>().enabled = false;
		}
		if (Input.GetMouseButton(0) && selectedItem != null)
		{
			selectedItem.position = Input.mousePosition;
		}

		else if (Input.GetMouseButtonUp(0) && selectedItem != null)
		{
			if (selectedSlot == null) selectedItem.parent = originalSlot;
			else
			{
				selectedItem.parent = selectedSlot;
			}

			selectedItem.localPosition = Vector3.zero;
			selectedItem.GetComponent<Collider>().enabled = true;
		}
	}
}
