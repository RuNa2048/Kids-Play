using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragContainer : Container
{
	[Header("References: DragContainer")]
	[SerializeField]
	private ScoreManager _scoreManager;

	protected void Awake()
	{
		_scoreManager.ChangeStageEvent += ReturnCellInStartCondition;
	}

	public void ReturnCellInStartCondition()
	{
		foreach (DragContainerCell cell in _cells)
		{
			cell.EnableCell();
		}
	}

	public void EnableAllCells()
	{
		foreach (DragContainerCell cell in _cells)
		{
			cell.enabled = true;

		}
	}

	public void DisableCell(DragContainerCell cell)
	{
		cell.StopAllCoroutines();
		cell.enabled = false;
	}
}
