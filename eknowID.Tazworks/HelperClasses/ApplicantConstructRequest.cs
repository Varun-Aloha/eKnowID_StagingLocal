using eknowID.Model;
using eknowID.Tazworks.WrapperClasses;
using eknowID.Tazworks.XMLClasses;
using EknowIDData.Helper;
using EknowIDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TazWorksCom;
using TazWorksCom.WrapperClasses;
using TazWorksCom.XMLClasses;

namespace TazWorksCom
{
    public class ApplicantConstructRequest
    {
        #region Data Member
        BackgroundCheck _backgroundCheck;
        BackgroundSearchPackage _backgroundSearchPackage;
        Screenings _screenings;
        List<ScreeningType> _screeningTypes;
        #endregion
        
        #region Constructor
        public ApplicantConstructRequest()
        {
            _backgroundCheck = new BackgroundCheck();
            _backgroundSearchPackage = new BackgroundSearchPackage();
            _screenings = new Screenings();
            _screenings.AdditionalItems = new List<AdditionalItems>();
            _screeningTypes = new List<ScreeningType>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// This methods is used for fill manullay
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public string GetBackgroundCheckXmlString(Candidate candidate)
        {
            // Get personal information and create xml element
            var personDataModal = new PersonalDataModal
            {
                //FirstName = candidate.FirstName,
                //LastName = candidate.LastName,
                //Email = candidate.EmailId,
                //Address = string.Empty,
                //AssessmentId = candidate.AssessmentId

                FirstName = "Mayur",
                LastName = "Savaliya",
                Email = "savaliya.mayur101@gmail.com",
                Address = string.Empty,
                AssessmentId = Guid.Empty
                
            };

            //create commonSearch xml for all offers
            CreateCommonSearchTag(personDataModal);

            _backgroundCheck.BackgroundSearchPackage = _backgroundSearchPackage;
            _screenings.Screening = _screeningTypes;
            _backgroundCheck.BackgroundSearchPackage.Screenings = _screenings;

            return SerializationHelper.XmlSerializeToString(_backgroundCheck);            
        }

        public string SendXmlRequestToTazwork(string xmlRequest)
        {
            ProcessRequest request = new ProcessRequest();
            return request.HttpPost(xmlRequest);            
        }
        #endregion

        #region Private Methods
        private void CreateCommonSearchTag(PersonalDataModal personDataModal)
        {
            // Create xml tag for persoanl information 
            CreatePersonalDataTag(personDataModal);

            // Create xml tag for Additional Items
            CreateAdditionalItemsTag();

            CreateSSNSearchTag();
            CreatePersonSearchTag();
            CreateSexOfferSearchTag(string.Empty);
            CreateInstaCriminalSearchTag();
        }

        /// <summary>
        /// CreatePErsonalDataTag
        /// </summary>
        /// <param name="personDataModal"></param>
        private void CreatePersonalDataTag(PersonalDataModal personDataModal)
        {
            ApplicantPersonalDataWarpper personalDataWrapper = new ApplicantPersonalDataWarpper(personDataModal);
            PersonalData personalData = personalDataWrapper.CreatePersonalDataTag();
            _backgroundSearchPackage.PersonalData = personalData;
            _backgroundSearchPackage.ReferenceId = personDataModal.AssessmentId.ToString();
        }

        /// <summary>
        /// This methods is used to create additional items
        /// </summary>
        private void CreateAdditionalItemsTag()
        {
            //not send email to applicant            
            //_screenings.AdditionalItems.Add(AdditionalItemsWrapper.CreateAdditionalItemsTag("x:interface", "APPLICANT_NO_EMAIL"));

            ////credentials is added to the reportUrl
            //_screenings.AdditionalItems.Add(AdditionalItemsWrapper.CreateAdditionalItemsTag("x:embed_credentials", "YES"));

        }

        private void CreateSSNSearchTag()
        {
            SSNScreening SSNScreening = new SSNScreening();
            SSNScreening.Vendor = new SSNVendor();
            _screeningTypes.Add(SSNScreening);
        }

        private void CreatePersonSearchTag()
        {            
            PersonSearchScreening PersonsearchScreening = new PersonSearchScreening();
            PersonsearchScreening.Vendor = new PersonSearchVendor();

            _screeningTypes.Add(PersonsearchScreening);
        }

        private void CreateSexOfferSearchTag(string region)
        {
            SexOfferScreening SexOfferScreening = new SexOfferScreening();
            SexOfferScreening.Region = region ?? string.Empty;

            _screeningTypes.Add(SexOfferScreening);
        }

        private void CreateInstaCriminalSearchTag()
        {
            //StateCriminalScreening StateCriminalScreening = new StateCriminalScreening();
            //StateCriminalScreening.Region = region ?? string.Empty;

            //InstaCriminalSingleStateScreening InstaCriminalSingleStateScreening = new InstaCriminalSingleStateScreening();
            //InstaCriminalSingleStateScreening.Region = region ?? string.Empty;

            InstaCriminalMultiStateScreening InstaCriminalMultiStateScreening = new InstaCriminalMultiStateScreening();

            //_screeningTypes.Add(StateCriminalScreening);
            //_screeningTypes.Add(InstaCriminalSingleStateScreening);
            _screeningTypes.Add(InstaCriminalMultiStateScreening);
        }

        private void CountyCriminalSearchTag(string region, string country)
        {
            CountyCriminalScreening CountyCriminalScreening = new CountyCriminalScreening();
            CountyCriminalScreening.Region = region ?? string.Empty;
            CountyCriminalScreening.County = country ?? string.Empty;
            _screeningTypes.Add(CountyCriminalScreening);
        }        
        #endregion
    }
}
