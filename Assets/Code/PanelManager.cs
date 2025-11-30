using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private bool mode;
  public void TogglePanel()
    {
        panel.SetActive(mode);
    } 
}
