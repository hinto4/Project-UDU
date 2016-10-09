using UnityEngine;
using System.Collections;

public class UserInterfaceController : MonoBehaviour
{
    public GameObject TestPanel;

    private PointsManager _pointsManager;
    private bool _isPanelOpen;

    void Start()
    {
        _pointsManager = GameObject.FindObjectOfType<PointsManager>();
    }

	void Update()
    {
        if(_pointsManager.CollectedPoints >= 2 && !_isPanelOpen)
        {
            SetPanelStatus(true);
            _isPanelOpen = true;
        }
    }

    public void SetPanelStatus(bool value)
    {
        TestPanel.SetActive(value);
    }
}
