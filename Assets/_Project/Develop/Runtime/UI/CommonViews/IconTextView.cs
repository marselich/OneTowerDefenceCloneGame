using Assets._Project.Develop.Runtime.UI.Core.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.CommonViews
{
    public class IconTextView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _icon;

        public void SetText(string text, Color color)
        {
            SetText(text);
            _text.color = color;
        }

        public void SetText(string text)
        {
            _text.color = Color.white;
            _text.text = text;
        }

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
    }
}