using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels;
    public XRSimpleInteractable button;
    public GameObject FishObj;
    public int index;
    void Start()
    {
        button.selectEntered.AddListener((_) => ButtonClick());
        index = -1;
    }

    public void ButtonClick()
    {
        if (index != -1) panels[index].SetActive(false);
        index++;
        if (index == panels.Length)
        {
            FishObj.SetActive(true);
            index = -1;
            return;
        }
        panels[index].SetActive(true);
    }

}
