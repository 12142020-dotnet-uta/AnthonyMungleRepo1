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
        public CustomerViewModel LogInCustomer(LoginCustomerViewModel loginCustomerViewModel)
        {
            Customer customer = new Customer()
            {
                Fname = loginCustomerViewModel.Fname,
                Lname = loginCustomerViewModel.Lname,
                Uname = loginCustomerViewModel.Uname
            };

            Customer currentCustomer = _repository.LogInCustomer(customer);

            CustomerViewModel customerViewModel = _mapper.convertToCustomerViewModel(currentCustomer);
            return customerViewModel;
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

        public List<LocationViewModel> LocationList()
        {

            List<Location> locationList = _repository.LocationList();

            List<LocationViewModel> locationViewModelList = new List<LocationViewModel>();
            foreach(Location L in locationList)
            {
                locationViewModelList.Add(_mapper.convertToLocationViewModel(L));
            }

            return locationViewModelList;

        }

        public List<InventoryViewModel> SearchInventoryList(int locationId)
        {
            List<Inventory> inventoryList = _repository.SearchInventoryList(locationId);
            List<InventoryViewModel> inventoryViewModel = new List<InventoryViewModel>();

            foreach(Inventory I in inventoryList)
            {

                inventoryViewModel.Add(_mapper.convertToInventoryModelView(I));

            }
            return inventoryViewModel;
        }
    }
}
