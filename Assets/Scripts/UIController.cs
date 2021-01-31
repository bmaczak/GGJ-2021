using UnityEngine;

public class UIController : MonoBehaviour
{
	public CanvasGroup pauseMenu;
	public CanvasGroup inGameMenu;

	bool paused;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ShowPause(!paused);
		}
	}

	public void ShowPause(bool pasued)
	{
		this.paused = pasued;
		Time.timeScale = pasued ? 0 : 1;
		Enable(pauseMenu, pasued);
		Enable(inGameMenu, !pasued);
	}

    void Enable(CanvasGroup canvasGroup, bool enabled)
    {
        canvasGroup.alpha = enabled ? 1 : 0;
        canvasGroup.interactable = enabled;
        canvasGroup.blocksRaycasts = enabled;
    }

	public void Exit()
	{
		Application.Quit();
	}
}
