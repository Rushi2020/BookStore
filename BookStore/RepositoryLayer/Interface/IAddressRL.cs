using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAddressRL
    {
        string AddAddress(AddressModel addressModel, int id);
        string UpdateAddress(AddressModel addressModel);
        string DeleteAddress(int AddressId);
        List<AddressModel> GetAllAddress();
        List<AddressModel> GetAddressById(int id);
    }
}
