using System;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DropContainerCell : ContainerCell
{
	public override void Renderer(IItem item)
	{
		nameField = item.Name;
		imageField.sprite = item.UIEmptyIcon;
	}
}
