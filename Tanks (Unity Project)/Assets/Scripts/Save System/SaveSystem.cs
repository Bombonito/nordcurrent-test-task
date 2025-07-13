using System.Collections.Generic;
using Save_System.Adapters;
using Save_System.Data;
using Utilities;
using Zenject;

namespace Save_System
{
    public class SaveSystem : IInitializable, ISaveObserver<GameModeSaveAdapter>
    {
        private GameModeSaveAdapter _gameModeSaveAdapter;
        public GameModeSaveAdapter GameModeSaveAdapter => _gameModeSaveAdapter;
        
        [Inject] public CoroutineRunner CoroutineRunner { get; }
        
        public void Initialize()
        { }

        public void Save()
        {
            SaveIO.Write(new Save(GameModeSaveAdapter.Extract()));
        }

        public void Load()
        { 
            CoroutineRunner.StartCoroutine(GameModeSaveAdapter.ApplyCoroutine(SaveIO.Read().GameModeSaveData));
        }

        public void Add(GameModeSaveAdapter saveWriter) => _gameModeSaveAdapter = saveWriter;
        public void Remove(GameModeSaveAdapter saveWriter) => _gameModeSaveAdapter = null;
    }
}