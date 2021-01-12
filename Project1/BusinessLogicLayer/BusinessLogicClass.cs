using ModelLayer;
using ModelLayer.ViewModels;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{ 
    public class BusinessLogicClass
    {
        private readonly Repository _repository;
        private readonly Mapper _mapper;
        public BusinessLogicClass(Repository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Takes a Login playerViewModel instance and returns a playerViewModel instance
        /// </summary>
        /// <returns></returns>
        public CustomerViewModel LogInCustomer(CreateCustomerViewModel loginCustomerViewModel)
        {
            Customer customer = new Customer()
            {
                Fname = loginCustomerViewModel.Fname,
                Lname = loginCustomerViewModel.Lname,
                Uname = loginCustomerViewModel.Uname
            };

            Customer currentCustomer = _repository.LogInCustomer(customer);
            if(currentCustomer != null)
            {
                CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(currentCustomer);
                return customerViewModel;
            }
            return null;

            
        }

        public CustomerViewModel EditCustomer(Guid customerGuid)
        {
            Customer customer = _repository.GetCustomerById(customerGuid);
            CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(customer);
            return customerViewModel;

        }

        public CustomerViewModel EditedCustomer(CustomerViewModel customerViewModel)
        {
            Customer customer = _repository.GetCustomerById(customerViewModel.CustomerId);

            customer.Fname = customerViewModel.Fname;
            customer.Lname = customerViewModel.Lname;
            customer.Uname = customerViewModel.Uname;
            customer.ByteArrayImage = _mapper.ConvertIformFileToByteArray(customerViewModel.IformFileImage);

            Customer customer1 = _repository.EditCustomer(customer);

            CustomerViewModel customerViewModel1 = _mapper.convertToCustomerViewModel(customer1);

            return customerViewModel1;

        }

        public List<LocationViewModel> LocationList(Guid customerGuid)
        {

            List<Location> locationList = _repository.LocationList();

            List<LocationViewModel> locationViewModelList = new List<LocationViewModel>();
            foreach(Location L in locationList)
            {
                locationViewModelList.Add(_mapper.convertToLocationViewModel(L, customerGuid));
            }

            return locationViewModelList;

        }

        public List<InventoryViewModel> SearchInventoryList(int locationId, Guid customerGuid)
        {
            List<Inventory> inventoryList = _repository.SearchInventoryList(locationId);
            List<InventoryViewModel> inventoryViewModel = new List<InventoryViewModel>();

            foreach(Inventory I in inventoryList)
            {
               
                inventoryViewModel.Add(_mapper.convertToInventoryModelView(I, customerGuid));

            }
            return inventoryViewModel;
        }

        public CustomerViewModel LogInCustomerUsingUsername(LoginViewModel user)
        {
            string username = user.Uname;
            Customer currentCustomer = _repository.LogInCustomerWithUserName(username);
            if (currentCustomer != null)
            {
                CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(currentCustomer);
                return customerViewModel;
            }
            return null;

        }

        public AmountToAddViewModel AmountToAdd(int locationId, int inventoryId, string productName, Guid customerGuid)
        {
            // Cart currentCart = _repository.GetCart(customerGuid);
            Product product = new Product();
            product = _repository.GetProduct(productName);
            byte[] picture = product.ByteArrayImage;
            int amountTotal = _repository.GetInventoryStock(inventoryId);

            AmountToAddViewModel addToCartViewModel = new AmountToAddViewModel()
            {
                stock = amountTotal,
                location = locationId,
                CustomerId = customerGuid,
                inventory = inventoryId,
                Product = productName,
                discription = product.Description
                
            };
            if(picture != null)
            {
                addToCartViewModel.JpgString = _mapper.ConvertByteArrayToString(picture);
            }
            return addToCartViewModel;
        }
    }
}
