using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class CameraManager : MonoBehaviour
{
    private enum VirtualCameras
    {
        NoSelection = -1,
        FreeCamera = 0,
        FollowCamera = 1,
    }

    [SerializeField]
    private List<CinemachineVirtualCamera> _virtualCameras;

    public Transform ActiveCamera { get; private set; }
    public UnityEvent ActiveCameraChanged;

    private VirtualCameras _currentCamera = VirtualCameras.NoSelection;

    VirtualCameras CameraKeyPressed
    {
        get
        {
            for (int i = 0; i < _virtualCameras.Count; ++i)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)) return (VirtualCameras)i;
            }

            return VirtualCameras.NoSelection;
        }
    }

    void Awake()
    {
        ActiveCameraChanged = new UnityEvent();
    }

    void Start()
    {
        SetActiveCamera(VirtualCameras.FreeCamera);
    }

    private void Update()
    {
        VirtualCameras selectedCamera = CameraKeyPressed;
        if (selectedCamera != VirtualCameras.NoSelection)
        {
            SetActiveCamera(selectedCamera);
        }
    }
    private void SetActiveCamera(VirtualCameras selectedCamera)
    {
        if (selectedCamera == _currentCamera || _virtualCameras == null || (int)selectedCamera >= _virtualCameras.Count)
            return;

        _currentCamera = selectedCamera;

        for (int i = 0; i < _virtualCameras.Count; i++)
        {
            bool isActive = (i == (int)selectedCamera);
            _virtualCameras[i].gameObject.SetActive(isActive);

            if (isActive)
            {
                ActiveCamera = _virtualCameras[i].transform;
                ActiveCameraChanged.Invoke();
            }
        }
    }
}

