namespace Project1_APBD.Containers;

public class FridgeContainer : Container
{
    public String TypeOfProduct { get; set; }
    public double Temperature { get; set; }
    private Dictionary<string, double> _Fridge { get; set; } = new Dictionary<string, double>();

    public FridgeContainer(double height, double ownMass, double depth, double maxLoad, string typeOfProduct, double temperature) : base("C", height, ownMass, depth, maxLoad)
    {
        
        
        FillDictionary();
        if (!_Fridge.ContainsKey(typeOfProduct))
        {
            throw new Exception($"Fridge type {typeOfProduct} does not exist.");
        }
        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
        
    }

    private void FillDictionary()
    {
        _Fridge.Add("Bananas", 13.3);
        _Fridge.Add("Chocolate", 18);
        _Fridge.Add("Fish", 2);
        _Fridge.Add("Meat", -15);
        _Fridge.Add("Ice cream", -18);
        _Fridge.Add("Frozen pizza", -30);
        _Fridge.Add("Cheese", 7.2);
        _Fridge.Add("Sausages", 5);
        _Fridge.Add("Butter", 20.5);
        _Fridge.Add("Eggs", 19);
    }

    public Dictionary<string, double> GetFridge()
    {
        return _Fridge;
    }
    
    
    
    
    
    
}