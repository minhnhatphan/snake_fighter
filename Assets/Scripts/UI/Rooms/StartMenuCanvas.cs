using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCanvas : MonoBehaviour
{
    [SerializeField]
    private StartMenu _startMenu = null;
    private RoomsCanvases _roomCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomCanvases = canvases;
        _startMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
