namespace NorthWindEntityLocalData.Classes
{
    public class CategoryProduct
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public override string ToString() 
            => $"{CategoryName}, {ProductName}";

    }
}
