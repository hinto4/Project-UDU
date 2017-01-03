using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ItemController : MonoBehaviour
{
    public GameObject ActiveItem;

    private CanvasTextManager _canvasTextManager;

    private bool _mouseOverHover;

    void Start()
    {
        _canvasTextManager = GameObject.FindObjectOfType<CanvasTextManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ActiveItem == null && !_mouseOverHover)
        {
            _canvasTextManager.UpdateCanvasTextValue(_canvasTextManager.AnnouncerText, "No item selected!");
            _canvasTextManager.FadeText(_canvasTextManager.AnnouncerText, 1f);
        }
        else if(Input.GetMouseButtonDown(0) && !_mouseOverHover)
        {
            Instantiate(ActiveItem, this.transform.position, Quaternion.identity);
        }
    }

    public void OnMouseHover()
    {
        _mouseOverHover = true;
    }

    public void OnMouseExit()
    {
        _mouseOverHover = false;
    }
}