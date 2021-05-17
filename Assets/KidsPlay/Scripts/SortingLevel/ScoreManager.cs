using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	private GameStage _gameStage;
	[SerializeField]
	private int _score;

	[SerializeField]
	int _itemsCount;

	public event Action ChangeStageEvent;

	private void Start()
	{
		_itemsCount = _gameStage.GetCurrentCountItems();
	}

	public void UpdateScore()
	{
		print(1);
		_score++;

		if (_score >= _itemsCount)
		{
			_score = 0;
			ChangeStageEvent?.Invoke();
		}
	}
}
