using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Container : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private GameStage _gameStage;
	[SerializeField]
	protected List<ContainerCell> _cells;

	[SerializeField]
	protected ContainerCell _CellPrefab;

	protected virtual void Start()	
	{
		_gameStage.ChoiceEvent += Renderer;
	}

	protected void Renderer(List<AssetItem> assetItems)
	{
		List<AssetItem> items = OrderRandomization(assetItems);

		for (int i = 0; i <= _cells.Count - 1; i++)
		{
			_cells[i].Renderer(items[i]);
		}
	}

	protected List<AssetItem> OrderRandomization(List<AssetItem> assetItems)
	{
		List<AssetItem> items = assetItems;

		for (int i = items.Count - 1; i >= 1; i--)
		{
			int j = Random.Range(0, items.Count - 1);

			var tempCell = items[j];
			items[j] = items[i];
			items[i] = tempCell;
		}

		return items;
	}
}
