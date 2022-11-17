﻿using Game.Scripts.Behaviours;
using Game.Scripts.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Managers
{
    public class ChunkManager : CustomBehaviour
    {
        [SerializeField] GameObject ChunkPrefab;
        [SerializeField] Transform chunksParent;
        [SerializeField] Transform chunksSpawnPoint;

        

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            LocalStart();
        }


        private void LocalStart()
        {
            InstantiateStartingChunks();                                                                                                        
            var firstChunk =Instantiate(ChunkPrefab, chunksSpawnPoint.position, Quaternion.identity, chunksParent);
            firstChunk.GetComponent<ChunkRotatingBehaviour>().Initialize(this);
        }

  
        private void InstantiateStartingChunks()
        {
            for (int i = 10; i < 71; i+=10)
            {

            var currentChunk1 = Instantiate(ChunkPrefab, chunksSpawnPoint.position, Quaternion.identity, chunksParent);
            var currentChunkRotationBehaviour = currentChunk1.GetComponent<ChunkRotatingBehaviour>();
                currentChunkRotationBehaviour.Initialize(this);
                currentChunkRotationBehaviour.GetThePosition(i);
                currentChunkRotationBehaviour.IsChunkInitial = true;
            }   
        }


        public void SpawnChunk()
        {
            var currentChunk = Instantiate(ChunkPrefab, chunksSpawnPoint.position, Quaternion.identity, chunksParent);
            var currentChunkRotatingBehaviour = currentChunk.GetComponent<ChunkRotatingBehaviour>();
            currentChunkRotatingBehaviour.Initialize(this);
            currentChunkRotatingBehaviour.MakeChunkAbleToMove();
        }

        
    }
}