using UnityEngine.SceneManagement;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
	public void LoadLevel(int number)
	{
		SceneManager.LoadScene(number);
	}
}
