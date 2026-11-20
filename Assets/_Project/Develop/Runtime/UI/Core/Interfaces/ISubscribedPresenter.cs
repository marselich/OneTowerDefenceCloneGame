namespace Assets._Project.Develop.Runtime.UI.Core.Interfaces
{
    public interface ISubscribedPresenter : IPresenter
    {
        void Subscribe();
        void Unsubscribe();
    }
}
