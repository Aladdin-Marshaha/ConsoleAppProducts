using ConsoleAppProducts.Entities;
using ConsoleAppProducts.Services;
using System.Runtime.CompilerServices;

namespace ConsoleAppProducts;

internal class ConsoleUI
{
    private readonly ProductService _productService;

    public ConsoleUI(ProductService productService)
    {
        _productService = productService;
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMenuTitle("MENU OPTIONS");
            Console.WriteLine($"{"1.",-4} Add New Product.");
            Console.WriteLine($"{"2.",-4} Show All Products.");
            Console.WriteLine($"{"3.",-4} Show a specific Product.");
            Console.WriteLine($"{"4.",-4} Update Product.");
            Console.WriteLine($"{"5.",-4} Delete Product.");
            Console.WriteLine($"{"0.",-4} Exit Application.");
            Console.WriteLine();
            Console.Write("Enter Menu Option: ");

            var option = Console.ReadLine();

            switch ( option )
            {
                case "1":
                    CreateProduct_UI(); break;
                case "2":
                    GetAllProducts_UI(); break;
                case "3":
                    GetOneProduct_UI(); break;
                case "4":
                    UpdateProduct_UI(); break;
                case "5":
                    DeleteProduct_UI(); break;
                case "0":
                    ShowExitApplicationOption(); break;
                default:
                    Console.WriteLine("\nInvalid option selected. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void CreateProduct_UI()
    {
        DisplayMenuTitle("Create Prodcut");

        Console.Write("Product ArticleNumber: ");
        var articleNumber = Console.ReadLine()!;

        Console.Write("Manufacturer Name: ");
        var title = Console.ReadLine()!;
        Console.Write("Product Title: ");
        var manufacturerName = Console.ReadLine()!;

        Console.Write("Ingress: ");
        var ingress = Console.ReadLine()!;

        Console.Write("Description: ");
        var description = Console.ReadLine()!;

        Console.Write("Specifications: ");
        var specifications = Console.ReadLine()!;

        Console.Write("Product Price: ");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Discount Price: ");
        var discountPrice = decimal.Parse(Console.ReadLine()!);

        Console.Write("Category Name: ");
        var categoryName = Console.ReadLine()!;

        var result = _productService.CreateProduct(articleNumber, title, manufacturerName, ingress, description, specifications, price, discountPrice, categoryName);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created. ");
            Console.ReadKey();
        }
        else 
        { 
            Console.Clear();
            Console.WriteLine("Product already exist");
        }
    }

    private void GetAllProducts_UI()
    {
        var allProducts = _productService.GetProducts();
        Console.Clear();
        DisplayMenuTitle("All Products");
        if (allProducts.Any())
        {
            foreach (var product in allProducts)
            {
                Console.WriteLine($"Article Number: {product.ArticleNumber}, Title: {product.Title}, Manufacturer: {product.Manufacturer.ManufacturerName}, Price: {product.PriceList.Price}");
            }
        }
        else
        {
            Console.WriteLine("No products found.");
        }
        DisplayPressAnyKey();
    }


    private void GetOneProduct_UI()
    {
        DisplayMenuTitle("Show Specific Product");

        Console.Write("Enter the article number of the product: ");
        var articleNumber = Console.ReadLine();

        var productToView = _productService.GetProductByArticleNumber(articleNumber!);
        Console.Clear();

        DisplayMenuTitle("Show Specific Product");
        if (productToView != null)
        {
            Console.WriteLine($"Article Number: {productToView.ArticleNumber}");
            Console.WriteLine($"Title: {productToView.Title}");
            Console.WriteLine($"Manufacturer: {productToView.Manufacturer.ManufacturerName}");
            Console.WriteLine($"Price: {productToView.PriceList.Price}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

        DisplayPressAnyKey();
    }


    private void UpdateProduct_UI()
    {
        DisplayMenuTitle("Update Product");
        Console.Clear();
        Console.Write("Enter the article number of the product to update: ");
        var articleNumber = Console.ReadLine();

        var productToUpdate = _productService.GetProductByArticleNumber(articleNumber!);
        Console.Clear();
        DisplayMenuTitle("Update Product");
        if (productToUpdate != null)
        {

            Console.Write("Enter the new title for the product: ");
            var newTitle = Console.ReadLine();

            Console.Write("Enter the new ingress for the product: ");
            var newIngress = Console.ReadLine();

            Console.Write("Enter the new description for the product: ");
            var newDescription = Console.ReadLine();

            Console.Write("Enter the new specifications for the product: ");
            var newSpecifications = Console.ReadLine();

            Console.Write("Enter the new price for the product: ");
            var newPrice = Decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter the new discount price for the product: ");
            var newDiscountPrice = Decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter the new manufacturer name for the product: ");
            var newManufacturerName = Console.ReadLine();

            Console.Write("Enter the new category name name for the product: ");
            var newCategoryName = Console.ReadLine();

            productToUpdate.Title = newTitle!;
            productToUpdate.Description.Ingress = newIngress!;
            productToUpdate.Description.Description = newDescription!;
            productToUpdate.Description.Specifications = newSpecifications!;
            productToUpdate.PriceList.Price = newPrice!;
            productToUpdate.PriceList.DiscountPrice = newDiscountPrice!;
            productToUpdate.Manufacturer.ManufacturerName = newManufacturerName!;
            productToUpdate.Category.CategoryName = newCategoryName!;

            _productService.UpdateProduct(productToUpdate);

            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Product not found.");
        }

        DisplayPressAnyKey();
    }


    private void DeleteProduct_UI()
    {
        Console.Clear();

        DisplayMenuTitle("Delete Product");
        Console.Write("Enter the article number of the product to delete: ");

        var articleNumber = Console.ReadLine();

        var wasdeleted = _productService.DeleteProduct(articleNumber!);
        Console.Clear();
        if (wasdeleted)
        {
            Console.WriteLine($"Product with article number '{articleNumber}' has been deleted.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

        Console.ReadKey();
        Console.Clear();
    }



    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to close this application? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            Environment.Exit(0);
    }

    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"*¤*¤ {title} ¤*¤*");
        Console.WriteLine();
    }

    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}