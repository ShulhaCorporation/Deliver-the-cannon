using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private int min = 1000;
    [SerializeField]
    private int max = 10000;
    public int generatedNumber;
    void Start()
    {
        generatedNumber = UnityEngine.Random.Range(min, max);
        label.SetText(generatedNumber + "");
    }
}
