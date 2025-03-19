namespace Project1_APBD.Navigation;

public class CommandNavigation
{
    private ConsoleNavigation navigation = new ConsoleNavigation();
    public void StartNavigation()
    {
        
        Console.WriteLine("Starting navigation");
        Console.WriteLine($"1. Create a Ship");
    }
}