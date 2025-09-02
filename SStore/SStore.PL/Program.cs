using SStore.BLL;
using SStore.DAL.Models;

namespace SStore.PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===Main Menu Which Model Do You Need To Work With===");
                    Console.WriteLine("1- Products");
                    Console.WriteLine("2- Categorie");
                    Console.WriteLine("3- Customer");
                    Console.WriteLine("5- Exit");
                    Console.WriteLine("=======================");
                    Console.Write("Select an option: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            WorkWithProducts();
                            break;
                        case "2":
                           WorkWithCategories();
                            break;
                        case "3":
                            WorkWithCustomer();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        private static bool WorkWithProducts()
        {
            Console.WriteLine("=======================Product Manger===================================");
            Console.WriteLine("1- Get All Products");
            Console.WriteLine("2- Get Product By ID");
            Console.WriteLine("3- Add Product");
            Console.WriteLine("4- Update Product");
            Console.WriteLine("5- Delete Product");
            Console.WriteLine("6- Exit");

            Console.Write("Choose option: ");
            string options = Console.ReadLine();

            switch (options)
            {
                case "1": // Get All Products
                    List<Product> products = ProcductService.GettAllProducts();
                    foreach (var item in products)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("==================================");
                    break;

                case "2": // Get Product By ID
                    Console.Write("Enter Product ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Product product = ProcductService.GetProductByID(id);
                    Console.WriteLine(product);
                    Console.WriteLine("-----------------------------------");
                    break;

                case "3": // Add Product
                    Product newProduct = new Product();
                    Console.Write("Enter Product Name: ");
                    newProduct.Name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    newProduct.price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Category ID: ");
                    newProduct.IdCategory = int.Parse(Console.ReadLine());
                    Console.Write("Enter Stock: ");
                    newProduct.stock = int.Parse(Console.ReadLine());
                    newProduct.CreatedAt = DateTime.Now;

                    bool isAdded = ProcductService.AddProduct(newProduct);
                    Console.WriteLine(isAdded ? "Done Added" : "Error 404");
                    break;

                case "4": // Update Product
                    Product updateProduct = new Product();
                    Console.Write("Enter Product ID to Update: ");
                    updateProduct.Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Product Name: ");
                    updateProduct.Name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    updateProduct.price = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Category ID: ");
                    updateProduct.IdCategory = int.Parse(Console.ReadLine());
                    Console.Write("Enter Stock: ");
                    updateProduct.stock = int.Parse(Console.ReadLine());
                    updateProduct.CreatedAt = DateTime.Now;

                    bool isUpdated = ProcductService.UpdateProduct(updateProduct);
                    Console.WriteLine(isUpdated ? "Done Updated" : "Error 404");
                    break;

                case "5": // Delete Product
                    Console.Write("Enter Product ID to Delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    bool isDeleted = ProcductService.DeleteProduct(deleteId);
                    Console.WriteLine(isDeleted ? "Done Deleted" : "Error 404");
                    break;

                case "6": // Exit
                    return false;

                default:
                    Console.WriteLine("Invalid Option! Try again.");
                    break;
            }

            return true;
        }
        private static bool WorkWithCategories()
        {
            Console.WriteLine("=======================Category Manager===================================");
            Console.WriteLine("1- Get All Categories");
            Console.WriteLine("2- Get Category By ID");
            Console.WriteLine("3- Add Category");
            Console.WriteLine("4- Update Category");
            Console.WriteLine("5- Delete Category");
            Console.WriteLine("6- Exit");

            Console.Write("Choose option: ");
            string options = Console.ReadLine();

            switch (options)
            {
                case "1": // Get All Categories
                    List<Categorie> categories = CategorieService.GetAllCategories();
                    foreach (var item in categories)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("==================================");
                    break;

                case "2": // Get Category By ID
                    Console.Write("Enter Category ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Categorie category = CategorieService.GetCategoryByID(id);
                    Console.WriteLine(category != null ? category.ToString() : "Not Found!");
                    Console.WriteLine("-----------------------------------");
                    break;

                case "3": // Add Category
                    Categorie newCategory = new Categorie();
                    Console.Write("Enter Category Name: ");
                    newCategory.Name = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    newCategory.Description = Console.ReadLine();

                    bool isAdded = CategorieService.AddCategory(newCategory);
                    Console.WriteLine(isAdded ? "Done Added" : "Error 404");
                    break;

                case "4": // Update Category
                    Categorie updateCategory = new Categorie();
                    Console.Write("Enter Category ID to Update: ");
                    updateCategory.Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Category Name: ");
                    updateCategory.Name = Console.ReadLine();
                    Console.Write("Enter Description: ");
                    updateCategory.Description = Console.ReadLine();

                    bool isUpdated = CategorieService.UpdateCategory(updateCategory);
                    Console.WriteLine(isUpdated ? "Done Updated" : "Error 404");
                    break;

                case "5": // Delete Category
                    Console.Write("Enter Category ID to Delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    bool isDeleted = CategorieService.DeleteCategory(deleteId);
                    Console.WriteLine(isDeleted ? "Done Deleted" : "Error 404");
                    break;

                case "6": // Exit
                    return false;

                default:
                    Console.WriteLine("Invalid Option! Try again.");
                    break;
            }

            return true;
        }

        private static bool WorkWithCustomer()
        {
            Console.WriteLine("=======================Customer Manager===================================");
            Console.WriteLine("1- Get All Customers");
            Console.WriteLine("2- Get Customer By ID");
            Console.WriteLine("3- Add Customer");
            Console.WriteLine("4- Update Customer");
            Console.WriteLine("5- Delete Customer");
            Console.WriteLine("6- Exit");

            Console.Write("Choose option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1": // Get All Customers
                    List<Customer> customers = CustomerService.GetAllCustomers();
                    foreach (var item in customers)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("==================================");
                    break;

                case "2": // Get Customer By ID
                    Console.Write("Enter Customer ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Customer customer = CustomerService.GetCustomerByID(id);
                    Console.WriteLine(customer != null ? customer.ToString() : "Not Found!");
                    Console.WriteLine("-----------------------------------");
                    break;

                case "3": // Add Customer
                    Customer newCustomer = new Customer();
                    Console.Write("Enter First Name: ");
                    newCustomer.FirstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    newCustomer.LastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    newCustomer.Email = Console.ReadLine();
                    Console.Write("Enter Phone: ");
                    newCustomer.Phone = Console.ReadLine();
                    Console.Write("Enter City (optional): ");
                    newCustomer.City = Console.ReadLine();
                    Console.Write("Enter State (optional): ");
                    newCustomer.StateName = Console.ReadLine();
                    Console.Write("Enter ZipCode (optional): ");
                    newCustomer.ZipCode = Console.ReadLine();
                    Console.Write("Enter Country (optional): ");
                    newCustomer.Country = Console.ReadLine();
                    newCustomer.CreatedAt = DateTime.Now;

                    bool isAdded = CustomerService.AddCustomer(newCustomer);
                    Console.WriteLine(isAdded ? "Done Added" : "Error 404");
                    break;

                case "4": // Update Customer
                    Customer updateCustomer = new Customer();
                    Console.Write("Enter Customer ID to Update: ");
                    updateCustomer.CustomerID = int.Parse(Console.ReadLine());
                    Console.Write("Enter First Name: ");
                    updateCustomer.FirstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    updateCustomer.LastName = Console.ReadLine();
                    Console.Write("Enter Email: ");
                    updateCustomer.Email = Console.ReadLine();
                    Console.Write("Enter Phone: ");
                    updateCustomer.Phone = Console.ReadLine();
                    Console.Write("Enter City (optional): ");
                    updateCustomer.City = Console.ReadLine();
                    Console.Write("Enter State (optional): ");
                    updateCustomer.StateName = Console.ReadLine();
                    Console.Write("Enter ZipCode (optional): ");
                    updateCustomer.ZipCode = Console.ReadLine();
                    Console.Write("Enter Country (optional): ");
                    updateCustomer.Country = Console.ReadLine();
                    updateCustomer.CreatedAt = DateTime.Now;

                    bool isUpdated = CustomerService.UpdateCustomer(updateCustomer);
                    Console.WriteLine(isUpdated ? "Done Updated" : "Error 404");
                    break;

                case "5": // Delete Customer
                    Console.Write("Enter Customer ID to Delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    bool isDeleted = CustomerService.DeleteCustomer(deleteId);
                    Console.WriteLine(isDeleted ? "Done Deleted" : "Error 404");
                    break;

                case "6": // Exit
                    return false;

                default:
                    Console.WriteLine("Invalid Option! Try again.");
                    break;
            }

            return true;
        }


    }
}
