using DG.Tweening;

namespace Assets._Project.Develop.Runtime.UI.Core.Interfaces
{
    public interface IShowableView : IView
    {
        Tween Show();
        Tween Hide();
    }
}
