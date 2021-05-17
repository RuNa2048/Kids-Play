using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragContainerCell : ContainerCell, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[Header("References")]
	[SerializeField]
	private DropContainer _dropContainer;
	[SerializeField]
	private Transform _dragginParent;
	[SerializeField]
	Transform _standartParent;

	[Header("Moving")]
	[SerializeField]
	private float _cellSpeed;

	bool _isFree = true;

	public Vector2 StartingPosition { get; private set; }

	private void Start()
	{
		StartingPosition = rectTransform.position;
	}

	public override void Renderer(IItem item)
	{
		print(3);

		nameField = item.Name;
		imageField.sprite = item.UIMainIcon;

		rectTransform.position = StartingPosition;
	}

	public void OnPointerDown(PointerEventData eventData)
	{

		transform.SetParent(_dragginParent);
		_isFree = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
		_dropContainer.CheckForBinding(this);

		if (!_isFree)
			return;

		rectTransform.anchoredPosition += eventData.delta;
	}

	public void OnPointerUp(PointerEventData eventData)
	{

		transform.SetParent(_standartParent);

		if (_isFree)
		{
			StartCoroutine(MoveTo(StartingPosition));
		}
	}

	private IEnumerator MoveTo(Vector2 position)
	{
		float step = _cellSpeed * Time.deltaTime;
		while ((Vector2)rectTransform.position != position)
		{
			rectTransform.position = Vector2.MoveTowards(rectTransform.position, position, step);

			yield return null;
		}
	}

	public void EnableCell()
	{
		StopAllCoroutines();

		//rectTransform.position = StartingPosition;
		enabled = true;
	}

	public void DisableCell(Vector2 position)
	{
		print(2);
		_isFree = false;
		transform.SetParent(_standartParent);

		StopAllCoroutines();
		StartCoroutine(MoveTo(position));

		enabled = false;
	}
}
