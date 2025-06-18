using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	[SerializeField] private Button repeatButton;

	void Start()
	{
		repeatButton.onClick.AddListener(() => RepeatScene());
	}

	private void RepeatScene()
	{
		StartCoroutine(LoadSceneCoroutine(SceneManager.GetActiveScene().name));
	}
	
	private IEnumerator LoadSceneCoroutine(string sceneName)
	{
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

		while (!asyncOperation.isDone)
		{
			Debug.Log($"Viajando a la siguiente escena {asyncOperation.progress}%");
			yield return null;
		}
	}
}
