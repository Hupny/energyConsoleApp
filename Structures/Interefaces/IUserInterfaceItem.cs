namespace Structures.Interefaces
{
    public interface IUserInterfaceItem<T>
    {
        void Start();
        void ShowOptions();
        void ListItems();
        void CreateItem();
        void UpdateItem();
        void DeleteItem(string id);
        void ShowItem(int index);
    }
}
