using UnityEngine;

public class DropContainer : Container
{
	[SerializeField]
	private ScoreManager _scoreManager;

	public void CheckForBinding(DragContainerCell dragCell)
	{
		foreach (DropContainerCell cell in _cells)
		{
			if (cell.Name == dragCell.Name)
			{
				bool entered = cell.rect.Contains(dragCell.RectTransform().position);

				if (entered)
				{
					dragCell.DisableCell(cell.RectTransform().position);
					_scoreManager.UpdateScore();
				}
			}
		}
	}
}
