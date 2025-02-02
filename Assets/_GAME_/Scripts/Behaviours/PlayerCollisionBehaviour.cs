﻿using Game.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Behaviours
{
    public class PlayerCollisionBehaviour : MonoBehaviour
    {

        private PlayerController _playerController;


        public void Initialize(PlayerController playerController)
        {
            _playerController= playerController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                
                other.GetComponent<Collider>().enabled = false;
                _playerController.PlayerAnimationBehaviours.Animator.enabled = false;
                
                    _playerController.PlayerMovementBehaviour.OpenRagdollPhsyics();
                
                
                StartCoroutine(callLevelFailCO());
                _playerController.PlayerMovementBehaviour.DisableInput();
                
                

                //bir event oluşturalım lost diye 
                // bu event çağırılınca enemyler ve chunklar durucak 
                //kamera değişimi
            }
        }

        IEnumerator callLevelFailCO()
        {
            yield return new WaitForSeconds(1);
            _playerController.GameManager.EventManager.LevelFailed();

        }






    }
}