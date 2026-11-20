using Assets._Project.Develop.Runtime.UI.Core.Popup;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.CommonViews
{
    public class ConfirmationPopupView : PopupViewBase
    {
        public event Action ConfirmButtonClicked;
        public event Action CancelButtonClicked;

        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _message;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        public void SetTitle(string text) => _title.text = text;
        public void SetMessage(string text)
        {
            _message.color = Color.white;
            _message.text = text;
        }
        public void SetMessage(string text, Color color)
        {
            SetMessage(text);
            _message.color = color;
        }

        private void OnEnable()
        {
            _confirmButton.onClick.AddListener(OnConfirmButtonClicked);
            _cancelButton.onClick.AddListener(OnCancelButtonClicked);
        }

        private void OnDisable()
        {
            _confirmButton.onClick.RemoveListener(OnConfirmButtonClicked);
            _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
        }

        private void OnCancelButtonClicked() => CancelButtonClicked?.Invoke();

        private void OnConfirmButtonClicked() => ConfirmButtonClicked?.Invoke();
    }
}