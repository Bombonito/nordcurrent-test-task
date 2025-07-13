using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Save_System.Data
{
    [Serializable]
    public class GameModeSaveData
    {
        [SerializeField] private int _maxBotCount;
        [SerializeField] private List<TankSaveData> _tanks;

        public int MaxBotCount => _maxBotCount;
        public List<TankSaveData> Tanks => _tanks;

        public GameModeSaveData(int maxBotCount, List<TankSaveData> tanks)
        {
            _maxBotCount = maxBotCount;
            _tanks = tanks;
        }
    }
}