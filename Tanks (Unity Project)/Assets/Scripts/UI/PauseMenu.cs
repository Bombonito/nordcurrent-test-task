using System;
using Save_System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _actionAsset;
        [SerializeField] private string _actionMapPlayer;
        [SerializeField] private InputActionReference _hotkey;
        [SerializeField] private GameObject _view;
        
        [Inject] public SaveSystem SaveSystem { get; }

        private bool _isPaused;

        private void Start()
        {
            _hotkey.action.Enable();
            _hotkey.action.started += OnHotkeyClick;
        }

        private void OnHotkeyClick(InputAction.CallbackContext context)
        {
            _isPaused = !_isPaused;
            
            _view.SetActive(_isPaused);
            Time.timeScale = _isPaused ? 0 : 1;
            var combatInputMap = _actionAsset.FindActionMap(_actionMapPlayer);
            if (_isPaused)
            {
                combatInputMap.Disable();
            }
            else
            {
                combatInputMap.Enable();
            }
        }

        public void Save()
        {
            SaveSystem.Save();
        }

        public void Load()
        {
            SaveSystem.Load();
        }
    }
}