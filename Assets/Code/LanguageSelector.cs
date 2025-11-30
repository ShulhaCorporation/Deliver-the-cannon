using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSelector : MonoBehaviour, ISave
{
    private TMP_Dropdown dropdown;
     private string languageCode = "";
    private string[] languageCodes = new string[3] {"en", "tok", "uk"};
    private Dictionary<string, int> languageValues = new Dictionary<string, int>()
    {
        {"en", 0},
        {"tok", 1},
        {"uk", 2},
    };
      public void ChangeLanguage(int dropdownLanguageId)
     {  
        if(dropdownLanguageId >= 0 &&  dropdownLanguageId < languageCodes.Length) 
        {
            Debug.Log("мова змінилася");
            languageCode = languageCodes[dropdownLanguageId];
            SaveManager.instance.SaveGame();
        }
    }
    private void Start()
    {
        Debug.Log("Стартонули");
        dropdown = GetComponent<TMP_Dropdown>();
        SaveManager.instance.LoadGame();
    }
    public void Save(GameData data)
    {
        string oldcode = data.languageCode;
        data.languageCode = languageCode;
        Debug.Log($"{oldcode} -> {data.languageCode}");
    }

    public void Load(GameData data)
    {
        languageCode = data.languageCode;
          if(dropdown == null)
        {
            Debug.Log("dropdown = NULL");
            return;
        }
        if (!languageValues.ContainsKey(languageCode))
        {
            Debug.Log("Нестандартний мовний код: " + languageCode);
            dropdown.value = 0;
            languageCode = languageCodes[0];
            return;
        }
        dropdown.value = languageValues[languageCode];
        Debug.Log($"успішне завантаження {languageValues[languageCode]}");
    }
}
