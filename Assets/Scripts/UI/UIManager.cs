using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public bool paused;
    private GameObject textPauseGame;
    private GameObject pauseRestartInput;
	private GameObject button_return;
	private GameObject button_replay;

	private UIManager() { }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start()
    {
        paused = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
		pauseRestartInput = GameObject.Find("b_GetMenu");

		if (textPauseGame != null){
			Time.timeScale = 1;
		}

    }

    //Reloads the Level
    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }

    }

    public void Play()
    {
		Invoke("PlayTheGame", 0.5f);
    }

	// needs delay to create Beziers curves
	public void PlayTheGame()
	{
		SceneManager.LoadScene(3);
	}
		
}
