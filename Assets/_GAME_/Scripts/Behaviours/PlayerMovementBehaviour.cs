﻿using Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        public bool IsPlayerClicking { get; set; }

        [SerializeField] Transform _leftLanePosition;
        [SerializeField] float _playerHorizontalMoveSpeed = 2f;
        [SerializeField] float _playerRunForwardSpeed = 10f; // after instantiating end chunk

        [SerializeField] Rigidbody _myRigidBody;
        [SerializeField] GameObject _myBones;

        private Vector3 _rightLanePosition;

        private PlayerController _playerController;
        private bool _isMouseButtonReleased = false;
        private bool _isInputActive = true;
        

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
            _rightLanePosition = transform.position;
            
        }


        private void Update()
        {
            if (_isInputActive)
            {
                if (_playerController.GameManager.ChunkManager.IsEndChunkSpawned)
                {
                    _myBones.SetActive(false);
                    _myRigidBody.useGravity = true;
                    _myRigidBody.GetComponent<CapsuleCollider>().enabled = true;
                    
                    transform.position += Vector3.forward * Time.deltaTime * _playerRunForwardSpeed;
                }

                if (Input.GetMouseButton(0))
                {
                    IsPlayerClicking = true;
                    _isMouseButtonReleased = false;
                    if (transform.position.x >= _leftLanePosition.position.x)
                    {
                        transform.position += Vector3.left * _playerHorizontalMoveSpeed * Time.deltaTime;

                    }
                }

                if (_isMouseButtonReleased)
                {
                    if (transform.position.x <= _rightLanePosition.x)
                    {
                        transform.position += Vector3.right * _playerHorizontalMoveSpeed * Time.deltaTime;
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {

                    _isMouseButtonReleased = true;
                    IsPlayerClicking = false;

                }
            }
        }

        public void DisableInput()
        {
            _isInputActive= false;
            IsPlayerClicking = false;
        }

    }
}
