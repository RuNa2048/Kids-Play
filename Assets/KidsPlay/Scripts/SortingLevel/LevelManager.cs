using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[SerializeField]
	private float _delay;

	public event Action StartingLevelEvent;
	public event Action CompletingLevelEvent;


	/// <summary>
	/// вызов происходит по нажатию на кнопку "крестика" на TrainingPanel
	/// </summary>
	public void Start/*Game*/()
	{
		StartCoroutine(Init());
	}

	IEnumerator Init()
	{
		yield return new WaitForSeconds(_delay);
		StartingLevelEvent?.Invoke();
	}

	public void CompleteGame()
	{
		CompletingLevelEvent?.Invoke();
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
