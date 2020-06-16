namespace MVC.Interfaces
{
    public interface IPorxy: INotifier
    {
        string ProxyName {get;}
        object Data{get; set;}
        void OnRegister();
        void OnRemove();
    }
}
