using BusinessLayer.Interface;
using DatabaseLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class AddressBL:IAddressBL
    {
        IAddressRL addressRL;

        public AddressBL(IAddressRL addressRL)
        {
            this.addressRL = addressRL;
        }

        public string AddAddress(AddressModel addressModel, int id)
        {
            try
            {
                return this.addressRL.AddAddress(addressModel,id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteAddress(int AddressId)
        {
            try
            {
                return this.addressRL.DeleteAddress(AddressId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressModel> GetAddressById(int id)
        {
            try
            {
                return this.addressRL.GetAddressById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<AddressModel> GetAllAddress()
        {
            try
            {
                return this.addressRL.GetAllAddress();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateAddress(AddressModel addressModel)
        {
            try
            {
                return this.addressRL.UpdateAddress(addressModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
