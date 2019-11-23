using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu
{
    public class MenuButton : Button
    {
        private Animator _animator;
        private static readonly int Selected = Animator.StringToHash("Selected");

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        public override void OnSelect(BaseEventData eventData)
        {
            base.OnSelect(eventData);
            _animator.SetBool(Selected, true);
        }

        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            _animator.SetBool(Selected, false);
        }
    }
}