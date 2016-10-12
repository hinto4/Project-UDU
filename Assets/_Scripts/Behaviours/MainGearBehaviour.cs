using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MainGearBehaviour : MonoBehaviour
{
    private BoxMovementController _playerBox;

    void Start()
    {
        _playerBox = GameObject.FindObjectOfType<BoxMovementController>();
    }

    void Update()
    {
        transform.localRotation = _playerBox.transform.rotation;
    }

}
