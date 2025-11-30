using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField]
    private SaveManager saveManager;
    [SerializeField]
    private TextMeshProUGUI inputField;
    [SerializeField]
    private RandomNumberGenerator rng;
    [SerializeField]
    private GameObject panel;
    public void VerifyPassword()
    {
        int password = rng.generatedNumber;
        int input = 0;
        string cleanInput = "";
        //Unity додає зайвий пробіл у кінці тексту, тому краще провести валідацію всього вводу і отримати чисте число
        for (int i = 0; i < inputField.text.Length; i++)
        {
            if (Char.IsDigit(inputField.text[i]))
            {
                cleanInput += inputField.text[i];
            }
        }
        int.TryParse(cleanInput, out input);
        if (input == password)
        {
            saveManager.NewGame();
            panel.SetActive(false);
        }
       
       }
}
