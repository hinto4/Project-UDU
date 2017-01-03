using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionbarHandler : MonoBehaviour
{
    public GameObject ActionbarUI;          // UI actionbar element from Canvas.

    private readonly List<GameObject> _slotsList = new List<GameObject>();
    private ItemController _itemController;
    private GameObject _clickedSlot;

    void Start()
    {
        _itemController = GameObject.FindObjectOfType<ItemController>();

        foreach (var slot in ActionbarUI.GetComponentsInChildren<RectTransform>())
        {
            if (slot.gameObject != ActionbarUI.gameObject)
            {
                _slotsList.Add(slot.gameObject);
            }
        }
    }

    public void ActivateItem(GameObject item)
    {
        _itemController.ActiveItem = item;
    }
}