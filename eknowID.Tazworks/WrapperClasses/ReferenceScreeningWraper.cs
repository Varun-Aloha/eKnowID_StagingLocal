using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EknowIDModel;
using TazWorksCom.XMLClasses;

namespace TazWorksCom.WrapperClasses
{
    public class ReferenceScreeningWraper
    {
        private ReferenceInfo _referenceInfo;

        public ReferenceScreeningWraper(ReferenceInfo referenceInfo)
        {
            _referenceInfo = referenceInfo;            
        }

        public ReferenceScreening GetXMLNode()
        {
            ReferenceScreening referenceScreening = new ReferenceScreening();

            referenceScreening.Contact = new ReferenceContact();
            referenceScreening.Contact.PersonName = new ReferencePersonName();
            referenceScreening.Contact.PersonName.FormattedName = _referenceInfo.Name;
            referenceScreening.Contact.ContactMethod = new ContactMethod();
            referenceScreening.Contact.ContactMethod.Telephone = _referenceInfo.MobileNumber;
            referenceScreening.Contact.Relationship = _referenceInfo.Relationship;
            if (_referenceInfo.ReferenceTypeId == 1)
            {
                referenceScreening.qualifier = "professional";
            }
            else if (_referenceInfo.ReferenceTypeId == 2)
            {
                referenceScreening.qualifier = "personal";
            }
            
            return referenceScreening;
        }
    }
}
