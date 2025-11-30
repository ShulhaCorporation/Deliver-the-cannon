using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadChecker : MonoBehaviour
{ //Цей клас каже менеджеру зберігання завантажитися під час першого запуску гри, тому що подія sceneLoaded тоді не спрацьовує
    private bool isEventCalled = false;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        if (!isEventCalled)
        {
            SaveManager.instance.FirstTimeLoad();
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode uselessvariablewhytfdoesitexist)
    {
        isEventCalled = true;
    }
   }
