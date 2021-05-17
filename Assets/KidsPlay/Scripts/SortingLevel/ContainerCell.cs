using UnityEngine;
using UnityEngine.UI;

public abstract class ContainerCell : MonoBehaviour
{
	[SerializeField]
	protected string nameField;
	public string Name { get { return nameField; } }

	public Image imageField;
	protected RectTransform rectTransform;
	public RectTransform RectTransform() => rectTransform;
	public Rect rect;


	protected virtual void OnEnable()
	{
		imageField = GetComponent<Image>();
		rectTransform = GetComponent<RectTransform>();

		rect = GetWorldSpaceRect(rectTransform);
	}

	public abstract void Renderer(IItem item);

	public Rect GetWorldSpaceRect(RectTransform rectTransform)
	{
		Rect rect = rectTransform.rect;
		rect.center = rectTransform.TransformPoint(rect.center);
		rect.size = rectTransform.TransformVector(rect.size);
		return rect;
	}
}
