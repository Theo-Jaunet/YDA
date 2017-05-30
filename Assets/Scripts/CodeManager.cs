using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour {

	public static CodeManager instance;

	int nbActions = 0;

	static Queue<string> actionCases;

	void Update()
	{

	}


	public static Queue<string> getActions()
	{
		return actionCases;
	}

	public void setActions()
	{
		// GO = Game Objects
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Case");
		actionCases = new Queue<string>(gameObjects.Length);
		Queue<GameObject> queueTempGO = new Queue<GameObject>();
		int indexArrayGO = 0;

		// creating a temporary queue to sort easily the game objects by name
		for (int i = 0; i < gameObjects.Length; i++)
		{
			queueTempGO.Enqueue(gameObjects[i]);
		}

		bool arraySorted = false;

		int sizeIndex = gameObjects.Length;

		// loop to sort the GO
		while (!arraySorted || indexArrayGO > sizeIndex)
		{
			string stringGO = queueTempGO.Peek().ToString();
			string indexGO = stringGO.Substring(4, 1);

			if (indexArrayGO.ToString() == indexGO.ToString())
			{
				// remove the object in the queue and returns it to the temporary array
				gameObjects[indexArrayGO] = queueTempGO.Dequeue();
			}

			if (indexArrayGO >= sizeIndex)
			{
				indexArrayGO = 0;
			}

			// we can end the loop now
			if (queueTempGO.Count == 0)
			{
				arraySorted = true;
			}

			indexArrayGO++;
		}

		for (int i = 0; i < gameObjects.Length; i++)
		{
			actionCases.Enqueue(gameObjects[i].transform.GetChild(0).ToString());
		}
		/*
		foreach(string element in actionCases) { 
			print(element);
		}*/
	}

}
