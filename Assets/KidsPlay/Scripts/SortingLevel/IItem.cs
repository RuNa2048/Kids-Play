using UnityEngine;

public interface IItem
{
    string Name { get; }
	Sprite UIMainIcon { get; }
	Sprite UIEmptyIcon { get; }
}
