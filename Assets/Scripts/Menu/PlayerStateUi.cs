using System;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class PlayerStateUi : MonoBehaviour
    {
        [SerializeField] private Color activeColor;
        [SerializeField] private float activeScale = 0.25f;
        [SerializeField] private float inactiveScale = 0.2f;
        [SerializeField] private float transitionSpeed = 2f;
        [SerializeField] private Transform containerToScale;
        
        private Color _disabledColor;

        private bool _active;
        
        private Image _image;

        private float _timer = 1f;

        private Vector3 _activeScale;
        private Vector3 _inactiveScale;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _disabledColor = _image.color;
            _activeScale = new Vector3(activeScale, activeScale, activeScale);
            _inactiveScale = new Vector3(inactiveScale, inactiveScale, inactiveScale);
        }

        private void Update()
        {
            if (_timer >= 1) return;
            _timer = Mathf.Clamp01(_timer + Time.deltaTime * transitionSpeed);
            _image.color = Color.Lerp(_image.color, _active ? activeColor : _disabledColor, _timer);
            containerToScale.localScale = Vector3.Lerp(_active ? _inactiveScale : _activeScale,
                _active ? _activeScale : _inactiveScale , _timer);
        }

        public void OnPlayerJoined()
        {
            if (_active) return;

            _timer = 1f - _timer;
            _active = true;
        }

        public void OnPlayerLeft()
        {
            if (!_active) return;

            _timer = 1f - _timer;
            _active = false;
        }
    }
}