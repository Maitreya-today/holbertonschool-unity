using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	//================================================================================
	// Public Variables ==============================================================
	//================================================================================
	public GameObject pauseCanvas;

	//================================================================================
	// Private Variables =============================================================
	//================================================================================
	

	//================================================================================
	// Start is called before the first frame update =================================
	//================================================================================
	void Start()
	{
		

	}

	//================================================================================
	// Update is called once per frame ===============================================
	//================================================================================
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (pauseCanvas.activeSelf == true)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}

	}

	//================================================================================
	// Coroutines ====================================================================
	//================================================================================


	//================================================================================    
	// Functions =====================================================================
	//================================================================================
	public void Pause()
	{
		Time.timeScale = 0;
		pauseCanvas.SetActive(true);
		
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseCanvas.SetActive(false);
		
	}

	public void Restart()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Options()
	{
		PlayerPrefs.SetString("lastScene", SceneManager.GetActiveScene().name);
		SceneManager.LoadScene("Options");
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

}