using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private GameStage _gameStage;
	[SerializeField]
	private Transform _dropContainer;
	[SerializeField]
	private Transform _dragContainer;

	[Header("Cells")]
	private List<GameObject> _dropCells;
	private List<GameObject> _dragCells;


	[SerializeField]
	private ContainerCell _CellPrefab;
	[SerializeField]
	private GameObject _dropCellPrefab;

	private void Awake()	
	{
		_gameStage.ChoiceEvent += Renderer;
	}

	public void Renderer(List<AssetItem> items)
	{
		//foreach (Transform child in transform)
		//	Destroy(child.gameObject);

		//OrderRandomization(ref items);

		items.ForEach(item =>
	   {
		   var dragCell = Instantiate(_CellPrefab, transform);
		   var dropCell = Instantiate(_dropCellPrefab, _dropContainer);
		   dragCell.Renderer(item, dropCell);
	   });


	}

	private void OrderRandomization(ref List<AssetItem> items)
	{
		for (int i = items.Count - 1; i >= 1; i--)
		{
			int j = Random.Range(0, items.Count - 1);

			var tempCell = items[j];
			items[j] = items[i];
			items[i] = tempCell;
		}
	}
}
