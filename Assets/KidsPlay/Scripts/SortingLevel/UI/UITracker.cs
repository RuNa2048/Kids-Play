using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITracker : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private LevelManager _levelManager;

	[Header("Panels")]
	[SerializeField]
	private GameObject _trainingPanel;
	[SerializeField]
	private GameObject _completeGamePanel;

	private void Awake()
	{
		_levelManager.CompletingLevelEvent += ShowCompleteGamePanel;
		_levelManager.StartingLevelEvent += ShutdownTrainingPanel;
	}

	private void ShowTrainingPanel()
	{
		_trainingPanel.SetActive(true);
	} 

	private void ShutdownTrainingPanel()
	{
		_trainingPanel.SetActive(false);
	}

	private void ShowCompleteGamePanel()
	{
		_completeGamePanel.SetActive(true);
	}
}
