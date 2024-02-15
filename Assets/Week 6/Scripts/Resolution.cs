using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public void Set16by9()
    {
        Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
    }

    public void SetFullHD()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }
}
