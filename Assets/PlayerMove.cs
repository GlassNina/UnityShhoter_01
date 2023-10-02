using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]                          //1

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 6.0f;                        //2

    private CharacterController _characterController;                    //3

    void Start()
    {
        _characterController = GetComponent<CharacterController>();      //4
    }
    void Update()
    {
        MoveInput();                                                     //5
    }
    private void MoveInput()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;             //6
        float deltaZ = Input.GetAxis("Vertical") * _speed;               //6
        
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);               //7
        movement = Vector3.ClampMagnitude(movement, _speed);             //8
        movement *= Time.deltaTime;                                      //9
        movement = transform.TransformDirection(movement);               //10
        
        _characterController.Move(movement);                             //11
    }
}