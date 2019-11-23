using System;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class PlayerStateUi : MonoBehaviour
    {
        [SerializeField] private Color activeColor;
        [SerializeField] private float activeScale = 1.5f;
        [SerializeField] private float transitionSpeed = 2f;
        private Color _disabledColor;

        private bool _active;

        private TextMeshProUGUI _text;

        private float _timer = 1f;

        private Vector3 _activeScale;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _disabledColor = _text.color;
            _activeScale = new Vector3(activeScale, activeScale, activeScale);
        }

        private void Update()
        {
            if (_timer >= 1) return;
            _timer = Mathf.Clamp01(_timer + Time.deltaTime * transitionSpeed);
            _text.color = Color.Lerp(_text.color, _active ? activeColor : _disabledColor, _timer);
            transform.localScale = Vector3.Lerp(_active ? Vector3.one : _activeScale,
                _active ? _activeScale : Vector3.one, _timer);
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