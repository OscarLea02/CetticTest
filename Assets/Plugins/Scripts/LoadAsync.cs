using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAsync : MonoBehaviour {

	public Slider loadingBar;


	private AsyncOperation async;


	public void Start()
	{
		StartCoroutine(LoadLevelWithBar());
	}


	IEnumerator LoadLevelWithBar ()
	{
		async = Application.LoadLevelAsync("Map1");
		while (!async.isDone)
		{
			loadingBar.value = async.progress;
			yield return null;
		}
	}
}
