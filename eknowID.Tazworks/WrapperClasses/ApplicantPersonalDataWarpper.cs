using eknowID.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom;

namespace eknowID.Tazworks.WrapperClasses
{
    public class ApplicantPersonalDataWarpper
    {
        private PersonalDataModal _personDataModal;

        public ApplicantPersonalDataWarpper(PersonalDataModal personDataModal)
        {
            _personDataModal = personDataModal;
        }

        public PersonalData CreatePersonalDataTag()
        {
            var personName = new PersonName
            {
                GivenName = _personDataModal.FirstName,
                MiddleName = _personDataModal.MiddleName,
                FamilyName = _personDataModal.LastName
            };

            var demographicDetail = new DemographicDetail
            {
                DateOfBirth = _personDataModal.DateOfBirth,
                GovernmentId = new GovernmentId
                {
                    Value = string.Empty
                }
            };

            var postalAddress = new PostalAddress
            {
                PostalCode = _personDataModal.ZipCode,
                Region = _personDataModal.State,
                Municipality = _personDataModal.State,
                DeliveryAddress = new DeliveryAddress
                {
                    AddressLine = _personDataModal.Address,
                    StreetName = string.Empty
                }
            };

            PersonalData personalData = new PersonalData
            {
                PersonName = personName,
                DemographicDetail = demographicDetail,
                PostalAddress = postalAddress,
                EmailAddress = _personDataModal.Email,
                Telephone = _personDataModal.Phone
            };

            return personalData;
        }
    }
}
