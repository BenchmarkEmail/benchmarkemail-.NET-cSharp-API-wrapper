namespace BenchmarkEmail
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using CookComputing.XmlRpc;

    public class APIWrapper
    {
        private IBME2 api;
        string apiToken;
        int ErrorCode = 0;
        string ErrorMessage = "";

        public APIWrapper()
        {
            this.api = XmlRpcProxyGen.Create<IBME2>();
            this.api.UserAgent = "BenchmarkEmail v1.0";
            this.api.Timeout = 90000; //default = 90 second timeout
        }

        /**
         ** Set or get CurrentToken     
         **/
        
        public int Timeout
        {
            set { this.api.Timeout = value; }
            get { return this.api.Timeout; }
        }

        public string CurrentToken
        {
            set { this.apiToken = value; }
            get { return this.apiToken; }
        }

        /**
         ** Register() method definition, this  method registers a client
         **/

        public int register(ClientMasterStructure clientstruct)
        {
            try
            {
                return this.api.register(clientstruct);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return -1;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
               ** clientGetContactInfo() method definition, this  method returns the client setting info
               **/

        public ClientSettingsStructure clientGetContactInfo()
        {
            try
            {
                return this.api.clientGetContactInfo(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** GetConfirmEmailList() method definition, this  method gets the lists of emails that the client has sent for confirmation
        **/

        public ConfirmEmailStructure[] confirmEmailList()
        {
            try
            {
                return this.api.confirmEmailList(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** AddConfirmEmail() method definition, this  method adds emails for confirmation
        **/

        public string confirmEmailAdd(string TargetEmailID)
        {
            try
            {
                return this.api.confirmEmailAdd(this.apiToken, TargetEmailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** clientSetContactInfo() method definition, this  method sets the client setting info
        **/

        public int clientSetContactInfo(ClientSettingsStructure CltSeto)
        {
            try
            {
                return this.api.clientSetContactInfo(this.apiToken, CltSeto);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** clientGetPlanInfo() method definition, this  method sets the client setting info
        **/

        public ClientPlanInfoStructure clientGetPlanInfo()
        {
            try
            {
                return this.api.clientGetPlanInfo(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** subAccountCreate() method definition, this  method allows the client to create a subaccount
        **/

        public int subAccountCreate(AccountStructure accountstruct)
        {
            try
            {
                return this.api.subAccountCreate(this.apiToken, accountstruct);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
               ** subAccountUpdate() method definition, this  method allows the client to update the subaccount
               **/

        public int subAccountUpdate(AccountStructure accountstruct)
        {
            try
            {
                return this.api.subAccountUpdate(this.apiToken, accountstruct);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** subAccountGetList() method definition, this  method gets the account list
        **/

        public AccountStructure[] subAccountGetList()
        {
            try
            {
                return this.api.subAccountGetList(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** subAccountUpdateStatus() method definition, Update SubAccount status
        **/

        public void subAccountUpdateStatus(string ID, string status)
        {
            try
            {
                this.api.subAccountUpdateStatus(this.apiToken, ID, status);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }



        /**
         ** login() method definition, this  method returns the token that will be used for all the api methods
         **/
        public string login(string username, string password)
        {
            try
            {
                return this.api.login(username, password);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return "";
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** tokenAdd() method definition, this  method allows you to add your own custom token
        **/
        public bool tokenAdd(string userName, string password, string token)
        {
            try
            {
                return this.api.tokenAdd(userName, password, token);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return false;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** tokenDelete() method definition, this  method allows you to delete your token
         **/
        public bool tokenDelete(string userName, string password, string token)
        {
            try
            {
                return this.api.tokenDelete(userName, password, token);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return false;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** tokenGet() method definition, this  method returns the token string array
        **/
        public string[] tokenGet(string userName, string password)
        {
            try
            {
                return this.api.tokenGet(userName, password);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return null;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** imageGetList() method definition, this  returns the list of images in the your Image Gallery
        **/
        public ImageStructure[] imageGetList(int pageNumber, int pageSize)
        {
            try
            {
                return this.api.imageGetList(this.apiToken, pageNumber, pageSize);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return null;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** ImageDelete() method definition, deletes the Image specified by the ImageID
         **/

        public bool imageDelete(string ImageID)
        {
            try
            {
                return this.api.imageDelete(this.apiToken, ImageID);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return false;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }


        }

        /**
               ** imageAdd() method definition, deletes the Image specified by the ImageID
               **/

        public bool imageAdd(ImageData imgdata)
        {
            try
            {
                return this.api.imageAdd(this.apiToken, imgdata);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return false;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }


        }

        /**
              ** imageGetCount() method definition, deletes the Image specified by the ImageID
              **/

        public int imageGetCount()
        {
            try
            {
                return this.api.imageGetCount(this.apiToken);
            }
            catch (XmlRpcTypeMismatchException)
            {
                return 0;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }


        }

        /**
             ** imageGet() method definition, Get details for an image
             **/

        public ImageData imageGet(string imageID)
        {
            try
            {
                return this.api.imageGet(this.apiToken,imageID);
            }           
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }


        }


        



        /**
        ** emailCopy() method definition, this  method creates a copy of your existing email as specified by the emailID
        **/
        public string emailCopy(string emailID)
        {
            try
            {
                return this.api.emailCopy(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        /**
         ** emailCreate() method definition
         **/
        public string emailCreate(EmailStructure emailData)
        {
            try
            {
                return this.api.emailCreate(this.apiToken, emailData);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** emailRssCreate() method definition
         **/
        public string emailRssCreate(EmailStructure emailData)
        {
            try
            {
                return this.api.emailRssCreate(this.apiToken, emailData);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** emailDelete() method definition
         **/
        public bool emailDelete(string emailID)
        {
            try
            {
                return this.api.emailDelete(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** emailGet() method definition
         **/
        public EmailStructure[] emailGet(string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.emailGet(this.apiToken, filter, status, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailTemplateGetList() method definition
        **/
        public EmailTemplateStructure[] emailTemplateGetList(int pageNumber, int pageSize)
        {
            try
            {
                return this.api.emailTemplateGetList(this.apiToken, pageNumber, pageSize);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailTemplateGetCount() method definition
        **/
        public int emailTemplateGetCount()
        {
            try
            {
                return this.api.emailTemplateGetCount(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
       ** emailPreview() method definition
       **/
        public EmailStructure emailPreview(string emailID,string emailAddress,string htmlContent,string textContent)
        {
            try
            {
                return this.api.emailPreview(this.apiToken,emailID,emailAddress,htmlContent,textContent);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
     ** emailPreviewTest() method definition
     **/
        public string emailPreviewTest(string emailID, string emailAddress, string htmlContent, string textContent, string personalMessage)
        {
            try
            {
                return this.api.emailPreviewTest(this.apiToken, emailID, emailAddress, htmlContent, textContent, personalMessage);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
         ** emailRssGet() method definition
         **/
        public EmailStructure[] emailRssGet(string filter, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.emailRssGet(this.apiToken, filter, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }



        /**
         ** emailGetDetail() method definition
         **/

        public EmailStructure emailGetDetail(string emailID)
        {
            try
            {
                return this.api.emailGetDetail(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** emailRssGetDetail() method definition
         **/

        public EmailStructure emailRssGetDetail(string emailID)
        {
            try
            {
                return this.api.emailRssGetDetail(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
         ** emailSchedule() method definition
         **/

        public bool emailSchedule(string emailID, string scheduleDate)
        {
            try
            {
                return this.api.emailSchedule(this.apiToken, emailID, scheduleDate);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** emailRssSchedule() method definition
         **/

        public bool emailRssSchedule(string emailID, string scheduleDate, string interval)
        {
            try
            {
                return this.api.emailRssSchedule(this.apiToken, emailID, scheduleDate, interval);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailSendNow() method definition
        **/

        public bool emailSendNow(string emailID)
        {
            try
            {
                return this.api.emailSendNow(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
       
        /**
       ** emailSendNow() method definition
       **/

        public int emailCheckName(string emailID,string emailName)
        {
            try
            {
                return this.api.emailCheckName(this.apiToken, emailID,emailName);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailSendTest() method definition
        **/

        public bool emailSendTest(string emailID, string testEmailAddress)
        {
            try
            {
                return this.api.emailSendTest(this.apiToken, emailID, testEmailAddress);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailUnSchedule() method definition
        **/

        public bool emailUnSchedule(string emailID)
        {
            try
            {
                return this.api.emailUnSchedule(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailUpdate() method definition
        **/

        public bool emailUpdate(EmailStructure emailData)
        {
            try
            {
                return this.api.emailUpdate(this.apiToken, emailData);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** emailRssUpdate() method definition
        **/

        public bool emailRssUpdate(EmailStructure emailData)
        {
            try
            {
                return this.api.emailRssUpdate(this.apiToken, emailData);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }



        /**
       ** emailAssignList() method definition
       **/

        public bool emailAssignList(string emailID, EmailContactStructure[] lists)
        {
            try
            {
                return this.api.emailAssignList(this.apiToken, emailID, lists);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        /**
      ** emailReassignList() method definition
      **/

        public bool emailReassignList(string emailID, EmailContactStructure[] lists)
        {
            try
            {
                return this.api.emailReassignList(this.apiToken, emailID, lists);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
         ** emailResend() method definition
         **/

        public string emailResend(string emailID, string scheduleDate)
        {
            try
            {
                return this.api.emailResend(this.apiToken, emailID, scheduleDate);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
         ** emailQuickSend() method definition
         **/

        public string emailQuickSend(string emailID, string ListName, EmailAddressStructure[] emails, string scheduleDate)
        {
            try
            {
                return this.api.emailQuickSend(this.apiToken, emailID, ListName, emails, scheduleDate);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** autoresponderGetList() method definition
        **/
        public AutoresponderStructure[] autoresponderGetList(int pageNumber, int pageSize, string orderBy, string filter, string sortOrder)
        {
            try
            {
                return this.api.autoresponderGetList(this.apiToken, pageNumber, pageSize, orderBy, filter, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** autoresponderGetDetail() method definition
        **/
        public AutoResponderDetailedStructure autoresponderGetDetail(string autoresponderID)
        {
            try
            {
                return this.api.autoresponderGetDetail(this.apiToken, autoresponderID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** autoresponderGetEmailDetail() method definition
        **/

        public EmailStructure autoresponderGetEmailDetail(string autoresponderID, string autoresponderDetailID)
        {
            try
            {
                return this.api.autoresponderGetEmailDetail(this.apiToken, autoresponderID, autoresponderDetailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** autoresponderCreate() method definition
        **/

        public string autoresponderCreate(AutoResponderDataStructure Autoresponder)
        {
            try
            {
                return this.api.autoresponderCreate(this.apiToken, Autoresponder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** autoresponderDetailDelete() method definition
         **/

        public bool autoresponderDetailDelete(string autoresponderID, string autoresponderDetailID )
        {
            try
            {
                return this.api.autoresponderDetailDelete(this.apiToken, autoresponderID, autoresponderDetailID );
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** autoresponderDetailHistoryDelete() method definition
        **/

        public bool autoresponderDetailHistoryDelete(string autoresponderID, string autoresponderDetailID,string email)
        {
            try
            {
                return this.api.autoresponderDetailHistoryDelete(this.apiToken, autoresponderID, autoresponderDetailID,email);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** autoresponderDelete() method definition
         **/

        public bool autoresponderDelete(string autoresponderID)
        {
            try
            {
                return this.api.autoresponderDelete(this.apiToken, autoresponderID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }



        /**
        ** autoresponderUpdate() method definition
        **/

        public bool autoresponderUpdate(string autoresponderID, int status, AutoResponderDataStructure Autoresponder)
        {
            try
            {
                return this.api.autoresponderUpdate(this.apiToken, autoresponderID ,  status , Autoresponder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** autoresponderDetailCreate() method definition
        **/

        public string autoresponderDetailCreate(string autoresponderID, AutoResponderDetailDataStructure AutoresponderDetail)
        {
            try
            {
                return this.api.autoresponderDetailCreate(this.apiToken, autoresponderID, AutoresponderDetail);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** batchAddContacts() method definition
        **/
        public string batchAddContacts(string listID, XmlRpcStruct[] contacts)
        {
            try
            {
                return this.api.batchAddContacts(this.apiToken, listID, contacts);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        /**
        ** batchGetStatus() method definition
        **/
        public string batchGetStatus(string listID, string batchID)
        {
            try
            {
                return this.api.batchGetStatus(this.apiToken, listID, batchID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** listAddContacts() method definition
        **/
        public int listAddContacts(string listID, XmlRpcStruct[] contacts)
        {
            try
            {
                return this.api.listAddContacts(this.apiToken, listID, contacts);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** listAddContactsOptin() method definition
        **/
        public int listAddContactsOptin(string listID, ContactStructure[] contacts, string optin)
        {
            try
            {
                return this.api.listAddContactsOptin(this.apiToken, listID, contacts, optin);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** listCreate() method definition
         **/
        public string listCreate(string listname)
        {
            try
            {
                return this.api.listCreate(this.apiToken, listname);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** listDelete() method definition
        **/
        public bool listDelete(string listID)
        {
            try
            {
                return this.api.listDelete(this.apiToken, listID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
       ** ContactStructure() method definition
       **/
        public ContactListStructure[] listSearchContacts(string emailID)
        {
            try
            {
                return this.api.listSearchContacts(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** ContactListStructure() method definition
        **/
        public ContactListStructure[] listGet(string filter, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.listGet(this.apiToken, filter, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** listGetContactDetails() method definition
        **/
        public System.Collections.Hashtable listGetContactDetails(string listID, string email)
        {
            try
            {
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                XmlRpcStruct xml = this.api.listGetContactDetails(this.apiToken, listID, email);
                System.Collections.IEnumerator en = xml.Keys.GetEnumerator();
                while (en.MoveNext())
                {
                    ht.Add(en.Current, xml[en.Current]);
                }
                return ht;
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
      ** ContactStructure() method definition
      **/
        public System.Collections.Hashtable[] listGetContactsAllFields(string listID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.listGetContactsAllFields(this.apiToken, listID, filter, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** ContactStructure() method definition
         **/
        public ContactStructure[] listGetContacts(string listID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.listGetContacts(this.apiToken, listID, filter, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        /**
         ** ContactStructure() method definition
         **/
        public ContactStructure[] listGetContactsByType(string listID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder, string Type)
        {
            try
            {
                return this.api.listGetContactsByType(this.apiToken, listID, filter, pageNumber, pageSize, orderBy, sortOrder, Type);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** listUnsubscribeContacts() method definition
        **/
        public int listUnsubscribeContacts(string listID, string[] contacts)
        {
            try
            {
                return this.api.listUnsubscribeContacts(this.apiToken, listID, contacts);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** listDeleteContacts() method definition
        **/
        public bool listDeleteContacts(string listID, string contacts)
        {
            try
            {
                return this.api.listDeleteContacts(this.apiToken, listID, contacts);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** listDeleteEmailContact() method definition
        **/
        public bool listDeleteEmailContact(string listID, string email)
        {
            try
            {
                return this.api.listDeleteEmailContact(this.apiToken, listID, email);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** listUpdateContactDetails() method definition
        **/

        public XmlRpcStruct listUpdateContactDetails(string listID, string contactID, XmlRpcStruct contactDetails)
        {
            try
            {
                return this.api.listUpdateContactDetails(this.apiToken, listID, contactID, contactDetails);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        
        /**
         ** listAddContactsForm() method definition
         **/
        public int listAddContactsForm(string formid, SignupFormContactStructure contacts)
        {
            try
            {
                return this.api.listAddContactsForm(this.apiToken, formid, contacts);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
         ** segmentCreate() method definition
         **/
        public string segmentCreate(SegmentStructure segment)
        {
            try
            {
                return this.api.segmentCreate(this.apiToken, segment);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentCreateCriteria() method definition
         **/
        public string segmentCreateCriteria(string segmentID, SegmentCriteriaStructure criteria)
        {
            try
            {
                return this.api.segmentCreateCriteria(this.apiToken, segmentID, criteria);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentDelete() method definition
         **/
        public bool segmentDelete(string segmentID)
        {
            try
            {
                return this.api.segmentDelete(this.apiToken, segmentID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentDeleteCriteria() method definition
         **/
        public bool segmentDeleteCriteria(string segmentID, string criteriaID)
        {
            try
            {
                return this.api.segmentDeleteCriteria(this.apiToken, segmentID, criteriaID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentGet() method definition
         **/
        public SegmentListStructure[] segmentGet(string filter, int pageNumber, int pageSize, string orderBy)
        {
            try
            {
                return this.api.segmentGet(this.apiToken, filter, pageNumber, pageSize, orderBy);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentGetContacts() method definition
         **/
        public ContactStructure[] segmentGetContacts(string segmentID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.segmentGetContacts(this.apiToken, segmentID, filter, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentGetCount() method definition
         **/
        public double segmentGetCount(string filter)
        {
            try
            {
                return this.api.segmentGetCount(this.apiToken, filter);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentGetCriteriaList() method definition
         **/
        public SegmentCriteriaStructure[] segmentGetCriteriaList(string segmentID)
        {
            try
            {
                return this.api.segmentGetCriteriaList(this.apiToken, segmentID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** segmentGetCriteriaList() method definition
         **/
        public SegmentStructure segmentGetDetail(string segmentID)
        {
            try
            {
                return this.api.segmentGetDetail(this.apiToken, segmentID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** reportGet() method definition
        **/
        public EmailStructure[] reportGet(string filter, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGet(this.apiToken, filter, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** reportGetBounces() method definition
        **/
        public ReportBounceStructure[] reportGetBounces(string emailID, int pageNumber, int pageSize,string Filter, string orderBy,string sortOrder)
        {
            try
            {
                return this.api.reportGetBounces(this.apiToken, emailID, pageNumber, pageSize, Filter,orderBy,sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** reportGetClicks() method definition
         **/
        public ReportClickStructure[] reportGetClicks(string emailID)
        {
            try
            {
                return this.api.reportGetClicks(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
         ** reportGetClickEmails() method definition
         **/
        public ReportDataStructure[] reportGetClickEmails(string emailID,string clickUrl, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetClickEmails(this.apiToken, emailID,clickUrl, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** reportGetForwards() method definition
        **/

        public ReportDataStructure[] reportGetForwards(string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetForwards(this.apiToken, emailID, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** reportGetHardBounces() method definition
        **/

        public ReportBounceStructure[] reportGetHardBounces(string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetHardBounces(this.apiToken, emailID, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** reportGetSoftBounces() method definition
        **/
        public ReportBounceStructure[] reportGetSoftBounces(string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetSoftBounces(this.apiToken, emailID, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** reportGetOpens() method definition
        **/
        public ReportDataStructure[] reportGetOpens(string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetOpens(this.apiToken, emailID, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** reportGetOpens() method definition
        **/
        public ReportDataStructure[] reportGetUnopens(string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetUnopens(this.apiToken, emailID, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
        ** reportGetUnsubscribes() method definition
         **/

        public ReportDataStructure[] reportGetUnsubscribes(string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.reportGetUnsubscribes(this.apiToken, emailID, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        /**
        ** reportGetSummary() method definition
        **/

        public ReportSummaryStructure reportGetSummary(string emailID)
        {
            try
            {
                return this.api.reportGetSummary(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

      

        public ReportSummaryStructure[] reportCompare(string emailIDs)
        {
            try
            {
                return this.api.reportCompare(this.apiToken, emailIDs);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public ReportCountryOpenStruct[] reportGetOpenCountry(string emailID)
        {
            try
            {
                return this.api.reportGetOpenCountry(this.apiToken, emailID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public ReportCountryOpenStruct[] reportGetOpenForCountry(string emailID, string CountryCode)
        {
            try
            {
                return this.api.reportGetOpenForCountry(this.apiToken, emailID, CountryCode);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        /**
       ** AddConfirmEmail() method definition, this  method adds emails for confirmation
       **/

        public string pollCreate(PollStructure poll)
        {
            try
            {
                return this.api.pollCreate(this.apiToken, poll);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string pollDelete(string PollID)
        {
            try
            {
                return this.api.pollDelete(this.apiToken, PollID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string pollUpdate(string PollID,PollStructure poll)
        {
            try
            {
                return this.api.pollUpdate(this.apiToken,PollID, poll);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public PollStructure[] pollReportList(string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.pollReportList(this.apiToken, filter, status, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public PollStructure[] pollGetList(string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.pollGetList(this.apiToken, filter, status, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public PollStructure[] pollResponseReport(string PollID)
        {
            try
            {
                return this.api.pollResponseReport(this.apiToken, PollID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public int pollStatusUpdate(string PollID, string Status)
        {
            try
            {
                return this.api.pollStatusUpdate(this.apiToken, PollID, Status);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public string pollCopy(string PollID, string NewPollName)
        {
            try
            {
                return this.api.pollCopy(this.apiToken, PollID, NewPollName);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
       
        public SurveyStructure[] surveyGetList(string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.surveyGetList(this.apiToken, filter, status, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string surveyCreate(SurveyStructure surveyData)
        {
            try
            {
                return this.api.surveyCreate(this.apiToken,surveyData);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public string surveyQuestionCreate(string SurveyID,SurveyQuestionStructure surveyquestion)
        {
            try
            {
                return this.api.surveyQuestionCreate(this.apiToken,SurveyID, surveyquestion);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string surveyColorUpdate(string SurveyID,SurveyColorStructure surveyColor)
        {
            try
            {
                return this.api.surveyColorUpdate(this.apiToken,SurveyID, surveyColor);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string surveyUpdate(string SurveyID,SurveyStructure survey)
        {
            try
            {
                return this.api.surveyUpdate(this.apiToken,SurveyID,survey);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string surveyQuestionUpdate(string SurveyID,SurveyQuestionStructure surveyQuestion)
        {
            try
            {
                return this.api.surveyQuestionUpdate(this.apiToken,SurveyID, surveyQuestion);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public string surveyDelete(string SurveyID)
        {
            try
            {
                return this.api.surveyDelete(this.apiToken, SurveyID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public int surveyStatusUpdate(string SurveyID,string Status)
        {
            try
            {
                return this.api.surveyStatusUpdate(this.apiToken, SurveyID,Status);
            }
             catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public SurveyQuestionStructure[] surveyGetQuestionList(string SurveyID)
        {
            try
            {
                return this.api.surveyGetQuestionList(this.apiToken,SurveyID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public SurveyColorStructure surveyGetColor(string SurveyID)
        {
            try
            {
                return this.api.surveyGetColor(this.apiToken, SurveyID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }

        }
        public ReportSurveyStructure[] surveyReportList(string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder)
        {
            try
            {
                return this.api.surveyReportList(this.apiToken, filter, status, pageNumber, pageSize, orderBy, sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public SurveyQuestionStructure[] surveyResponseReport(string SurveyID)
        {
            try
            {
                return this.api.surveyResponseReport(this.apiToken, SurveyID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public string surveyQuestionDelete(string SurveyID,string QuestionID)
        {
            try
            {
                return this.api.surveyQuestionDelete(this.apiToken, SurveyID,QuestionID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public EmailTemplateCategoryStructure[] emailCategoryGetList()
        {
            try
            {
                return this.api.emailCategoryGetList(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public SurveyTemplateStructure[] surveyTemplateGetList()
        {
            try
            {
                return this.api.surveyTemplateGetList(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string surveyCopy(string SurveyID, string NewSurveyName)
        {
            try
            {
                return this.api.surveyCopy(this.apiToken, SurveyID, NewSurveyName);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string surveyCopyTemplate(string TemplateID, string NewSurveyName)
        {
            try
            {
                return this.api.surveyCopyTemplate(this.apiToken, TemplateID, NewSurveyName);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public Boolean videoCreate(VideoGalleryStructure videoStructure)
        {
            try
            {
                return this.api.videoCreate(this.apiToken, videoStructure);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public string videoDelete(string VideoID)
        {
            try
            {
                return this.api.videoDelete(this.apiToken, VideoID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public VideoGalleryStructure[] videoGetList(int pagenumber, int pagesize)
       {
           try
           {
               return this.api.videoGetList(this.apiToken, pagenumber, pagesize);
           }
           catch (XmlRpcFaultException xe)
           {
               this.ErrorCode = xe.FaultCode;
               this.ErrorMessage = xe.FaultString;
               throw xe;
           }
       }
        public string signupFormCreate(SignupFormDataStructure signupForm)
        {
            try
            {
                return this.api.signupFormCreate(this.apiToken, signupForm);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public bool signupFormUpdateColor(string signFormID,SignupFormColorStructure signupForm)
        {
            try
            {
                return this.api.signupFormUpdateColor(this.apiToken,signFormID, signupForm);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public bool signupFormUpdateMessage(string signFormID, SignupFormDataStructure signupForm)
        {
            try
            {
                return this.api.signupFormUpdateMessage(this.apiToken, signFormID, signupForm);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public bool signupFormDelete(string signFormID)
        {
            try
            {
                return this.api.signupFormDelete(this.apiToken, signFormID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public bool signupFormUpdate(string signFormID, SignupFormDataStructure singupForm)
        {
            try
            {
                return this.api.signupFormUpdate(this.apiToken, signFormID, singupForm);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public SignupFormDataStructure signupFormGet(string signFormID)
        {
            try
            {
                return this.api.signupFormGet(this.apiToken, signFormID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public string signupFormGetCode(string signFormID, string codeType)
        {
            try
            {
                return this.api.signupFormGetCode(this.apiToken, signFormID, codeType);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        /**
         ** SignupFormStructure() method definition
         **/

        public SignupFormStructure[] listGetSignupForms(int pageNumber, int pageSize, string orderBy,string sortOrder)
        {
            try
            {
                return this.api.listGetSignupForms(this.apiToken, pageNumber, pageSize, orderBy,sortOrder);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public XmlRpcStruct listGetContactFields(string listID)
        {
            try
            {
                return this.api.listGetContactFields(this.apiToken, listID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public double listGetContactsCount(string listID, string filter)
        {
            try
            {
                return this.api.listGetContactsCount(this.apiToken, listID,filter);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public double listGetCount(string filter)
        {
            try
            {
                return this.api.listGetCount(this.apiToken, filter);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }
        public double reportGetCount(string filter)
        {
            try
            {
                return this.api.reportGetCount(this.apiToken, filter);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }

        public int videoGetCount()
        {
            try
            {
                return this.api.videoGetCount(this.apiToken);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }
        }


        public VideoGalleryStructure videoGet(string videoID)
        {
            try
            {
                return this.api.videoGet(this.apiToken, videoID);
            }
            catch (XmlRpcFaultException xe)
            {
                this.ErrorCode = xe.FaultCode;
                this.ErrorMessage = xe.FaultString;
                throw xe;
            }

        }

        

    }





    #region Structures

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ImageData
    {
        public string image_id;
        public string image_name;
        public string image_url;
        public string image_data;
        public string image_height;
        public string image_width;
        public string image_size;
    }
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ImageStructure
    {
        public int sequence;
        public string id;
        public string client_id;
        public string image_path_virtual;
        public string image_size;
        public string image_h;
        public string image_w;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ClientPlanInfoStructure
    {
        public string plan_name;
        public string plan_email_limit;
        public string additional_amount;
        public string account_expire;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ClientMasterStructure
    {
        public string firstname;
        public string lastname;
        public string companyname;
        public string email;
        public string phone;
        public string login;
        public string password;
        public string promocode;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ConfirmEmailStructure
    {
        public int sequence;
        public string id;
        public string email;
        public string confirmed;
        public string createddate;
        public string modifieddate;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ClientSettingsStructure
    {
        public string client_id;
        public string company;
        public string phone;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string country;
        public string email;
        public string first_name;
        public string last_name;
    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SignupFormStructure
    {
        public int sequence;
        public string id;
        public string name;
        public string listName;
        public string toListName;
        public string added;
        public string encToken;
    }

    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SignupFormDataStructure
    {
        public int sequence;
        public string id;
        public string name;
        public ContactListStructure[] lists;
        public string introduction;
        public string title;
        public string logo;
        public string save;
        public string welcomeEmailFromName;
        public string welcomeEmailFromEmail;
        public string welcomeEmailSubject;
        public string welcomeEmailMessage;
        public string welcomeEmailConfirmationText;
        public string welcomeEmailSignature;
        public string successRedirectURL;
        public string optinRedirectURL;
        public string optinAlertFrequency;
        public SignupFormFieldDataStructure[] fields;
    }


    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SignupFormColorStructure
    {
        public int sequence;
        public string id;
        public string border;
        public string headerBackground;
        public string header;
        public string formBackground;
        public string form;
        public string paraBackground;
        public string headerFont;
        public string headerSize;
        public string formFont;
        public string formSize;
        public string paraFont;
        public string paraSize;
        public string button;
        public string logoAlign;
        public string titleAlign;
        public string introAlign;
        public string buttonAlign;
        public string width;
    }

    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SignupFormFieldDataStructure
    {
        public int sequence;
        public string field;
        public string label;
        public string type;
        public string order;
        public string required;
    }
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct AccountStructure
    {
        public string clientid;
        public string login;
        public string password;
        public string firstname;
        public string lastname;
        public string email;
        public string phone;
        public string free_mail_sent;
        public string active;
        public string plan_email_limit;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct EmailStructure
    {
        public int sequence;
        public string id;
        public string emailName;
        public string subject;
        public string fromName;
        public string fromEmail;
        public string replyEmail;
        public bool isSegment;
        public int toListID;
        public string toListName;
        public string status;
        public string templateContent;
        public string templateText;
        public string us_address;
        public string us_city;
        public string us_state;
        public string us_zip;
        public string permissionReminderMessage;
        public string googleAnalyticsCampaign;
        public bool webpageVersion;
        public string intl_address;
        public string scheduleDate;
        public string createdDate;
        public string modifiedDate;
        public string rssurl;
        public string rssinterval;
        public string rssactive;
        public string version;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ContactStructure
    {
        public int sequence;
        public string id;
        public string email;
        public string firstname;
        public string lastname;
        public string middlename;
        public string emailtype;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ContactListStructure
    {
        public int sequence;
        public string id;
        public string listname;
        public int contactcount;
        public string createdDate;
        public string modifiedDate;
        public string permissionPassList;
        public string is_importing;
        public string list_audited;
        public string list_description;
        public string is_master_unsubscribe;
        public string encToken;
        //public string encTokenAdd;
        public string allow_delete;
    }

    

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SegmentCriteriaStructure
    {
        public int sequence;
        public string id;
        public string field;
        public string segmentid;
        public string startDate;
        public string endDate;
        public string filterType;
        public string filter;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SegmentStructure
    {
        public int sequence;
        public string id;
        public string segmentname;
        public string description;
        public string listid;
        public string listname;
        public int contactcount;
        public string createdDate;
        public string modifiedDate;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SegmentListStructure
    {
        public int sequence;
        public string id;
        public string segmentname;
        public string listid;
        public string listname;
        public int contactcount;
        public string createdDate;
        public string modifiedDate;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SignupFormContactStructure
    {
        public string email;
        public string firstname;
        public string lastname;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ReportBounceStructure
    {
        public string sequence;
        public string email;
        public string name;
        public string type;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ReportClickStructure
    {
        public string sequence;
        public string URL;
        public string clicks;
        public string percent;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ReportDataStructure
    {
        public string sequence;
        public string email;
        public string name;
        public string logdate;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ReportSummaryStructure
    {
        public string mailSent;
        public string id;
        public string emailName;
        public string clicks;
        public string opens;
        public string bounces;
        public string abuseReports;
        public string unsubscribes;
        public int toListID;
        public string toListName;
        public string forwards;
        public string scheduleDate;
        public string subject;
        public string shareURL;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct EmailContactStructure
    {
        public int sequence;
        public string emailID;
        public bool isSegment;
        public string toSegmentID;
        public string toListID;
        public string toListName;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct EmailAddressStructure
    {      
        public string email;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct AutoresponderStructure
    {
        public int sequence;
        public string id;
        public string autoresponderName;
        public string totalEmails;
        public string status;
        public string modifiedDate;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct AutoResponderEmailsStructure
    {
        public string autoresponderDetailID;
        public string subject;
        public string days;
        public string type;
        public string whentosend;
        public string fieldtocompare;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct AutoResponderDetailedStructure
    {
        public string id;
        public string autoresponderName;
        public string totalEmails;
        public string status;
        public string createdDate;
        public string modifiedDate;
        public string contactListID;
        public string contactListName;
        public string isSegment;
        public string fromName;
        public string fromEmail;
        public string permissionReminderMessage;
        public bool webpageVersion;
        public AutoResponderEmailsStructure[] emails;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct AutoResponderDataStructure
    {
        public string autoresponderName;
        public string contactListID;
        public string fromName;
        public string fromEmail;
        public bool permissionReminder;
        public string permissionReminderMessage;
        public bool webpageVersion;
        public bool isSegment;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct AutoResponderDetailDataStructure
    {
        public string subject;
        public string templateContent;
        public string templateText;
        public string us_address;
        public string us_city;
        public string us_state;
        public string us_zip;
        public string intl_address;
        public string days;
        public string type;
        public string whentosend;
        public string fieldtocompare;
    }

    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct PollStructure
    {
        public int sequence;
        public string id;
        public string name;
        public string question;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public string answer5;
        public string answer1count;
        public string answer2count;
        public string answer3count;
        public string answer4count;
        public string answer5count;
        public string responses;
        public string status;
        public string encToken;
        public string createdDate;
        public string modifiedDate;
        public string questioncolor;
        public string questionfont;
        public string answercolor;
        public string answerfont;
        public string buttontext;
        public string borderbg;
        public string formbg;
        public string livedate;        
        public string url;
    }

    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SurveyStructure
    {
        public int sequence;
        public string id;
        public string name;
        public string title;
        public string description;
        public string url;
        public string message;
        public string intro;
        public string logourl;
        public string questions;
        public string responses;
        public string status;
        public string encToken;
        public string createdDate;
        public string modifiedDate;
        public string livedate;
        public string successurl;

    }

    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SurveyQuestionStructure
    {
        public string questionid;
        public string surveyid;
        public string question;
        public string questiontype;
        public string questionoptions;
        public string notes;
        public string required;
        public string comment;
        public string commentcount;
        public string other;
        public string othercount;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public string answer5;
        public string answer6;
        public string answer7;
        public string answer8;
        public string answer9;
        public string answer10;
        public string[] answercount;
        public string answer1count;
        public string answer2count;
        public string answer3count;
        public string answer4count;
        public string answer5count;
        public string answer6count;
        public string answer7count;
        public string answer8count;
        public string answer9count;
        public string answer10count;
        public string textcount;

    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SurveyColorStructure
    {
        public string surveyid;
        public string questionfg;
        public string formbg;
        public string formfg;
        public string headerbg;
        public string headerfg;
        public string parafg;
        public string headerfont;
        public string headersize;
        public string parafont;
        public string parasize;
        public string questionfont;
        public string questionsize;
        public string answerfont;
        public string answersize;
        public string logoalign;
        public string introalign;
        public string titlealign;
        public string buttontext;
        public string buttonalign;
    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ReportSurveyStructure
    {
        public string id;
        public string name;
        public string response;
        public string status;
        public string intro;
        public string active;
        public string questions;
        public string createdDate;
        public string modifiedDate;
        public string encToken;
        public string pdfEncToken;
    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct VideoGalleryStructure
    {
        public int sequence;
        public string client_videos;
        public string id;
        public string client_id;
        public string video_name;
        public string video_description;
        public string video_height;
        public string video_width;
        public string video_image;
        public string video_embed;
        public string encToken;
        public string createddatetime;
    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct EmailTemplateCategoryStructure
    {
        public int sequence;
        public string id;
        public string name;
        public string count;
        public string newFlag;
    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct EmailTemplateStructure
    {
        public int sequence;
        public string id;
        public string template_name;
        public string template_source;
        public string preview_small;
        public string backgroundImage;
        public string headerImage;
        public string content;
    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct SurveyTemplateStructure
    {
        public int sequence;
        public string id;
        public string name;
        public string image;
        public string description;
        public string quesCount;
        public string encToken;

    }
    [Serializable]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct ReportCountryOpenStruct
    {
        public string sequence;
        public string country_name;
        public string country_region;
        public string openCount;
    }
    #endregion Structures
    [XmlRpcUrl("http://api.benchmarkemail.com/1.0")] 

    public interface IBME2 : IXmlRpcProxy
    {
        #region Global

        [XmlRpcMethod("register")]
        int register(ClientMasterStructure clientstruct);

        [XmlRpcMethod("clientGetContactInfo")]
        ClientSettingsStructure clientGetContactInfo(string token);

        [XmlRpcMethod("confirmEmailList")]
        ConfirmEmailStructure[] confirmEmailList(string token);

        [XmlRpcMethod("confirmEmailAdd")]
        string confirmEmailAdd(string token, string TargetEmailID);

        [XmlRpcMethod("clientSetContactInfo")]
        int clientSetContactInfo(string token, ClientSettingsStructure CltSeto);

        [XmlRpcMethod("clientGetPlanInfo")]
        ClientPlanInfoStructure clientGetPlanInfo(string token);

        [XmlRpcMethod("subAccountCreate")]
        int subAccountCreate(string token, AccountStructure accountstruct);

        [XmlRpcMethod("subAccountUpdate")]
        int subAccountUpdate(string token, AccountStructure accountstruct);

        [XmlRpcMethod("subAccountGetList")]
        AccountStructure[] subAccountGetList(string token);

        [XmlRpcMethod("subAccountUpdateStatus")]
        void subAccountUpdateStatus(string token, string ID, string status);

        [XmlRpcMethod("login")]
        string login(string username, string password);

        [XmlRpcMethod("tokenAdd")]
        bool tokenAdd(string userName, string password, string token);

        [XmlRpcMethod("tokenDelete")]
        bool tokenDelete(string userName, string password, string token);

        [XmlRpcMethod("tokenGet")]
        string[] tokenGet(string userName, string password);

        #endregion Global

        #region Image Related
        [XmlRpcMethod("imageGetList")]
        ImageStructure[] imageGetList(string token, int pageNumber, int pageSize);

        [XmlRpcMethod("imageDelete")]
        bool imageDelete(string token, string ImageID);

        [XmlRpcMethod("imageAdd")]
        bool imageAdd(string token, ImageData imgdata);

        [XmlRpcMethod("imageGetCount")]
        int imageGetCount(string token);

        [XmlRpcMethod("imageGet")]
        ImageData imageGet(string token, string imageID);

        #endregion Image related

        #region Email Related
        [XmlRpcMethod("emailCategoryGetList")]
        EmailTemplateCategoryStructure[] emailCategoryGetList(string token);

        [XmlRpcMethod("emailCheckName")]
        int emailCheckName(string token,string emailID,string emailName);

        [XmlRpcMethod("emailAssignList")]
        bool emailAssignList(string token, string emailID, EmailContactStructure[] lists);

        [XmlRpcMethod("emailReassignList")]
        bool emailReassignList(string token, string emailID, EmailContactStructure[] lists);

        [XmlRpcMethod("emailCopy")]
        string emailCopy(string token, string emailID);

        [XmlRpcMethod("emailCreate")]
        string emailCreate(string token, EmailStructure emailData);

        [XmlRpcMethod("emailRssCreate")]
        string emailRssCreate(string token, EmailStructure emailData);

        [XmlRpcMethod("emailDelete")]
        bool emailDelete(string token, string emailID);

        [XmlRpcMethod("emailGet")]
        EmailStructure[] emailGet(string token, string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("emailRssGet")]
        EmailStructure[] emailRssGet(string token, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("emailGetDetail")]
        EmailStructure emailGetDetail(string token, string emailID);

        [XmlRpcMethod("emailRssGetDetail")]
        EmailStructure emailRssGetDetail(string token, string emailID);

        [XmlRpcMethod("emailSchedule")]
        bool emailSchedule(string token, string emailID, string scheduleDate);

        [XmlRpcMethod("emailRssSchedule")]
        bool emailRssSchedule(string token, string emailID, string scheduleDate, string interval);

        [XmlRpcMethod("emailSendNow")]
        bool emailSendNow(string token, string emailID);

        [XmlRpcMethod("emailSendTest")]
        bool emailSendTest(string token, string emailID, string testEmail);

        [XmlRpcMethod("emailUnSchedule")]
        bool emailUnSchedule(string token, string emailID);

        [XmlRpcMethod("emailUpdate")]
        bool emailUpdate(string token, EmailStructure emailData);

        [XmlRpcMethod("emailRssUpdate")]
        bool emailRssUpdate(string token, EmailStructure emailData);

        [XmlRpcMethod("emailResend")]
        string emailResend(string token, string emailID, string scheduleDate);

        [XmlRpcMethod("emailQuickSend")]
        string emailQuickSend(string token, string emailID, string ListName, EmailAddressStructure[] emails, string scheduleDate);

        [XmlRpcMethod("emailTemplateGetList")]
        EmailTemplateStructure[] emailTemplateGetList(string token, int pageNubmer, int pageSize);

        [XmlRpcMethod("emailTemplateGetCount")]
        int emailTemplateGetCount(string token);

        [XmlRpcMethod("emailPreview")]
        EmailStructure emailPreview(string token, string emailID, string emailAddress, string htmlContent, string textContent);

        [XmlRpcMethod("emailPreviewTest")]
        string emailPreviewTest(string token, string emailID, string emailAddress, string htmlContent, string textContent, string personalMessage);


        [XmlRpcMethod("autoresponderGetList")]
        AutoresponderStructure[] autoresponderGetList(string token, int pageNumber, int pageSize, string orderBy, string filter, string sortOrder);

        [XmlRpcMethod("autoresponderGetDetail")]
        AutoResponderDetailedStructure autoresponderGetDetail(string token, string autoresponderID);

        [XmlRpcMethod("autoresponderGetEmailDetail")]
        EmailStructure autoresponderGetEmailDetail(string token, string autoresponderID, string autoresponderDetailID);

        [XmlRpcMethod("autoresponderCreate")]
        string autoresponderCreate(string token, AutoResponderDataStructure Autoresponder);

        [XmlRpcMethod("autoresponderDelete")]
        bool autoresponderDelete(string token, string autoresponderID );

        [XmlRpcMethod("autoresponderUpdate")]
        bool autoresponderUpdate(string token, string autoresponderID, int status, AutoResponderDataStructure Autoresponder);

        [XmlRpcMethod("autoresponderDetailCreate")]
        string autoresponderDetailCreate(string token, string autoresponderID, AutoResponderDetailDataStructure AutoresponderDetail);

        [XmlRpcMethod("autoresponderDetailDelete")]
        bool autoresponderDetailDelete(string token, string autoresponderID, string autoresponderDetailID);

        [XmlRpcMethod("autoresponderDetailHistoryDelete")]
        bool autoresponderDetailHistoryDelete(string token, string autoresponderID, string autoresponderDetailID,string email);

        

        #endregion Email Related

        #region List Related
        [XmlRpcMethod("listSearchContacts")]
        ContactListStructure[] listSearchContacts(string token, string emailID);

        [XmlRpcMethod("listAddContacts")]
        int listAddContacts(string token, string listID, XmlRpcStruct[] contacts);

        [XmlRpcMethod("listAddContactsOptin")]
        int listAddContactsOptin(string token, string listID, ContactStructure[] contacts, string optin);
        
        [XmlRpcMethod("batchAddContacts")]
        string batchAddContacts(string token, string listID, XmlRpcStruct[] contacts);

        [XmlRpcMethod("batchGetStatus")]
        string batchGetStatus(string token, string listID, string batchID);
        
        [XmlRpcMethod("listCreate")]
        string listCreate(string token, string listname);

        [XmlRpcMethod("listDelete")]
        bool listDelete(string token, string listID);

        [XmlRpcMethod("listGet")]
        ContactListStructure[] listGet(string token, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("listGetContactDetails")]
        XmlRpcStruct listGetContactDetails(string token, string listID, string email);

        [XmlRpcMethod("listGetContacts")]
        ContactStructure[] listGetContacts(string token, string listID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("listGetContactsByType")]
        ContactStructure[] listGetContactsByType(string token, string listID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder,string Type);

        [XmlRpcMethod("listUnsubscribeContacts")]
        int listUnsubscribeContacts(string token, string listID, string[] contacts);

        [XmlRpcMethod("listDeleteContacts")]
        bool listDeleteContacts(string token, string listID, string contacts);

        [XmlRpcMethod("listDeleteEmailContact")]
        bool listDeleteEmailContact(string token, string listID, string email);

        [XmlRpcMethod("listUpdateContactDetails")]
        XmlRpcStruct listUpdateContactDetails(string token, string listID, string contactID, XmlRpcStruct contactDetails);


        [XmlRpcMethod("listAddContactsForm")]
        int listAddContactsForm(string token, string formid, SignupFormContactStructure contacts);

        [XmlRpcMethod("listGetContactFields")]
        XmlRpcStruct listGetContactFields(string token, string listID);

        [XmlRpcMethod("listGetContactsAllFields")]
        XmlRpcStruct[] listGetContactsAllFields(string token, string listID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder);


        [XmlRpcMethod("listGetContactsCount")]
        double listGetContactsCount(string token, string listID, string filter);

        [XmlRpcMethod("listGetCount")]
        double listGetCount(string token, string filter);

        [XmlRpcMethod("segmentCreate")]
        string segmentCreate(string token, SegmentStructure segment);

        [XmlRpcMethod("segmentCreateCriteria")]
        string segmentCreateCriteria(string token, string segmentID, SegmentCriteriaStructure criteria);

        [XmlRpcMethod("segmentDelete")]
        bool segmentDelete(string token, string segmentID);

        [XmlRpcMethod("segmentDeleteCriteria")]
        bool segmentDeleteCriteria(string token, string segmentID, string criteriaID);

        [XmlRpcMethod("segmentGet")]
        SegmentListStructure[] segmentGet(string token, string filter, int pageNumber, int pageSize, string orderBy);

        [XmlRpcMethod("segmentGetContacts")]
        ContactStructure[] segmentGetContacts(string token, string segmentID, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("segmentGetCount")]
        double segmentGetCount(string token, string filter);

        [XmlRpcMethod("segmentGetCriteriaList")]
        SegmentCriteriaStructure[] segmentGetCriteriaList(string token, string segmentID);

        [XmlRpcMethod("segmentGetDetail")]
        SegmentStructure segmentGetDetail(string token, string segmentID);
        #endregion List Related

        #region Poll Related
        [XmlRpcMethod("pollCreate")]
        string pollCreate(string token, PollStructure poll);

        [XmlRpcMethod("pollDelete")]
        string pollDelete(string token, string PollID);

        [XmlRpcMethod("pollUpdate")]
        string pollUpdate(string token, string PollID, PollStructure poll);

        [XmlRpcMethod("pollReportList")]
        PollStructure[] pollReportList(string token, string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("pollGetList")]
        PollStructure[] pollGetList(string token, string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("pollResponseReport")]
        PollStructure[] pollResponseReport(string token, string PollID);

        [XmlRpcMethod("pollStatusUpdate")]
        int pollStatusUpdate(string token, string PollID, string Status);

        [XmlRpcMethod("pollCopy")]
        string pollCopy(string token, string PollID, string NewPollName);
        
        #endregion Poll Related

        #region Survey Related
        [XmlRpcMethod("surveyCreate")]
        string surveyCreate(string token, SurveyStructure surveyData);

        [XmlRpcMethod("surveyQuestionCreate")]
        string surveyQuestionCreate(string token,string SurveyID, SurveyQuestionStructure surveyquestion);

        [XmlRpcMethod("surveyDelete")]
        string surveyDelete(string token, string SurveyID);

        [XmlRpcMethod("surveyUpdate")]
        string surveyUpdate(string token, string SurveyID, SurveyStructure survey);

        [XmlRpcMethod("surveyQuestionUpdate")]
        string surveyQuestionUpdate(string token, string SurveyID, SurveyQuestionStructure surveyquestion);

        [XmlRpcMethod("surveyQuestionDelete")]
        string surveyQuestionDelete(string token, string SurveyID, string QuestionID);

        [XmlRpcMethod("surveyColorUpdate")]
        string surveyColorUpdate(string token, string SurveyID, SurveyColorStructure surveyColor);

        [XmlRpcMethod("surveyGetList")]
        SurveyStructure[] surveyGetList(string token, string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("surveyStatusUpdate")]
        int surveyStatusUpdate(string token, string SurveyID, string Status);

        [XmlRpcMethod("surveyGetQuestionList")]
        SurveyQuestionStructure[] surveyGetQuestionList(string token, string SurveyID);

        [XmlRpcMethod("surveyReportList")]
        ReportSurveyStructure[] surveyReportList(string token, string filter, string status, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("surveyResponseReport")]
        SurveyQuestionStructure[] surveyResponseReport(string token, string SurveyID);

        [XmlRpcMethod("surveyTemplateGetList")]
        SurveyTemplateStructure[] surveyTemplateGetList(string token);

        [XmlRpcMethod("surveyCopy")]
        string surveyCopy(string token, string SurveyID, string NewSurveyName);

        [XmlRpcMethod("surveyCopyTemplate")]
        string surveyCopyTemplate(string token, string TemplateID, string NewSurveyName);

        [XmlRpcMethod("surveyGetColor")]
        SurveyColorStructure surveyGetColor(string token, string SurveyID);

        #endregion Survey Related

        #region Report Related

        [XmlRpcMethod("reportGet")]
        EmailStructure[] reportGet(string token, string filter, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetBounces")]
        ReportBounceStructure[] reportGetBounces(string token, string emailID, int pageNumber, int pageSize,string Filter, string orderBy,string sortOrder);

        [XmlRpcMethod("reportGetClicks")]
        ReportClickStructure[] reportGetClicks(string token, string emailID);

        [XmlRpcMethod("reportGetClickEmails")]
        ReportDataStructure[] reportGetClickEmails(string token, string emailID,string clickUrl, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetForwards")]
        ReportDataStructure[] reportGetForwards(string token, string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetHardBounces")]
        ReportBounceStructure[] reportGetHardBounces(string token, string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetSoftBounces")]
        ReportBounceStructure[] reportGetSoftBounces(string token, string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetOpens")]
        ReportDataStructure[] reportGetOpens(string token, string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetUnopens")]
        ReportDataStructure[] reportGetUnopens(string token, string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetUnsubscribes")]
        ReportDataStructure[] reportGetUnsubscribes(string token, string emailID, int pageNumber, int pageSize, string orderBy, string sortOrder);

        [XmlRpcMethod("reportGetSummary")]
        ReportSummaryStructure reportGetSummary(string token, string emailID);

        [XmlRpcMethod("reportCompare")]
        ReportSummaryStructure[] reportCompare(string token, string emailIDs);


        [XmlRpcMethod("reportGetOpenCountry")]
        ReportCountryOpenStruct[] reportGetOpenCountry(string token, string emailID);

        [XmlRpcMethod("reportGetOpenForCountry")]
        ReportCountryOpenStruct[] reportGetOpenForCountry(string token, string emailID,string CountryCode);

        [XmlRpcMethod("reportGetCount")]
        double reportGetCount(string token,string filter);
        #endregion Report Related

        #region video Related

        [XmlRpcMethod("videoCreate")]
        Boolean videoCreate(string token, VideoGalleryStructure videoStructure);

        [XmlRpcMethod("videoDelete")]
        string videoDelete(string token, string VideoID);

        [XmlRpcMethod("videoGetList")]
        VideoGalleryStructure[] videoGetList(string token, int pagenumber, int pagesize);

        [XmlRpcMethod("videoGetCount")]
        int videoGetCount(string token);

        [XmlRpcMethod("videoGet")]
        VideoGalleryStructure videoGet(string token, string videoID);
        
        #endregion video Related

        #region SignUp Form Related
        
        [XmlRpcMethod("signupFormCreate")]
        string signupFormCreate(string token, SignupFormDataStructure signupForm);

        [XmlRpcMethod("signupFormUpdateColor")]
        bool signupFormUpdateColor(string token, string signupFormID, SignupFormColorStructure signupForm);

        [XmlRpcMethod("signupFormUpdateMessage")]
        bool signupFormUpdateMessage(string token, string signupFormID, SignupFormDataStructure signupForm);

        [XmlRpcMethod("signupFormDelete")]
        bool signupFormDelete(string token,string signFormID);

        [XmlRpcMethod("signupFormUpdate")]
        bool signupFormUpdate(string token, string signupFormID, SignupFormDataStructure signupForm);

        [XmlRpcMethod("signupFormGet")]
        SignupFormDataStructure signupFormGet(string token, string signFormID);

        [XmlRpcMethod("signupFormGetCode")]
        string signupFormGetCode(string token, string signFormID,string codeType);

        [XmlRpcMethod("listGetSignupForms")]
        SignupFormStructure[] listGetSignupForms(string token, int pageNumber, int pageSize, string orderBy,string sortOrder);


        #endregion SignUp Form Related

         
        
        
    }
}
