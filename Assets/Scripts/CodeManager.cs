using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour {

	int nbActions = 0;

	string[] actionCases;

	void Update()
	{

	}

	public string[] getActions()
	{
		return actionCases;
	}

	public void setActions()
	{
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Case");
		int idArray = 0;
		actionCases = new string[gameObjects.Length];

		for (int i = 0; i < gameObjects.Length; i++)
		{
			print(gameObjects[i].ToString());
			if (gameObjects[i].transform.GetChildCount() > 0)
			{
				actionCases[idArray] = gameObjects[i].transform.GetChild(0).ToString();
				idArray++;		
			}
		}

		for(int i=0; i < actionCases.Length; i++)
		{
			print(actionCases[i]);
		}
	}


}
