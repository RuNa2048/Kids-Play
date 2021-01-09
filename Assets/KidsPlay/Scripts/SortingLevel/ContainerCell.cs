using UnityEngine;
using UnityEngine.UI;

public abstract class ContainerCell : MonoBehaviour
{
	[SerializeField]
	protected string nameField;

	public string Name { get { return nameField; } }

	protected Image imageField;
	public RectTransform rectTransform { get; private set; }

	protected virtual void OnEnable()
	{
		imageField = GetComponent<Image>();
		rectTransform = GetComponent<RectTransform>();
	}

	public abstract void Renderer(IItem item, GameObject dropCell);
}
