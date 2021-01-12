using Microsoft.AspNetCore.Http;
using ModelLayer;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Mapper
    {

        public CustomerViewModel convertToCustomerViewModel(Customer customer)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                CustomerId = customer.CustomerId,
                Fname = customer.Fname,
                Lname = customer.Lname,
                Uname = customer.Uname,
                JpgString = ConvertByteArrayToString(customer.ByteArrayImage)
            };

            return customerViewModel;

        }

        public LocationViewModel convertToLocationViewModel(Location location, Guid customerGuid)
        {
            LocationViewModel locationViewModel = new LocationViewModel()
            {
                CustomerId = customerGuid,
                LocationId = location.LocationId,
                LocationName = location.LocationName
                
            };

            return locationViewModel;

        }

        public ProductModelView convertToProductModelView(Product product)
        {
            ProductModelView productModelView = new ProductModelView()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                JpgString = ConvertByteArrayToString(product.ByteArrayImage)
            };

            return productModelView;
        }

        public InventoryViewModel convertToInventoryModelView(Inventory inventory, Guid customerGuid)
        {
            InventoryViewModel inventoryViewModel = new InventoryViewModel()
            {
                LocationId = inventory.Location.LocationId,
                CustomerId = customerGuid,
                InventoryId = inventory.InventoryId,
                ProductName = inventory.Product.ProductName,
                Quantity = inventory.Quantity,
                ProductPicture = ConvertByteArrayToString(inventory.Product.ByteArrayImage),
                price = inventory.Product.Price
            };

            return inventoryViewModel;
        }



        public string ConvertByteArrayToString(byte[] byteArray)
        {
            if (byteArray != null)
			{
				string imageBase64Data = Convert.ToBase64String(byteArray, 0, byteArray.Length);
				string imageDataURL = string.Format($"data:image/jpg;base64,{imageBase64Data}");
				return imageDataURL;
			}
			else return null;
        }

        public byte[] ConvertIformFileToByteArray(IFormFile iformFile)
        {
            if (iformFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    iformFile.CopyTo(ms);

                    if (ms.Length > 2097152)
                    {
                        return null;
                    }
                    else
                    {
                        byte[] a = ms.ToArray();
                        return a;
                    }
                }
            }
            return null;
        }

    }
}
