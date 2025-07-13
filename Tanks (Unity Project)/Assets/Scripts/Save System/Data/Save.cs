using System;
using System.Collections.Generic;
using UnityEngine;

namespace Save_System.Data
{
    [Serializable]
    public class Save
    {
        [SerializeField] private GameModeSaveData _gameModeSaveData;

        public GameModeSaveData GameModeSaveData => _gameModeSaveData;

        public Save(GameModeSaveData gameModeSaveData)
        {
            _gameModeSaveData = gameModeSaveData;
        }
    }
}