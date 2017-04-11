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
		ConstructFunctionDatabase();

		Debug.Log(database[1].Title);
	}

	void ConstructFunctionDatabase()
	{
		for (int i = 0; i < functionData.Count; i++)
		{
			database.Add(new Functions((int)functionData[i]["id"], functionData[i]["title"].ToString(), (int)functionData[i]["value"]));
		}
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
