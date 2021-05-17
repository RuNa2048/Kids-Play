﻿using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Stage
{
	public List<AssetItem> Items; 
}

public class GameStage : MonoBehaviour
{
	[SerializeField]
	public List<Stage> Stages;

	[Header("References")]
	[SerializeField]
	private ScoreManager _scoreManager;
	[SerializeField]
	private LevelManager _levelManager;

	[Header("Stage Parametres")]
	[SerializeField]
	private int _numCurrentStage = 0;

	int _numStages;

	public int GetCurrentCountItems() => Stages[_numCurrentStage].Items.Count;

	public event Action<List<AssetItem>> ChoiceEvent;

	private void Start()
	{
		_levelManager.StartingLevelEvent += StartFirstStage;
	}

	public void StartFirstStage()
	{
		ChoiceEvent?.Invoke(Stages[_numCurrentStage].Items);

		_scoreManager.ChangeStageEvent += OnChange;

		_numStages = Stages.Count;
	}

	private void OnChange()
	{
		_numCurrentStage++;

		if (_numCurrentStage == _numStages)
		{
			_levelManager.CompleteGame();

			return;
		}
			
		ChoiceEvent?.Invoke(Stages[_numCurrentStage].Items);
	}
}
