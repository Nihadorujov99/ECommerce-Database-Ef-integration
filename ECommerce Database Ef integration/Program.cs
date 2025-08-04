using System;
using System.Collections.Generic;
using System.Linq;
using EFintegration.DataContext.Models;
using EFintegration.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EFintegration
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Action> commands = new Dictionary<string, Action>
            {
                { "addcustomer", AddCustomer },
                { "addorder", AddOrder },
                { "addorderdetail", AddOrderDetail },
                { "addproduct", AddProduct },
                { "addcategory", AddCategory },
                { "addemployee", AddEmployee },
                { "addsupplier", AddSupplier },
                { "exit", () => Environment.Exit(0) }
            };

            do
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("Command cannot be empty.");
                    continue;
                }

                if (commands.TryGetValue(command.ToLower(), out Action action))
                {
                    action.Invoke();
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                }

            } while (true);
        }

        static void AddCustomer()
        {
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter contact name: ");
            string contactName = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter postal code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter country: ");
            string country = Console.ReadLine();

            var customer = new Customer
            {
                CustomerName = customerName,
                ContactName = contactName,
                Address = address,
                City = city,
                PostalCode = postalCode,
                Country = country
            };

            using (var context = new AppDbContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                Console.WriteLine("Customer added successfully.");
            }
        }

        static void AddOrder()
        {
            Console.Write("Enter customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid customer ID.");
                return;
            }

            Console.Write("Enter employee ID: ");
            if (!int.TryParse(Console.ReadLine(), out int employeeId))
            {
                Console.WriteLine("Invalid employee ID.");
                return;
            }

            var order = new Order
            {
                CustomerID = customerId,
                EmployeeID = employeeId,
                OrderDate = DateTime.Now
            };

            using (var context = new AppDbContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
                Console.WriteLine("Order added successfully.");
            }
        }

        static void AddOrderDetail()
        {
            Console.Write("Enter order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.WriteLine("Invalid order ID.");
                return;
            }

            Console.Write("Enter product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            var orderDetail = new OrderDetail
            {
                OrderID = orderId,
                ProductID = productId,
                Quantity = quantity
            };

            using (var context = new AppDbContext())
            {
                context.OrderDetails.Add(orderDetail);
                context.SaveChanges();
                Console.WriteLine("Order detail added successfully.");
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter supplier ID: ");
            if (!int.TryParse(Console.ReadLine(), out int supplierId))
            {
                Console.WriteLine("Invalid supplier ID.");
                return;
            }

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.WriteLine("Invalid category ID.");
                return;
            }

            Console.Write("Enter unit: ");
            string unit = Console.ReadLine();
            Console.Write("Enter price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            var product = new Product
            {
                ProductName = productName,
                SupplierID = supplierId,
                CategoryID = categoryId,
                Unit = unit,
                Price = price
            };

            using (var context = new AppDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
                Console.WriteLine("Product added successfully.");
            }
        }

        static void AddCategory()
        {
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            var category = new Category
            {
                CategoryName = categoryName,
                Description = description
            };

            using (var context = new AppDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
                Console.WriteLine("Category added successfully.");
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter birth date (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime birthDate))
            {
                Console.WriteLine("Invalid birth date.");
                return;
            }

            Console.Write("Enter notes: ");
            string notes = Console.ReadLine();

            var employee = new Employee
            {
                LastName = lastName,
                FirstName = firstName,
                BirthDate = birthDate,
                Photo = null,
                Notes = notes
            };

            using (var context = new AppDbContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Employee added successfully.");
            }
        }

        static void AddSupplier()
        {
            Console.Write("Enter supplier name: ");
            string supplierName = Console.ReadLine();
            Console.Write("Enter contact name: ");
            string contactName = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter postal code: ");
            string postalCode = Console.ReadLine();
            Console.Write("Enter country: ");
            string country = Console.ReadLine();
            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            var supplier = new Supplier
            {
                SupplierName = supplierName,
                ContactName = contactName,
                Address = address,
                City = city,
                PostalCode = postalCode,
                Country = country,
                Phone = phone
            };

            using (var context = new AppDbContext())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
                Console.WriteLine("Supplier added successfully.");
            }
        }
    }
}
