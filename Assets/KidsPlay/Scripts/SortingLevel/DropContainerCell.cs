using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropContainerCell : /*ContainerCell, IDropHandler*/ MonoBehaviour
{
	RectTransform _rectTransform;
	Image _cellImage;

	private void Start()
	{
		_rectTransform = GetComponent<RectTransform>();
		_cellImage = GetComponent<Image>();
	}

	//public ScoreManager ScoreManager;

	//public event Action SelectionEvent;

	//private void Start()
	//{
	//	ScoreManager = GetComponentInParent<ScoreManager>();
	//}

	//public override void Renderer(IItem item)
	//{
	//	nameField = item.Name;
	//	imageField.sprite = item.UIEmptyIcon;
	//}

	//public void OnDrop(PointerEventData eventData)
	//{
	//	if (eventData.pointerDrag != null)
	//	{
	//		DragContainerCell item = eventData.pointerDrag.GetComponent<DragContainerCell>();

	//		if (Name == item.Name)
	//		{
	//			SelectionEvent += ScoreManager.OnSelection;

	//			item.transform.position = transform.position;
	//			item.DisableCell();
	//		}

	//		SelectionEvent?.Invoke();
	//		SelectionEvent -= ScoreManager.OnSelection;
	//	}
	//}
}
