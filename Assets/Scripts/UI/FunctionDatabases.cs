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

	void ConstructFunctionDatabase()
	{

	}

}

public class Functions
{
	public int ID { get; set; }
	public string Title { get; set; }
	public int Value { get; set; }

	public Functions(int id, string title, int value)
	{
		this.ID = id;
		this.Title = title;
		this.Value = value;
	}

}
