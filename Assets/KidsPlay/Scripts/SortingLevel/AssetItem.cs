using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem :ScriptableObject, IItem
{
	public string Name => _name;
	public Sprite UIMainIcon => _mainIcon;
	public Sprite UIEmptyIcon => _emptyIcon;

	[SerializeField]
	private string _name;
	[SerializeField]
	private Sprite _mainIcon;
	[SerializeField]
	private Sprite _emptyIcon;
}
