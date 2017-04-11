using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;
using System.IO;

public class FunctionDatabases : MonoBehaviour {
	private List<Functions> database = new List<Functions>();
	private JsonData functionData;

	void Start()
	{
		functionData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Functions.json"));
	}

}

public class Functions
{

}
