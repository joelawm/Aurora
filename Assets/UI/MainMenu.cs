using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	//Campaign currently leads to the sandbox testing grounds
	public void CampaignGame ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		//Send a debug message
		Debug.Log("Quit");
		Application.Quit();
	}
}
