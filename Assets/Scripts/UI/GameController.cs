using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

	public bool isGameStartedFirstTime; // used for initialization

	public static GameController instance;
	private GameData data;

	public bool isMusicOn; // keep track of the music

	public int selectedPlayer; // which skin has been selected
	public int highScore;

	public int currentScore;
	public String name;

	public bool[] players; //how much skins are unlocked ?
	public bool[] achievements;

	void Start () {
		
	}

	private void Awake()
	{
		//MakeSingleton();
		InitializeGameVariables();
	}

	public int getPlayed(){
		return this.data.getSelectedPlayer();
	}
	public void setPlayed(int character){
		print (character);
		this.data.setSelectedPlayer(character);
	}

	public String getName(){
		return this.data.getName ();
	}

	public void setName(String nom){
		print (nom);
		this.name = nom;
	}
	void InitializeGameVariables()
	{
		Load();

		if(data != null)
		{
			isGameStartedFirstTime = data.getIsGameStartedFirstTime();
		}
		else
		{
			isGameStartedFirstTime = true;
		}

		if (isGameStartedFirstTime)
		{
			// The game is started for the first time
			// Initialisation of the variables
			highScore = 0;

			selectedPlayer = 0;

			name = "Bob";

			isGameStartedFirstTime = false;
			isMusicOn = false;

			players = new bool[2];
			achievements = new bool[8];

			players[0] = true;
			for(int i = 1; i < players.Length; i++)
			{
				players[i] = false;
			}

			for(int i = 0; i < achievements.Length; i++)
			{
				achievements[i] = false;
			}

			data = new GameData();

			data.setHighScore(highScore);
			data.setSelectedPlayer(selectedPlayer);
			data.setIsGameStartedFirstTime(isGameStartedFirstTime);
			data.setIsMusicOn(isMusicOn);
			data.setPlayers(players);
			data.setAchivements(achievements);

			Save();

			Load();
		}
		else
		{
			// The game has been played already so load game data

			highScore = data.getHighScore();
			selectedPlayer = data.getSelectedPlayer();
			isGameStartedFirstTime = data.getIsGameStartedFirstTime();
			isMusicOn = data.getIsGameStartedFirstTime();
			players = data.getPlayers();
			achievements = data.getAchievements();
		}
	}

	public void MakeSingleton()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void Load()
	{
		FileStream file = null;

		try
		{
			BinaryFormatter bf = new BinaryFormatter();
			// We open the encrypted save file
			file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
			data = (GameData)bf.Deserialize(file);

		} catch(Exception e)
		{

		}finally
		{
			if(file != null)
			{
				file.Close();
			}
		}
	}

	/**
	 *  Encrypted saves, so that the lurky hacky players 
	 *  can't hack their stats :3
	 **/
	public void Save()
	{
		FileStream file = null;
		try
		{
			BinaryFormatter bf = new BinaryFormatter();
			// we create a encrypted file with all the saves from the current player
			file = File.Create(Application.persistentDataPath + "/GameData.dat");  

			if(data != null)
			{
				// setting our data 
				data.setHighScore(highScore);
				data.setIsGameStartedFirstTime(isGameStartedFirstTime);
				data.setPlayers(players);
				data.setSelectedPlayer(selectedPlayer);
				data.setAchivements(achievements);
				data.setIsMusicOn(isMusicOn);

				bf.Serialize(file, data);
			}
		}
		// no crash if the file don't yet exists
		catch (Exception e)
		{
			print (e);
		}
		// executed no matter what
		finally
		{
			if(file != null)
			{
				file.Close();
			}
		}
	}
	
}

[Serializable]
class GameData
{
	private bool isGameStartedFirstTime; // used for initialization

	private bool isMusicOn; // keep track of the music

	private int selectedPlayer; // which skin has been selected
	private int highScore;
	private String name;

	private bool[] players; //how much skins are unlocked ?
	private bool[] achievements;


	// GETTERS - SETTERS
	public void setIsGameStartedFirstTime(bool isGameStartedFirstTime)
	{
		this.isGameStartedFirstTime = isGameStartedFirstTime;
	}

	public bool getIsGameStartedFirstTime()
	{
		return this.isGameStartedFirstTime;
	}

	public void setIsMusicOn(bool isMusicOn)
	{
		this.isMusicOn = isMusicOn;
	}

	public bool getIsMusicOn()
	{
		return this.isMusicOn;
	}
	public String getName(){
		return this.name;
	}
	public void setName(String nom){
		this.name = nom;
	}

	public void setSelectedPlayer(int selectedPlayer)
	{
		this.selectedPlayer = selectedPlayer;
	}

	public int getSelectedPlayer()
	{
		return this.selectedPlayer;
	}

	public void setHighScore(int highScore)
	{
		this.highScore = highScore;
	}

	public int getHighScore()
	{
		return this.highScore;
	}

	public bool[] getPlayers()
	{
		return this.players;
	}

	public void setPlayers(bool[] players)
	{
		this.players = players;
	}

	public void setAchivements(bool[] achievements)
	{
		this.achievements = achievements;
	}

	public bool[] getAchievements()
	{
		return this.achievements;
	}

}