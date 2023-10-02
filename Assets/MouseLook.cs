using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float HorizontalSens = 9.0f;
    [SerializeField] private float VerticalSens = 9.0f;
    [SerializeField] private float minimunVert = -45.0f;
    [SerializeField] private float maximumVert = 45.0f;

    private float _rotationX = 0;
    private float _rotationY = 0;

    void Update()
    {
        _rotationY = transform.eulerAngles.y + Input.GetAxis("Mouse X") * HorizontalSens;   

        _rotationX -= Input.GetAxis("Mouse Y") * VerticalSens;
        _rotationX = Mathf.Clamp(_rotationX, minimunVert, maximumVert);   

        transform.eulerAngles = new Vector3(_rotationX, _rotationY, 0);
    }
}