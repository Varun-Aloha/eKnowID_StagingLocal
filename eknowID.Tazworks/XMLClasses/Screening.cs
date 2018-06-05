//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace TazWorksCom
//{
//    [System.SerializableAttribute()]
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class Screening
//    {

//        private string permissiblePurposeField;

//        private string specimenIdField;

//        private string organizationNameField;

//        private string titleField;

//        private string startDateField;

//        private string endDateField;

//        private string compensationField;

//        private string regionField;

//        private string districtField;

//        private string countyField;

//        private BackgroundCheckBackgroundSearchPackageScreeningsScreeningLinkedApplicantsOrderId[][] linkedApplicantsField;

//        private BackgroundCheckBackgroundSearchPackageScreeningsScreeningContactInfo[] contactInfoField;

//        private BackgroundCheckBackgroundSearchPackageScreeningsScreeningContact[] contactField;

//        private BackgroundCheckBackgroundSearchPackageScreeningsScreeningEducationHistorySchoolOrInstitution[][] educationHistoryField;

//        private BackgroundCheckBackgroundSearchPackageScreeningsScreeningSearchLicenseLicense[][] searchLicenseField;

//        private Vendor[] vendorField;

//        private string typeField;

//        private string qualifierField;

//        private string numberField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string PermissiblePurpose
//        {
//            get
//            {
//                return this.permissiblePurposeField;
//            }
//            set
//            {
//                this.permissiblePurposeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string SpecimenId
//        {
//            get
//            {
//                return this.specimenIdField;
//            }
//            set
//            {
//                this.specimenIdField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string OrganizationName
//        {
//            get
//            {
//                return this.organizationNameField;
//            }
//            set
//            {
//                this.organizationNameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string StartDate
//        {
//            get
//            {
//                return this.startDateField;
//            }
//            set
//            {
//                this.startDateField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string EndDate
//        {
//            get
//            {
//                return this.endDateField;
//            }
//            set
//            {
//                this.endDateField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string Compensation
//        {
//            get
//            {
//                return this.compensationField;
//            }
//            set
//            {
//                this.compensationField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string Region
//        {
//            get
//            {
//                return this.regionField;
//            }
//            set
//            {
//                this.regionField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string District
//        {
//            get
//            {
//                return this.districtField;
//            }
//            set
//            {
//                this.districtField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public string County
//        {
//            get
//            {
//                return this.countyField;
//            }
//            set
//            {
//                this.countyField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [System.Xml.Serialization.XmlArrayItemAttribute("OrderId", typeof(BackgroundCheckBackgroundSearchPackageScreeningsScreeningLinkedApplicantsOrderId), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public BackgroundCheckBackgroundSearchPackageScreeningsScreeningLinkedApplicantsOrderId[][] LinkedApplicants
//        {
//            get
//            {
//                return this.linkedApplicantsField;
//            }
//            set
//            {
//                this.linkedApplicantsField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("ContactInfo", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public BackgroundCheckBackgroundSearchPackageScreeningsScreeningContactInfo[] ContactInfo
//        {
//            get
//            {
//                return this.contactInfoField;
//            }
//            set
//            {
//                this.contactInfoField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("Contact", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        public BackgroundCheckBackgroundSearchPackageScreeningsScreeningContact[] Contact
//        {
//            get
//            {
//                return this.contactField;
//            }
//            set
//            {
//                this.contactField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [System.Xml.Serialization.XmlArrayItemAttribute("SchoolOrInstitution", typeof(BackgroundCheckBackgroundSearchPackageScreeningsScreeningEducationHistorySchoolOrInstitution), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
//        public BackgroundCheckBackgroundSearchPackageScreeningsScreeningEducationHistorySchoolOrInstitution[][] EducationHistory
//        {
//            get
//            {
//                return this.educationHistoryField;
//            }
//            set
//            {
//                this.educationHistoryField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [System.Xml.Serialization.XmlArrayItemAttribute("License", typeof(BackgroundCheckBackgroundSearchPackageScreeningsScreeningSearchLicenseLicense), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
//        public BackgroundCheckBackgroundSearchPackageScreeningsScreeningSearchLicenseLicense[][] SearchLicense
//        {
//            get
//            {
//                return this.searchLicenseField;
//            }
//            set
//            {
//                this.searchLicenseField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("Vendor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
//        public Vendor[] Vendor
//        {
//            get
//            {
//                return this.vendorField;
//            }
//            set
//            {
//                this.vendorField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string type
//        {
//            get
//            {
//                return this.typeField;
//            }
//            set
//            {
//                this.typeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string qualifier
//        {
//            get
//            {
//                return this.qualifierField;
//            }
//            set
//            {
//                this.qualifierField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string number
//        {
//            get
//            {
//                return this.numberField;
//            }
//            set
//            {
//                this.numberField = value;
//            }
//        }
//    }
//}
