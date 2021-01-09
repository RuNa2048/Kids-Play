using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropContainer : MonoBehaviour
{
	List<DropContainerCell> dropCells;

	public RectTransform SeacrhEmptyCell(string nameCell)
	{
		for (int i = 0; i <= dropCells.Count; i++)
		{
			if (dropCells[i].Name == name)
				return dropCells[i].rectTransform;
		}
		return null;
	}
}
