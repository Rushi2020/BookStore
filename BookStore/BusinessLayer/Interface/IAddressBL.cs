using DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IAddressBL
    {
        string AddAddress(AddressModel addressModel);
        string UpdateAddress(AddressModel addressModel);
        string DeleteAddress(int AddressId);
        List<AddressModel> GetAllAddress();
        List<AddressModel> GetAddressById(int id);
    }
}
