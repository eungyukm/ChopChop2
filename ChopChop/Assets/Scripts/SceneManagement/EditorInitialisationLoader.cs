﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script loads the initial Scene, to allow to start the game from any gameplay Scene
/// </summary>
public class EditorInitialisationLoader : MonoBehaviour
{
#if UNITY_EDITOR
	public GameSceneSO initializationScene;
	public int targetFramerate = 0; // For debugging purposes

	private void Awake()
	{
		Application.targetFrameRate = targetFramerate; // For debugging purposes

		for (int i = 0; i < SceneManager.sceneCount; ++i)
		{
			Scene scene = SceneManager.GetSceneAt(i);
			if (scene.name == initializationScene.sceneName)
			{
				return;
			}
		}
		SceneManager.LoadSceneAsync(initializationScene.sceneName, LoadSceneMode.Additive);
	}
#endif
}
