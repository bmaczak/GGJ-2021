using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Quit();
	}
	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void Quit()
	{
		Application.Quit();
	}
}
