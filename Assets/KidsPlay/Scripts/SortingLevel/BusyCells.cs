using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyCells : MonoBehaviour
{
	[SerializeField]
	private ScoreManager _scoreManager;

	private void Awake()
	{
		_scoreManager.ChangeStageEvent += RemoveAllCells;
	}

	public void RemoveAllCells()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
}
