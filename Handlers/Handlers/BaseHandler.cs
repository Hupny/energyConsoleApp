namespace Handlers.Handlers
{
    public class BaseHandler<T>
    {
        public BaseHandler(List<T>? itemsList = null)
        {
            if (itemsList != null)
                ItemList = itemsList;
            else
            {
                ItemList = new List<T>();
            }

            Success = () =>
            {
                return "Success";
            };

            Fail = (string message) =>
            {
                return "Fail - " + message;
            };
        }

        protected List<T> ItemList { get; set; }
        protected Func<string> Success {  get; private set; }
        protected Func<string, string> Fail { get; private set; }

        public List<T> GetItemList()
        {
            return ItemList;
        }

        public bool ListEmpty()
        {
            return ItemList.Count == 0;
        }
    }
}
