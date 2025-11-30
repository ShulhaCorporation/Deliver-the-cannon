using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class TextFinder : MonoBehaviour, ISave
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private string key;
    private string languageCode;
   private Dictionary<string, string> english = new Dictionary<string, string>
   {
       {"gameName", "Deliver the cannon"},
       {"languageSettingsLabel", "Language:"},
       {"currentLanguage", "English"},
       {"settings", "Settings"},
       {"newGame", "New game"},
       {"resetLabel", "You are going to delete your progress"},
       {"enterThisNumber", "Enter this number to continue"},
   };
    private Dictionary<string, string> tokipona = new Dictionary<string, string>
   {
       {"gameName", "o pana e ilo utala!"},
       {"languageSettingsLabel", "Language/toki:"},
       {"currentLanguage", "toki pona"},
       {"settings", "nasin musi"},
       {"newGame", "musi sin"},
       {"resetLabel", "sina kama weka e pali sina"},
       {"enterThisNumber", "o sitelen e nanpa ni"},
   };
   private Dictionary<string, string> ukrainian= new Dictionary<string, string>
   {
       {"gameName", "Достав гармату"},
       {"languageSettingsLabel", "Language/Мова"},
       {"currentLanguage", "Українська"},
       {"settings", "Налаштування"},
       {"newGame", "Нова гра"},
       {"resetLabel", "Ви збираєтеся анулювати весь прогрес"},
       {"enterThisNumber", "Введіть це число, щоб продовжити"},
   };
    private void Refresh()
    {
        switch (languageCode) {
            case "en":
                text.SetText(english[key]);
                break;
            case "tok":
                text.SetText(tokipona[key]);
                break;
            case "uk":
                text.SetText(ukrainian[key]); 
                break;
            default:
                text.SetText(english[key]);
                Debug.Log("Невідомий мовний код!");
                break;
    }
    }

    
    public void Save( GameData data)
    {
        //��� ����� ������� ���� ��������
    }

    public void Load(GameData data)
    {
        this.languageCode = data.languageCode;
        Refresh();
    }
}
