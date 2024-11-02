namespace EnergyEndpointsConsoleApp.Views
{
    public class BaseView
    {
        public BaseView()
        {
            ConsoleView = true;
        }

        protected bool ConsoleView { get; set; }

        protected void InvalidInput()
        {
            throw new Exception("Invalid input");
        }

        protected void EmptyInput()
        {
            throw new Exception("Empty input passed when expecting a value");
        }

        protected virtual void Exit()
        {
            Console.WriteLine("Do you really want exit?");
            Console.Write("type 'y' to confirm: ");
            char confirmation = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Clear();
            if (confirmation == 'y' || confirmation == 'Y')
            {
                ConsoleView = false;
            }
            else
            {
                return;
            }
        }
    }
}
