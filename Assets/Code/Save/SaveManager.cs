using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Data;
using UnityEngine.SceneManagement;
using System;
public class SaveManager : MonoBehaviour
{
    private readonly string filename = "savefile";
    private SaveFileManager saveFileManager;
    private GameData gameData;
    public static SaveManager instance { get; private set; }
    private List<ISave> saveSystemObjects;
    private void Awake()
    {   if(instance != null)
        {
            Debug.Log("На сцені вже є зберігач, тому новий зберігач знищили.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;        
        DontDestroyOnLoad(this.gameObject);
        this.saveFileManager = new SaveFileManager(Application.persistentDataPath, filename);
    }
    private void OnEnable()
    {
        Debug.Log("enable");
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }
    private void OnDisable()
    {   
        Debug.Log("disable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;       
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        Debug.Log("loaded");
        this.saveSystemObjects = FindAllSaveSystemObjects();
        LoadGame();
    }
    public void OnSceneUnloaded(Scene scene)
    {  
        Debug.Log("unloaded");
        SaveGame(); 
    }
       private void OnApplicationQuit()
    { 
        SaveGame();
        Debug.Log("вихід");
    }
    public void NewGame()
    {
        this.gameData = new GameData();
        SaveGame();
    }
    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("Не можна зберегти порожні дані");
            return;
        }
        if (this.saveSystemObjects != null)
        {
            foreach (ISave saveSystemObject in this.saveSystemObjects)
            {
                saveSystemObject.Save( gameData);
            }
        }
        saveFileManager.Save(gameData); 
    }
    
    public void LoadGame()
     {
        this.gameData = saveFileManager.Load();
     if(this.gameData == null)
        {
            Debug.Log("Програма завантажила порожні дані");
            return;
        }
        if (this.saveSystemObjects != null)
        {
            foreach (ISave saveSystemObject in this.saveSystemObjects)
            {
                saveSystemObject.Load(gameData);
            }
        }
    }
    private List<ISave> FindAllSaveSystemObjects()
    {
        IEnumerable<ISave> saveSystemObjects = FindObjectsOfType<MonoBehaviour>(true)
                .OfType<ISave>();
        return new List<ISave>(saveSystemObjects);
    }
public void FirstTimeLoad()
    {
        this.saveSystemObjects = FindAllSaveSystemObjects();
        LoadGame();
    }
}
