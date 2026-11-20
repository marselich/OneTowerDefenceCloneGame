using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core.Interfaces;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextView ComputerCharsView { get; private set; }
        [field: SerializeField] public IconTextView PlayerCharsView { get; private set; }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
    }
}