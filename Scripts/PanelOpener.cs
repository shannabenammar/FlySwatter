using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour{

    public GameObject Panel;
    /*
    public GameObject EasyPanel, MediumPanel, HardPanel;
    public Image EasyPic, MediumPic, HardPic;
    public float r_dark, g_dark, b_dark, a_dark;
    public float r_clear, g_clear, b_clear, a_clear;
    Color dark;
    Color clear;
    */

    void Start()
    {
       // dark = new Color(r_dark, g_dark, b_dark, a_dark);
      //  clear = new Color(r_clear, g_clear, b_clear, a_clear);
       // clickEasy();
    }

    public void OpenPanel()
    {

        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);


        }
    }
}
