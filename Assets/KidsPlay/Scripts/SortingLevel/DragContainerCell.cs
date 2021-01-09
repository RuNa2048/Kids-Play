using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragContainerCell : ContainerCell, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[SerializeField]
	private DropContainer _dropContainer;
	//

	[SerializeField]
	private float _cellSpeed;

	private bool _isFree = true;
	private int _syblingIndex;

	CanvasGroup _canvasGroup;
	Transform _draggingParent;
	Transform _originalParent;
	Vector2 _startPosition;
	Image _emptyCell;

	GameObject _dropCell;

	float _attachmentArea;

	public override void Renderer(IItem item, GameObject dropCell)
	{
		print(1);
		CreateCell();

		nameField = item.Name;
		imageField.sprite = item.UIMainIcon;

		_dropCell = dropCell;

		_attachmentArea = (_dropCell.rect.width * _dropCell.rect.height) * 1.2f;
	}

	public void CreateCell()
	{
		_canvasGroup = gameObject.AddComponent(typeof(CanvasGroup)) as CanvasGroup;

		_startPosition = transform.position;
		_draggingParent = FindObjectOfType<BusyCells>().transform;
		_originalParent = transform.parent;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!_isFree)
			return;

		_syblingIndex = transform.GetSiblingIndex();

		transform.SetParent(_draggingParent);
		//rectTransform.localScale *= 1.2f;
		_canvasGroup.blocksRaycasts = false;

		_emptyCell = Instantiate(imageField, _originalParent);
		_emptyCell.color = Color.clear;

		_emptyCell.transform.SetSiblingIndex(_syblingIndex);
	}

	public void OnDrag(PointerEventData eventData)
	{
		//if (Vector2.Distance(rectTransform.position, _dropCell.position) <= _attachmentArea)
		//{
		//	rectTransform.position = _dropCell.position;
		//	DisableCell();
		//}
		rectTransform.anchoredPosition += eventData.delta;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!_isFree)
			return;

		StartCoroutine(ReturnCellInStartPos());
	}

	private IEnumerator ReturnCellInStartPos()
	{
		float step = _cellSpeed * Time.deltaTime;
		while ((Vector2)rectTransform.position != (Vector2)_emptyCell.transform.position)
		{
			rectTransform.position = Vector2.MoveTowards(rectTransform.position, _emptyCell.transform.position, step);


			yield return null;
		}
		Destroy(_emptyCell.gameObject);

		transform.SetParent(_originalParent);
		//rectTransform.localScale = new Vector2(1f, 1f);
		transform.SetSiblingIndex(_syblingIndex);

		_canvasGroup.blocksRaycasts = true;
	}

	public void DisableCell()
	{
		_isFree = false;
		_canvasGroup.blocksRaycasts = false;
		rectTransform.localScale = Vector3.one;
		StopAllCoroutines();
	}
}
