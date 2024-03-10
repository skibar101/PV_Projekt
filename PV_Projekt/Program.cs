namespace PV_Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            ///Zde spouštím třídu CommandInterface a následně sem přidávám položky, které tam chci mít.
            /// </summary>

            ICommand listUsersCommand = new ListUsers(); // Vytvoření seznamu příkazů pro získáni všech uživatelů
            ICommand addCustomerCommand = new AddCustomer();// Vytvoření seznamu příkazů pro přidaní zákazníka
            ICommand deleteCustomerCommand = new DeleteCustomer ();// Vytvoření seznamu příkazů pro smazání zákazníka
            ICommand updateCustomerCommand = new UpdateCustomer();// Vytvoření seznamu příkazů pro aktualizaci údajů zákazníka
            List<ICommand> commands = new List<ICommand> { listUsersCommand, addCustomerCommand, deleteCustomerCommand, updateCustomerCommand };//přidaní do rozhraní

            CommandInterface commandInterface = new CommandInterface(commands); // Vytvoření instance CommandInterface tady v mainu

            commandInterface.RunCommand(); // Spuštění rozhraní 
        }
    }
}