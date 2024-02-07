namespace HPlusSport.API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // so in the product.cs we access the cateogory and from the
        //category we get the list of products within the category

        //in our product each category will have atleast one product
        public virtual List<Product> Products { get; set; }
    }
}
