using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    #region Var

    [SerializeField]
    private GameObject MenuCanvas;

    [SerializeField]
    private GameObject MenuButton;

    [SerializeField]
    private Slider BGM_Slider;

    [SerializeField]
    private Slider Sound_Slider;


    [SerializeField]
    private AudioSource BGM;

    [SerializeField]
    private AudioSource Sound;

    #endregion

    public void OpenMenu()
    {
        MenuCanvas.SetActive(true);
        MenuButton.SetActive(false);
    }

    public void CloseMenu()
    {
        MenuButton.SetActive(true);
        MenuCanvas.SetActive(false);
    }

}
