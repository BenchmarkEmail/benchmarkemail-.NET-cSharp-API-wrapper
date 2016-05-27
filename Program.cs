using System;
using System.Collections.Generic;
using System.Text;
using CookComputing.XmlRpc;

namespace APIDLLTest
{
    class Program
    {


        public static void login(string username, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(username, password);
            Console.WriteLine("Token " + token);
        }

        public static void tokenAdd(string userName, string password, string token)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            bool allOk = obj.tokenAdd(userName, password, token);
            Console.WriteLine(allOk.ToString());
        }

        public static void tokenDelete(string userName, string password, string token)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            bool allOk = obj.tokenDelete(userName, password, token);
            Console.WriteLine(allOk.ToString());
        }

        public static void tokenGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string[] mytokens = obj.tokenGet(userName, password);

            if (mytokens != null)
            {
                for (int i = 0; i < mytokens.Length; i++)
                {
                    Console.WriteLine(mytokens[i]);
                };
            };

        }

        public static void emailReassignList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;

            BenchmarkEmail.ContactListStructure[] lists = obj.listGet("", 1, 1, "", "");
            BenchmarkEmail.SegmentListStructure[] segments = obj.segmentGet("", 1, 1, "");

            BenchmarkEmail.EmailContactStructure[] emailLists = new BenchmarkEmail.EmailContactStructure[2];
            emailLists[0] = new BenchmarkEmail.EmailContactStructure();
            emailLists[0].emailID = emailid;
            emailLists[0].toListID = lists[0].id;

            emailLists[1] = new BenchmarkEmail.EmailContactStructure();
            emailLists[1].emailID = emailid;
            emailLists[1].toSegmentID = segments[0].id;
            emailLists[1].isSegment = true;

            if (obj.emailReassignList(emailid, emailLists))
            {
                Console.WriteLine("Reassigned lists");
            }
            else
            {
                Console.WriteLine("Error assigning lists");
            }


        }


        public static void emailAssignList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;

            BenchmarkEmail.ContactListStructure[] lists = obj.listGet("", 1, 1, "", "");
            BenchmarkEmail.SegmentListStructure[] segments = obj.segmentGet("", 1, 1, "");

            BenchmarkEmail.EmailContactStructure[] emailLists = new BenchmarkEmail.EmailContactStructure[2];
            emailLists[0] = new BenchmarkEmail.EmailContactStructure();
            emailLists[0].emailID = emailid;
            emailLists[0].toListID = lists[0].id;

            emailLists[1] = new BenchmarkEmail.EmailContactStructure();
            emailLists[1].emailID = emailid;
            emailLists[1].toSegmentID = segments[0].id;
            emailLists[1].isSegment = true;

            if (obj.emailAssignList(emailid, emailLists))
            {
                Console.WriteLine("Assigned lists");
            }
            else
            {
                Console.WriteLine("Error assigning lists");
            }


        }

        public static void emailCopy(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            string newEmailID = obj.emailCopy(emailid);

            Console.WriteLine(newEmailID);




        }
        public static void emailCheckName(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            string emailName = "Welcome";
            int IsNewName = obj.emailCheckName(emailid,emailName);
            Console.WriteLine("New emai name status: "+IsNewName);
            
        }
        public static void emailDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            bool deletedflag = obj.emailDelete(emailid);
            Console.WriteLine(deletedflag.ToString());
        }


        public static void emailGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 10, "", "");

            for (int i = 0; i < EmailStruct.Length; i++)
            {
                Console.WriteLine(EmailStruct[i].sequence + " Email Name" + EmailStruct[i].id);
                Console.WriteLine(" To List: " + EmailStruct[i].toListName + " (" + EmailStruct[i].toListID + ")");
                Console.WriteLine("Subject: " + EmailStruct[i].subject);
                Console.WriteLine("Status: " + EmailStruct[i].status);
                Console.WriteLine("Created Date: " + EmailStruct[i].createdDate);
                Console.WriteLine("Updated Date: " + EmailStruct[i].modifiedDate);
            };

        }
        public static void emailTemplateGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailTemplateStructure[]  EmailTemplateStruct = obj.emailTemplateGetList(1,10);

            for (int i = 0; i < EmailTemplateStruct.Length; i++)
            {
                Console.WriteLine(EmailTemplateStruct[i].sequence + " Template Name" + EmailTemplateStruct[i].template_name);
                Console.WriteLine(" Template Source: " + EmailTemplateStruct[i].template_source + " (" + EmailTemplateStruct[i].preview_small + ")");
                Console.WriteLine("BackGround Image: " + EmailTemplateStruct[i].backgroundImage);
                Console.WriteLine("Content: " + EmailTemplateStruct[i].content);
            };

        }

        public static void emailTemplateGetCount(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            int number = obj.emailTemplateGetCount();
            Console.Write("The number of email Templates found are: " + number);

        }

        public static void emailRssGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailRssGet("", 1, 10, "", "");

            for (int i = 0; i < EmailStruct.Length; i++)
            {
                Console.WriteLine(EmailStruct[i].sequence + " Email Name" + EmailStruct[i].id);
                Console.WriteLine(" To List: " + EmailStruct[i].toListName + " (" + EmailStruct[i].toListID + ")");
                Console.WriteLine("Subject: " + EmailStruct[i].subject);
                Console.WriteLine("Status: " + EmailStruct[i].status);
                Console.WriteLine("Rss Feed Url: " + EmailStruct[i].rssurl);
                Console.WriteLine("Rss Interval: " + EmailStruct[i].rssinterval);
                Console.WriteLine("Rss Active: " + EmailStruct[i].rssactive);
                Console.WriteLine("Created Date: " + EmailStruct[i].createdDate);
                Console.WriteLine("Updated Date: " + EmailStruct[i].modifiedDate);
            };

        }

        public static void emailGetDetail(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            BenchmarkEmail.EmailStructure emailData = obj.emailGetDetail(emailid);

            Console.WriteLine("Email Name " + emailData.emailName);
            Console.WriteLine("Email Version" + emailData.version);

        }

        public static void emailRssGetDetail(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailRssGet("", 1, 10, "", "");
            string emailid = EmailStruct[0].id;

            Console.WriteLine("Email Id " + emailid);

            BenchmarkEmail.EmailStructure emailData = obj.emailRssGetDetail(emailid);

            Console.WriteLine("Email Name: " + emailData.emailName);
            Console.WriteLine("Status: " + emailData.status);
            Console.WriteLine("Rss Feed Url: " + emailData.rssurl);
            Console.WriteLine("Rss Interval: " + emailData.rssinterval);
            Console.WriteLine("Rss Active: " + emailData.rssactive);
            Console.WriteLine("Created Date: " + emailData.createdDate);
            Console.WriteLine("Updated Date: " + emailData.modifiedDate);

        }




        public static void emailCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;
            listID = " 385176";
            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 100, "");
            string SegmentID = segmentList[0].id;

            BenchmarkEmail.EmailStructure emailDetail = new BenchmarkEmail.EmailStructure();
            emailDetail.fromEmail = "user1@yahoo.com";
            emailDetail.fromName = "Steve";
            emailDetail.emailName = "Sales May12 2018";
            emailDetail.replyEmail = "feedback@yahoo.com";
            emailDetail.subject = "New Products launch at our store at Cyphercity ";
            emailDetail.templateContent = "<html><body> Hello World </body></html>";
            emailDetail.toListID = System.Convert.ToInt32(listID);
            //emailDetail.isSegment = true;
            //emailDetail.toListID = System.Convert.ToInt32(SegmentID);
            emailDetail.scheduleDate = "1 May 2010 5:00"; /* In UTC */
            emailDetail.webpageVersion = true;
            emailDetail.permissionReminderMessage = "You are receiving this email because of your relationship with our company. Unsubscribe is available at the bottom of this email.";

            string newEmailID = obj.emailCreate(emailDetail);

            Console.WriteLine(newEmailID);

        }

        public static void emailRssCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;

            BenchmarkEmail.EmailStructure emailDetail = new BenchmarkEmail.EmailStructure();
            emailDetail.fromEmail = "user1@____.com";
            emailDetail.fromName = "Steve";
            emailDetail.emailName = "Sales Promo OK Ok OK 14";
            emailDetail.replyEmail = "feedback@____.com";
            emailDetail.subject = "New Products launch at our store 1";
            emailDetail.templateContent = "<table style='' name='block_TITLE' border='0' cellpadding='10' cellspacing='0' width='100%'> <tbody><tr> <td align='left' valign='middle' width='100%'> <div style='font-family: Georgia,'Times New Roman',Times,serif; font-size: 40px; color: rgb(255, 255, 255);'>[RSS:TITLE]</div> </td> </tr> </tbody></table>";
            emailDetail.toListID = System.Convert.ToInt32(listID);
            emailDetail.scheduleDate = "1 May 2010 5:00"; /* In UTC */
            emailDetail.webpageVersion = true;
            emailDetail.permissionReminderMessage = "You are receiving this email because of your relationship with our company. Unsubscribe is available at the bottom of this email.";
            emailDetail.rssinterval = "7";
            emailDetail.rssurl = "http://justmarketing.wordpress.com/feed/";
            string newEmailID = obj.emailRssCreate(emailDetail);

            Console.WriteLine(newEmailID);

        }




        public static void emailSchedule(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;

            bool allok = obj.emailSchedule(emailid, "14 Jul 2020 12:00");

            Console.WriteLine(allok);
        }

        public static void emailRssSchedule(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailRssGet("", 1, 1, "", "");
            string emailid = EmailStruct[0].id;

            bool allok = obj.emailRssSchedule(emailid, "14 SEP 2020 12:00", "30");

            Console.WriteLine(allok);
        }




        public static void emailSendNow(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            emailid = "851184";
            bool allok = obj.emailSendNow(emailid);

            Console.WriteLine(allok);
        }

        public static void emailSendTest(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            string testEmailAddress = "yourname@sitedomain.com";

            bool allok = obj.emailSendTest(emailid, testEmailAddress);

            Console.WriteLine(allok);
        }

        public static void emailUnSchedule(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;

            bool allok = obj.emailUnSchedule(emailid);

            Console.WriteLine(allok);
        }

        public static void emailUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;
            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailGet("", "", 1, 1, "", "");
            string emailid = EmailStruct[0].id;
            BenchmarkEmail.EmailStructure emailDetail = new BenchmarkEmail.EmailStructure();
            emailDetail.id = emailid;
            emailDetail.fromEmail = "user1@sitedomain.com";
            emailDetail.fromName = "Steve";
            emailDetail.emailName = "Sales Promo May 10";
            emailDetail.replyEmail = "feedback@sitedomain.com";
            emailDetail.subject = "New Products launch at our store";
            emailDetail.templateContent = "<html><body> Hello World </body></html>";
            emailDetail.toListID = System.Convert.ToInt32(listID);
            emailDetail.permissionReminderMessage = "You are receiving this email because of your relationship with our company. Unsubscribe is available at the bottom of this email.";

            bool allok = obj.emailUpdate(emailDetail);

            Console.WriteLine(allok);

        }

        public static void emailResend(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string EmailID = "XXXXXXX"; // fill in the correct numerical value of the email campaign
            string flg = obj.emailResend(EmailID, "28 SEP 2010 5:00");
            Console.WriteLine(flg);

        }

        public static void emailQuickSend(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string EmailID = "XXXXXXX"; // fill in the correct numerical value of the email campaign
            BenchmarkEmail.EmailAddressStructure[] contacts = new BenchmarkEmail.EmailAddressStructure[2];
            contacts[0].email = "testcontact1@benchmarkemail.com";
            contacts[1].email = "testcontact2@benchmarkemail.com";
            string ListName = "My List for checking these features";
            string flg = obj.emailQuickSend(EmailID, ListName, contacts, "29 SEP 2010 5:00");
            Console.WriteLine(flg);
        }

        public static void emailPreview(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.EmailStructure[] emailList = obj.emailGet("", "", 1, 1, "", "");
            string emailID = emailList[0].id;
            string HtmlContent = "<html><body>hello</body></html>";
            string TextContent = "Buy our product and get Profit";
            string emailAddress = "";
            BenchmarkEmail.EmailStructure email = obj.emailPreview(emailID, emailAddress, HtmlContent, TextContent);
            Console.WriteLine(email.sequence + ")" + email.emailName);
            Console.WriteLine("From:-" + email.fromEmail);
            Console.WriteLine("From Name:-" + email.fromName);
            Console.WriteLine("Template:-" + email.templateContent);
        }

        public static void emailPreviewTest(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.EmailStructure[] emailList = obj.emailGet("", "", 1, 1, "", "");
            string emailID = emailList[0].id;
            string HtmlContent = "<html><body>hello</body></html>";
            string TextContent = "Buy our product and get Profit";
            string emailAddress = "antriksh@cybermaxsolutions.com";
            string PersonalMessage = "Hi! Are you want Profit";
            string retVal = obj.emailPreviewTest(emailID, emailAddress, HtmlContent, TextContent, PersonalMessage);
            Console.WriteLine("The email sent to " + retVal);

        }


        public static void autoresponderGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.AutoresponderStructure[] AutoresponderList = obj.autoresponderGetList(1, 100, "", "", "");

            for (int i = 0; i < AutoresponderList.Length; i++)
            {
                Console.WriteLine(AutoresponderList[i].sequence + " Autoresponder ID (" + AutoresponderList[i].id + " )");
                Console.WriteLine("Autoresponder Name: " + AutoresponderList[i].autoresponderName);
                Console.WriteLine("Status: " + AutoresponderList[i].status);
                Console.WriteLine("Total Emails: " + AutoresponderList[i].totalEmails);
                Console.WriteLine("Updated Date: " + AutoresponderList[i].modifiedDate);
            };


        }

        public static void autoresponderCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.AutoResponderDataStructure Autoresponder = new BenchmarkEmail.AutoResponderDataStructure();
            Autoresponder.autoresponderName = "My Autoresponder created via API";
            Autoresponder.contactListID = "2676";
            Autoresponder.fromEmail = "user1@userdomain.com";
            Autoresponder.fromName = "John Smith";
            Autoresponder.isSegment = false;
            Autoresponder.webpageVersion = true;
            Autoresponder.permissionReminder = true;
            Autoresponder.permissionReminderMessage = "Please click here to confirm, <a target=_new style='color:#0000ff;' href='CONFIRMURL'>Confirm my subscription</a> .";
            string AutoresponderID = obj.autoresponderCreate(Autoresponder);
            Console.WriteLine("Autoresponder ID " + AutoresponderID);
        }

        public static void autoresponderUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.AutoResponderDataStructure Autoresponder = new BenchmarkEmail.AutoResponderDataStructure();
            string AutoResponderID = "137";
            Autoresponder.autoresponderName = "My Autoresponder created via API - osaka bills";
            Autoresponder.fromEmail = "user1@userdomain.com";
            Autoresponder.fromName = "John Smith";
            Autoresponder.webpageVersion = true;
            Autoresponder.permissionReminder = true;
            Autoresponder.permissionReminderMessage = "Please click here to confirm, <a target=_new style='color:#0000ff;' href='CONFIRMURL'>Confirm my subscription</a> .";
            int status = 1; // status can be 1 or 0 
            bool updatestatus = obj.autoresponderUpdate(AutoResponderID, status, Autoresponder);
            Console.WriteLine("Autoresponder update " + updatestatus.ToString());
        }

        public static void autoresponderDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string AutoResponderID = "129";
            bool deletestatus = obj.autoresponderDelete(AutoResponderID);
            Console.WriteLine("Autoresponder deleted status " + deletestatus.ToString());
        }


        public static void autoresponderDetailDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string AutoResponderID = "139";
            string AutoResponderDetailID = "275";
            bool deletestatus = obj.autoresponderDetailDelete(AutoResponderID, AutoResponderDetailID);
            Console.WriteLine("Autoresponder detail deleted status " + deletestatus.ToString());
        }

        public static void autoresponderDetailHistoryDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string AutoResponderID = "103";
            string AutoResponderDetailID = "125";
            string email = "krylor@gmail.com";
            bool deletestatus = obj.autoresponderDetailHistoryDelete(AutoResponderID, AutoResponderDetailID, email);
            Console.WriteLine("Autoresponder detail history deleted status " + deletestatus.ToString());
        }

        public static void autoresponderGetEmailDetail(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string AutoResponderID = "137";
            string AutoResponderDetailID = "264";

            BenchmarkEmail.EmailStructure emailData = obj.autoresponderGetEmailDetail(AutoResponderID, AutoResponderDetailID);

            Console.WriteLine("Email Name " + emailData.emailName);
            Console.WriteLine("Email ID   " + emailData.id);


        }

        public static void autoresponderGetDetail(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string AutoResponderID = "137";
            BenchmarkEmail.AutoResponderDetailedStructure AutoResponderDetailed = obj.autoresponderGetDetail(AutoResponderID);
            Console.WriteLine("Autoresponder Name: " + AutoResponderDetailed.autoresponderName);
            Console.WriteLine("Autoresponder List Name: " + AutoResponderDetailed.contactListName);
            Console.WriteLine("Autoresponder List ID: " + AutoResponderDetailed.contactListID);
            Console.WriteLine("Autoresponder CreatedDate: " + AutoResponderDetailed.createdDate);
            Console.WriteLine("Autoresponder ModifiedDate: " + AutoResponderDetailed.modifiedDate);
            Console.WriteLine("Autoresponder Permission Message: " + AutoResponderDetailed.permissionReminderMessage);
            Console.WriteLine("Autoresponder Web version: " + AutoResponderDetailed.webpageVersion.ToString());
            Console.WriteLine("Autoresponder Levels: " + AutoResponderDetailed.emails.Length);

            if (AutoResponderDetailed.emails.Length > 0)
            {
                for (int i = 0; i < AutoResponderDetailed.emails.Length; i++)
                {
                    Console.WriteLine("Autoresponder Detail ID: " + AutoResponderDetailed.emails[i].autoresponderDetailID);
                    Console.WriteLine("Autoresponder Subject: " + AutoResponderDetailed.emails[i].subject);
                    Console.WriteLine("Autoresponder Days: " + AutoResponderDetailed.emails[i].days);
                    Console.WriteLine("Autoresponder Type: " + AutoResponderDetailed.emails[i].type);
                    Console.WriteLine("Autoresponder When to Send: " + AutoResponderDetailed.emails[i].whentosend);
                    Console.WriteLine("Autoresponder Field to compare: " + AutoResponderDetailed.emails[i].fieldtocompare);

                };
            }



        }

        public static void autoresponderDetailCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.AutoResponderDetailDataStructure AutoresponderDetail = new BenchmarkEmail.AutoResponderDetailDataStructure();
            string AutoresponderID = "4612";
            AutoresponderDetail.templateText = "This is new text thread";
            AutoresponderDetail.templateContent = "<b>This is the new HTML thread</b>";
            AutoresponderDetail.subject = "Autoresponder subject 1 is to 1";
            AutoresponderDetail.us_address = "Some random US address";
            AutoresponderDetail.us_city = "Tampa bay";
            AutoresponderDetail.us_state = "Florida";
            AutoresponderDetail.us_zip = "70212012";
            AutoresponderDetail.intl_address = "";
            AutoresponderDetail.whentosend = "after"; // valid values are "after" , "before", ignore if your email is of the type "new subscriber email"
            AutoresponderDetail.days = "36";
            AutoresponderDetail.fieldtocompare = "Bday";// ignore if your email is of the type "new subscriber email"
            AutoresponderDetail.type = "one off email"; // valid values are "one off email" , "annual email" , "new subscriber email"
            string id = obj.autoresponderDetailCreate(AutoresponderID, AutoresponderDetail);
            Console.WriteLine("Autoresponder Detail ID = " + id);
        }


        public static void emailRssUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;

            BenchmarkEmail.EmailStructure[] EmailStruct = obj.emailRssGet("", 1, 1, "", "");
            string emailid = EmailStruct[0].id;

            BenchmarkEmail.EmailStructure emailDetail = new BenchmarkEmail.EmailStructure();
            emailDetail.id = emailid;
            emailDetail.fromEmail = "user1@userdomain.com";
            emailDetail.fromName = "Steve";
            emailDetail.emailName = "Sales Promo May 29";
            emailDetail.replyEmail = "feedback@userdomain.com";
            emailDetail.subject = "New Products launch at our store";
            emailDetail.templateContent = "<table style='' name='block_TITLE' border='0' cellpadding='10' cellspacing='0' width='100%'> <tbody><tr> <td align='left' valign='middle' width='100%'> <div style='font-family: Georgia,'Times New Roman',Times,serif; font-size: 40px; color: rgb(255, 255, 255);'>[RSS:TITLE]</div> </td> </tr> </tbody></table>";
            emailDetail.toListID = System.Convert.ToInt32(listID);
            emailDetail.permissionReminderMessage = "You are receiving this email because of your relationship with our company. Unsubscribe is available at the bottom of this email.";
            emailDetail.scheduleDate = "3 SEP 2010 5:00"; /* In UTC */
            emailDetail.rssinterval = "7";
            emailDetail.rssurl = "http://benchmarkemail.wordpress.com/feed/";

            bool allok = obj.emailRssUpdate(emailDetail);

            Console.WriteLine(allok);

        }

        public static string batchGetStatus(string userName, string password, string listID, string batchID)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string status = obj.batchGetStatus(listID, batchID);
            Console.WriteLine(status);
            return status;
        }

        public static string batchAddContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string batchID = "";
            obj.CurrentToken = token;
            int i;
            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 20, "", "");
            string listID = contactList[3].id;
            XmlRpcStruct[] xml = new XmlRpcStruct[1];
            List<XmlRpcStruct> xmlnew = new List<XmlRpcStruct>();
            XmlRpcStruct entrynew = new XmlRpcStruct();
            for (i = 0; i < 200; i++)
            {
                entrynew = new XmlRpcStruct();
                entrynew["email"] = "new" + i.ToString() + "@yourdomain.com";
                entrynew["Firstname"] = "name" + i.ToString();
                entrynew["LastName"] = "lastname" + i.ToString() ;
                entrynew["Extra 5"] = "some data " + i.ToString();
                xmlnew.Add(entrynew);
            }
            xml = xmlnew.ToArray();
            try
            {
                batchID = obj.batchAddContacts(listID, xml);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("exception found " + ex.Message.ToString());
            }
            Console.WriteLine(batchID + " batch created " + contactList[0].listname);
            /*
            if (!String.IsNullOrEmpty(batchID))
            {
                for (int i1 = 0; i1 < 10; i1++)
                {
                    status = obj.batchGetStatus(listID, batchID);
                    Console.WriteLine("Status " + status + " " + DateTime.Now.ToString("HH:MM:ss"));
                    System.Threading.Thread.Sleep(10000);
                }
            }
            */
            return batchID;

        }




        public static void listAddContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 20, "", "");
            string listID = contactList[8].id;

            BenchmarkEmail.ContactStructure[] contact = obj.listGetContacts(listID, "", 1, 2, "", "");

            string contactEmail = contact[0].email;

            Console.WriteLine(" contactEmail " + contactEmail);

            System.Collections.Hashtable contactDetail = new System.Collections.Hashtable();

            contactDetail = obj.listGetContactDetails(listID, contactEmail);

            string contactID = contactDetail["id"].ToString();

            Console.WriteLine(" contactID " + contactID);

            XmlRpcStruct[] xml = new XmlRpcStruct[2];
            System.Collections.IEnumerator en = contactDetail.Keys.GetEnumerator();
            xml[0] = new XmlRpcStruct();

            while (en.MoveNext())
            {
                if (en.Current.ToString() == "email")
                {
                    xml[0].Add(en.Current.ToString().ToLower(), "usr5@userdomain.com");
                }
                else
                {
                    xml[0].Add(en.Current.ToString().ToLower(), contactDetail[en.Current]);
                }
            };

            xml[0]["Company name"] = "ACME";
            xml[0]["Firstname"] = "Clark";
            xml[0]["Lastname"] = "Kent";

            contactEmail = contact[1].email;

            Console.WriteLine(" contactEmail " + contactEmail);

            contactDetail = obj.listGetContactDetails(listID, contactEmail);

            contactID = contactDetail["id"].ToString();

            Console.WriteLine(" contactID " + contactID);
            en = contactDetail.Keys.GetEnumerator();
            xml[1] = new XmlRpcStruct();
            while (en.MoveNext())
            {
                if (en.Current.ToString() == "email")
                {
                    xml[1].Add(en.Current.ToString().ToLower(), "usr6@userdomain2.com");
                }
                else
                {
                    xml[1].Add(en.Current.ToString().ToLower(), contactDetail[en.Current]);
                }
            };

            xml[1]["Company Name"] = "ACME1";
            xml[1]["Firstname"] = "Bruce";
            xml[1]["LastName"] = "Wayne";

            int added = obj.listAddContacts(listID, xml);

            Console.WriteLine(added.ToString() + " records added");


        }

        public static void listAddContactsOptin(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;

            BenchmarkEmail.ContactStructure[] record1 = new BenchmarkEmail.ContactStructure[2];

            BenchmarkEmail.ContactStructure ContactData = new BenchmarkEmail.ContactStructure();
            ContactData.email = "user1@userdomain.com";
            ContactData.firstname = "Peter";
            ContactData.lastname = "Parker";

            record1[0] = ContactData;

            ContactData.email = "user2@userdomain2.com";
            ContactData.firstname = "Bruce";
            ContactData.lastname = "Wayne";

            record1[1] = ContactData;

            int added = obj.listAddContactsOptin(listID, record1, "1");

            Console.WriteLine(added.ToString() + " records added");


        }



        public static void listCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            string listID = obj.listCreate("BME Tech Support Testing List");

            Console.WriteLine("List added " + listID);
        }

        public static void listDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;

            bool allok = obj.listDelete(listID);

            Console.WriteLine(allok);
        }

        public static void listSearchContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ContactListStructure[] contactList = obj.listSearchContacts("info@mark.com");


            for (int i = 0; i < contactList.Length; i++)
            {
                Console.WriteLine("Sequence: " + contactList[i].sequence);
                Console.WriteLine("ListID: " + contactList[i].id + " List Name (" + contactList[i].listname + " )");
                
            };

        }
        

        public static void listGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 100, "", "");


            for (int i = 0; i < contactList.Length; i++)
            {
                Console.WriteLine(contactList[i].sequence + " List Name (" + contactList[i].id + " )");
                Console.WriteLine("Contacts: " + contactList[i].contactcount);
                Console.WriteLine("Created Date: " + contactList[i].createdDate);
                Console.WriteLine("Updated Date: " + contactList[i].modifiedDate);
            };

        }

        public static void listGetContactsAllFields(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            System.Collections.Hashtable[] ht = new System.Collections.Hashtable[100];
            string listID = contactList[0].id;
            ht = obj.listGetContactsAllFields(listID, "", 1, 100, "", "");
            for (int i = 0; i < ht.Length; i++)
            {
                Console.WriteLine(i + " Contact");
                System.Collections.IEnumerator en = ht[i].Keys.GetEnumerator();
                while (en.MoveNext())
                {
                    Console.WriteLine("Key: " + en.Current.ToString() + "  Value: " + ht[i][en.Current].ToString());
                };
                Console.WriteLine("\n");
            }

            //for (int i = 0; i < contact.Length; i++)
            //{
            //    Console.WriteLine(contact[i].sequence + " Email: " + contact[i].email + "  (" + contact[i].id + " )");
            //    Console.WriteLine("Name " + contact[i].firstname + " " + contact[i].middlename + " " + contact[i].lastname);
            //};


        }


        public static void listGetContactDetails(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 100, "", "");

            string listID = contactList[0].id;

            BenchmarkEmail.ContactStructure[] contact = obj.listGetContacts(listID, "", 1, 1, "", "");
            string contactEmail = contact[0].email;

            System.Collections.Hashtable ht = new System.Collections.Hashtable();

            ht = obj.listGetContactDetails(listID, contactEmail);

            System.Collections.IEnumerator en = ht.Keys.GetEnumerator();
            while (en.MoveNext())
            {
                Console.WriteLine("Key: " + en.Current.ToString() + "  Value: " + ht[en.Current].ToString());
            };


        }


        public static void listGetContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");

            string listID = contactList[0].id;

            BenchmarkEmail.ContactStructure[] contact = obj.listGetContacts(listID, "", 1, 100, "", "");

            for (int i = 0; i < contact.Length; i++)
            {
                Console.WriteLine(contact[i].sequence + " Email: " + contact[i].email + "  (" + contact[i].id + " )");
                Console.WriteLine("Name " + contact[i].firstname + " " + contact[i].middlename + " " + contact[i].lastname);
            };


        }

        public static void listGetContactsByType(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");

            string listID = contactList[0].id;
            //Type may be one of following(Optin,NotOptedIn,ConfirmedBounces,Active,Unsubscribe)
            string Type = "ConfirmedBounces";
            BenchmarkEmail.ContactStructure[] contact = obj.listGetContactsByType(listID, "", 1, 100, "", "", Type);

            for (int i = 0; i < contact.Length; i++)
            {
                Console.WriteLine(contact[i].sequence + " Email: " + contact[i].email + "  (" + contact[i].id + " )");
                Console.WriteLine("Name " + contact[i].firstname + " " + contact[i].middlename + " " + contact[i].lastname);
            };


        }


        public static void listUnsubscribeContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");

            string listID = contactList[0].id;
            string[] rec = new string[2];
            rec[0] = "user1@___.com";
            rec[1] = "user2@___.com";

            int active = obj.listUnsubscribeContacts(listID, rec);

            Console.WriteLine(active.ToString() + " active records in the list ");

        }

        public static void listDeleteContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");

            string listID = contactList[0].id;
            string contacts = "";

            BenchmarkEmail.ContactStructure[] contact = obj.listGetContacts(listID, "", 1, 5, "", "");
            for (int i = 0; i < contact.Length; i++)
            {
                if (contacts.Length > 0) { contacts = contacts + ","; }
                contacts = contacts + contact[i].id;
            }

            bool deleted = obj.listDeleteContacts(listID, contacts);

            if (deleted)
            {
                Console.WriteLine(" records deleted successfully");
            }
            else
            {
                Console.WriteLine(" error deleting records");
            }

        }

        public static void listDeleteEmailContact(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");

            string listID = contactList[0].id;
            string email = "test@invaliddomain.moc";


            bool deleted = obj.listDeleteEmailContact(listID, email);

            if (deleted)
            {
                Console.WriteLine(" record deleted successfully");
            }
            else
            {
                Console.WriteLine(" error deleting record");
            }

        }




        public static void listUpdateContactDetails(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 20, "", "");

            string listID = contactList[8].id;

            BenchmarkEmail.ContactStructure[] contact = obj.listGetContacts(listID, "", 1, 1, "", "");

            string contactEmail = contact[0].email;

            Console.WriteLine(" contactEmail " + contactEmail);

            System.Collections.Hashtable contactDetail = new System.Collections.Hashtable();

            contactDetail = obj.listGetContactDetails(listID, contactEmail);

            string contactID = contactDetail["id"].ToString();

            Console.WriteLine(" contactID " + contactID);

            XmlRpcStruct xml = new XmlRpcStruct();
            System.Collections.IEnumerator en = contactDetail.Keys.GetEnumerator();

            while (en.MoveNext())
            {
                xml.Add(en.Current, contactDetail[en.Current]);
            };

            xml["Company Name"] = "ACME";
            xml["FirstName"] = "Clark";
            xml["LastName"] = "Kent";

            XmlRpcStruct xmlout = obj.listUpdateContactDetails(listID, contactID, xml);

            en = xmlout.Keys.GetEnumerator();

            while (en.MoveNext())
            {
                Console.WriteLine("Key: " + en.Current.ToString() + "  Value: " + xmlout[en.Current].ToString());
            };

        }

        
        public static void segmentCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;

            BenchmarkEmail.SegmentStructure segment = new BenchmarkEmail.SegmentStructure();
            segment.description = "API Tested Segment";
            segment.listid = listID;
            segment.segmentname = "API Segment";

            string segmentID = obj.segmentCreate(segment);

            Console.WriteLine("Segment added " + segmentID);
        }

        public static void segmentCreateCriteria(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 1, "");
            string segmentID = segmentList[0].id;


            BenchmarkEmail.SegmentCriteriaStructure criteria = new BenchmarkEmail.SegmentCriteriaStructure();
            criteria.field = "subscribed date";
            criteria.filterType = "after";
            criteria.startDate = "15 01 2010";
            string criteriaID = obj.segmentCreateCriteria(segmentID, criteria);
            Console.WriteLine("Criteria added " + criteriaID);


            criteria = new BenchmarkEmail.SegmentCriteriaStructure();
            criteria.field = "email";
            criteria.filterType = "contains";
            criteria.filter = "hotmail";
            criteriaID = obj.segmentCreateCriteria(segmentID, criteria);
            Console.WriteLine("Criteria added " + segmentID);

        }

        public static void segmentDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 1, "");
            string segmentID = segmentList[0].id;
            if (obj.segmentDelete(segmentID))
            {
                Console.WriteLine("Segment Deleted");
            }
            else
            {
                Console.WriteLine("Error deleting segment");
            }
        }


        public static void segmentDeleteCriteria(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 1, "");
            string segmentID = segmentList[0].id;

            BenchmarkEmail.SegmentCriteriaStructure[] criteriaList = obj.segmentGetCriteriaList(segmentID);
            string criteriaID = criteriaList[0].id;

            obj.segmentDeleteCriteria(segmentID, criteriaID);
            Console.WriteLine("Segment Deleted");

        }

        public static void segmentGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 100, "");

            for (int i = 0; i < segmentList.Length; i++)
            {
                Console.WriteLine(segmentList[i].sequence + " " + segmentList[i].segmentname + "  (" + segmentList[i].id + " )");
                Console.WriteLine("Based on List: " + segmentList[i].listname + " (" + segmentList[i].listid + ")");
                Console.WriteLine("Contacts: " + segmentList[i].contactcount);
                Console.WriteLine("Created Date: " + segmentList[i].createdDate);
                Console.WriteLine("Updated Date: " + segmentList[i].modifiedDate);
            };
        }

        public static void segmentGetContacts(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 100, "");

            string segmentID = segmentList[0].id;

            BenchmarkEmail.ContactStructure[] contact = obj.segmentGetContacts(segmentID, "", 1, 100, "", "");

            for (int i = 0; i < contact.Length; i++)
            {
                Console.WriteLine(contact[i].sequence + " Email: " + contact[i].email + "  (" + contact[i].id + " )");
                Console.WriteLine("Name " + contact[i].firstname + " " + contact[i].middlename + " " + contact[i].lastname);
            }
        }

        public static void segmentGetCount(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 100, "");

            string segmentID = segmentList[0].id;

            Console.WriteLine(obj.segmentGetCount("").ToString() + " segments found in your account");

        }

        public static void segmentGetCriteriaList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 100, "");
            string segmentID = segmentList[0].id;

            BenchmarkEmail.SegmentCriteriaStructure[] criteriaList = obj.segmentGetCriteriaList(segmentID);
            for (int i = 0; i < criteriaList.Length; i++)
            {
                Console.WriteLine();
                Console.Write(criteriaList[i].sequence + " " + criteriaList[i].field + "  (" + criteriaList[i].id + " )");
                Console.Write(" " + criteriaList[i].filterType);
                if (criteriaList[i].field.ToLower() == "subscribed date")
                {
                    Console.Write(criteriaList[i].startDate);
                    if (!String.IsNullOrEmpty(criteriaList[i].endDate))
                    {
                        Console.Write(" " + criteriaList[i].endDate);
                    }
                }
                else
                {
                    Console.Write(criteriaList[i].filter);
                }
            }
        }

        public static void segmentGetDetail(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SegmentListStructure[] segmentList = obj.segmentGet("", 1, 100, "");

            string segmentID = segmentList[0].id;
            BenchmarkEmail.SegmentStructure segmentDetail = obj.segmentGetDetail(segmentID);

            Console.WriteLine(segmentDetail.segmentname + " ( " + segmentDetail.id + ")");
            Console.WriteLine(segmentDetail.description);
            Console.WriteLine("Based on " + segmentDetail.listname + " (" + segmentDetail.listid + ") ");

        }


        public static void listAddContactsForm(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.SignupFormStructure[] contactList = obj.listGetSignupForms(1, 1, "","0");

            string signupFormID = contactList[0].id;
            BenchmarkEmail.SignupFormContactStructure record1 = new BenchmarkEmail.SignupFormContactStructure();
            record1.email = "user1@Usrdomain.com";
            record1.firstname = "Peter";
            record1.lastname = "Parker";
            int added = obj.listAddContactsForm(signupFormID, record1);
            Console.WriteLine(added.ToString() + " Contacts added ");

        }





        public static void reportGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 100, "", "");

            for (int i = 0; i < campaignList.Length; i++)
            {
                Console.WriteLine(campaignList[i].sequence + " Campaign: " + campaignList[i].emailName + "  (" + campaignList[i].id + " )");
                Console.WriteLine("Status: " + campaignList[i].status + " Delivery Date: " + campaignList[i].scheduleDate);
                Console.WriteLine("Target List ID: " + campaignList[i].toListID + " Target List Name: " + campaignList[i].toListName);
            };

        }

        public static void reportGetBounces(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");


            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportBounceStructure[] bounceList = obj.reportGetBounces(campaignID, 1, 100, "", "", "");

            for (int i = 0; i < bounceList.Length; i++)
            {
                Console.WriteLine(bounceList[i].sequence + " Email: " + bounceList[i].email);
                Console.WriteLine("Name: " + bounceList[i].name);
                Console.WriteLine("Bounce Type: " + bounceList[i].type);
            };
        }

        public static void reportGetClicks(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportClickStructure[] List = obj.reportGetClicks(campaignID);

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " URL: " + List[i].URL);
                Console.WriteLine("Clicks: " + List[i].clicks);
                Console.WriteLine("Percent: " + List[i].percent);
            };
        }

        public static void reportGetClickEmails(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            string clickUrl = "";
            BenchmarkEmail.ReportDataStructure[] List = obj.reportGetClickEmails(campaignID, clickUrl, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);
                Console.WriteLine("Name: " + List[i].name);
                Console.WriteLine("LogDate: " + List[i].logdate);
            };
        }

        public static void reportGetForwards(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportDataStructure[] List = obj.reportGetForwards(campaignID, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);
                Console.WriteLine("Name: " + List[i].name);
                Console.WriteLine("LogDate: " + List[i].logdate);
            };
        }

        public static void reportGetHardBounces(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportBounceStructure[] List = obj.reportGetHardBounces(campaignID, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);
                Console.WriteLine("Name: " + List[i].name);
                Console.WriteLine("Bounce Type:" + List[i].type);
            };
        }

        public static void reportGetSoftBounces(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportBounceStructure[] List = obj.reportGetSoftBounces(campaignID, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);
                Console.WriteLine("Name: " + List[i].name);
                Console.WriteLine("Bounce Type:" + List[i].type);
            };
        }

        public static void reportGetUnopens(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportDataStructure[] List = obj.reportGetUnopens(campaignID, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);

            };
        }


        public static void reportGetOpens(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportDataStructure[] List = obj.reportGetOpens(campaignID, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);
                Console.WriteLine("Name: " + List[i].name);
                Console.WriteLine("LogDate: " + List[i].logdate);
            };
        }

        public static void reportGetUnsubscribes(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string campaignID = campaignList[0].id;
            BenchmarkEmail.ReportDataStructure[] List = obj.reportGetUnsubscribes(campaignID, 1, 10, "", "");

            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Email: " + List[i].email);
                Console.WriteLine("Name: " + List[i].name);
                Console.WriteLine("LogDate: " + List[i].logdate);
            };
        }


        public static void reportCompare(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 10, "", "");

            string campaignID = campaignList[0].id.ToString() + "," + campaignList[1].id.ToString() + "," + campaignList[2].id.ToString() + "," + campaignList[3].id.ToString();
            BenchmarkEmail.ReportSummaryStructure[] Lists = obj.reportCompare(campaignID);
            for (int i = 0, l = Lists.Length; i < l; i++)
            {
                BenchmarkEmail.ReportSummaryStructure List = Lists[i];
                Console.WriteLine(" Campaign: " + List.emailName + "(" + List.id + ") ");
                Console.WriteLine(" Date: " + List.scheduleDate);
                Console.WriteLine(" Total Sent: " + List.mailSent);
                Console.WriteLine(" Opens: " + List.opens);
                Console.WriteLine(" Bounces: " + List.bounces);
                Console.WriteLine(" Unsubscribes: " + List.unsubscribes);
                Console.WriteLine(" Clicks: " + List.clicks);
                Console.WriteLine(" Forwards: " + List.forwards);
                Console.WriteLine(" Abuse Complaint: " + List.abuseReports);

            }

        }

        public static void reportGetSummary(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 2, "", "");

            string campaignID = campaignList[0].id.ToString();

            BenchmarkEmail.ReportSummaryStructure List = obj.reportGetSummary(campaignID);

            Console.WriteLine(" Campaign: " + List.emailName + "(" + List.id + ") ");
            Console.WriteLine(" To: " + List.toListName + "(" + List.toListID + ") ");
            Console.WriteLine(" Date: " + List.scheduleDate);
            Console.WriteLine(" Total Sent: " + List.mailSent);
            Console.WriteLine(" Opens: " + List.opens);
            Console.WriteLine(" Bounces: " + List.bounces);
            Console.WriteLine(" Unsubscribes: " + List.unsubscribes);
            Console.WriteLine(" Clicks: " + List.clicks);
            Console.WriteLine(" Forwards: " + List.forwards);
            Console.WriteLine(" Abuse Complaint: " + List.abuseReports);
            Console.WriteLine(" Subject: " + List.subject);
            Console.WriteLine(" ShareUrl: " + List.shareURL);



        }

        public static void reportGetOpenCountry(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1,2, "", "");

            string emailID = campaignList[0].id;
            BenchmarkEmail.ReportCountryOpenStruct[] List = obj.reportGetOpenCountry(emailID);


           for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Country: " + List[i].country_name);
                Console.WriteLine("StateCode: " + List[i].country_region);
                Console.WriteLine("OpenCount: " + List[i].openCount);
                if (i == 100)
                    break;

            };



        }
        public static void reportGetOpenForCountry(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string CountryCode = "IN";

            BenchmarkEmail.EmailStructure[] campaignList = obj.reportGet("", 1, 1, "", "");

            string emailID = campaignList[0].id;
            BenchmarkEmail.ReportCountryOpenStruct[] List = obj.reportGetOpenForCountry(emailID, CountryCode);


            for (int i = 0; i < List.Length; i++)
            {
                Console.WriteLine(List[i].sequence + " Country: " + List[i].country_name);
                Console.WriteLine("StateCode: " + List[i].country_region);
                Console.WriteLine("OpenCount: " + List[i].openCount);
            };



        }
        public static void reportGetCount(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            double count = obj.reportGetCount("");
            Console.WriteLine("Report Count is: " + count);
        }

        public static void register()
        {
            BenchmarkEmail.ClientMasterStructure clientstruct = new BenchmarkEmail.ClientMasterStructure();
            clientstruct.firstname = "Peter";
            clientstruct.lastname = "Smith";
            clientstruct.companyname = "";
            clientstruct.email = "p.smith@userdomain.com";
            clientstruct.phone = "";
            clientstruct.login = "psmith";
            clientstruct.password = "789iop123";
            clientstruct.promocode = "";
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            int Retval = obj.register(clientstruct);
            Console.WriteLine(Retval.ToString());
        }

        public static void ImageGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ImageStructure[] ImageList = obj.imageGetList(1, 100);

            if (ImageList.Length > 0)
            {
                Console.WriteLine("No of Images Found :" + ImageList.Length);
                string id = ImageList[0].id;
                Console.WriteLine(id.ToString());

            };


        }

        public static void ImageDelete(string userName, string password)
        {

            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ImageStructure[] ImageList = obj.imageGetList(1, 100);

            if (ImageList.Length > 0)
            {
                string id = ImageList[0].id;
                string output = obj.imageDelete(id).ToString();
                Console.WriteLine(output);
            };

        }

        public static void imageGetCount(string userName, string password)
        {

            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            int imageCount = obj.imageGetCount();

            Console.WriteLine(imageCount);


        }

        public static void imageGet(string userName, string password)
        {

            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ImageStructure[] ImageList = obj.imageGetList(1, 100);
             if (ImageList.Length > 0)
            {
                string id = ImageList[0].id;
                BenchmarkEmail.ImageData imgData = obj.imageGet(id);
                Console.WriteLine(imgData.image_id + ")" + imgData.image_name);
                Console.WriteLine("ImageSize:" + imgData.image_size+" ImageUrl:"+imgData.image_url);
                Console.WriteLine("ImageHeight:" + imgData.image_height);

            }
        }




        public static void setContactInfo(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ClientSettingsStructure CltSet = new BenchmarkEmail.ClientSettingsStructure();
            CltSet.first_name  = "FirstName";
            CltSet.last_name = "LastName";
            CltSet.address = "signing address";
            CltSet.email  = "username@userdomain.com";
            int retVal = obj.clientSetContactInfo(CltSet);

            Console.WriteLine(retVal.ToString());

        }

        public static void getContactInfo(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ClientSettingsStructure CltSet = new BenchmarkEmail.ClientSettingsStructure();
            CltSet = obj.clientGetContactInfo();

            Console.WriteLine(CltSet.company);


        }

        public static void confirmEmailList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ConfirmEmailStructure[] ConfirmEmailList = obj.confirmEmailList();
            int ConfirmEmailListSize = ConfirmEmailList.Length;

            string id = "";
            string email = "";
            string confirmed = "";
            string createddate = "";
            string modifieddate = "";

            if (ConfirmEmailListSize > 0)
            {
                Console.WriteLine("No of Confirmed Emails Found :" + ConfirmEmailListSize.ToString());

                for (int i = 0; i < ConfirmEmailListSize; i++)
                {
                    id = ConfirmEmailList[i].id;
                    Console.WriteLine(id.ToString());
                    email = ConfirmEmailList[i].email;
                    Console.WriteLine(email.ToString());
                    confirmed = ConfirmEmailList[i].confirmed;
                    Console.WriteLine(confirmed.ToString());
                    createddate = ConfirmEmailList[i].createddate;
                    Console.WriteLine(createddate.ToString());
                    modifieddate = ConfirmEmailList[i].modifieddate;
                    Console.WriteLine(modifieddate.ToString());
                };

            };


        }

        public static void confirmEmailAdd(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string TargetEmailID = "p.smith@userdomain.com,bruce.smith@userdomain.com";


            string output = obj.confirmEmailAdd(TargetEmailID);

            if (output.Length == 0)
            {
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Could not be added:" + output);
            };


        }

        public static void clientGetPlanInfo(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ClientPlanInfoStructure CltSet = obj.clientGetPlanInfo();
            Console.WriteLine(CltSet.plan_name);
            Console.WriteLine(CltSet.account_expire);
        }

        public static byte[] StreamFile(string filename)
        {
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            // Create a byte array of file stream length
            byte[] ImageData = new byte[fs.Length];

            //Read block of bytes from stream into the byte array
            fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //Close the File Stream
            fs.Close();
            return ImageData; //return the byte data
        }

        public static void addImage(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.ImageData imgData = new BenchmarkEmail.ImageData();
            imgData.image_name = "160x600.jpg";
            byte[] bytedata = StreamFile("D:\\mysite\\website\\images\\partner\\banners\\160x600.jpg");
            imgData.image_data = Convert.ToBase64String(bytedata);
            bool myflag = obj.imageAdd(imgData);

            Console.WriteLine(myflag.ToString());

        }

        public static void subAccountCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.AccountStructure accountstruct = new BenchmarkEmail.AccountStructure();
            accountstruct.email = "useremail@userdomain.com";
            accountstruct.firstname = "ufirstname";
            accountstruct.lastname = "ulastname";
            accountstruct.login = "ulogin";
            accountstruct.password = "upassword";
            accountstruct.phone = "mphone";

            int retval = obj.subAccountCreate(accountstruct);

            Console.WriteLine(retval.ToString());
        }

        public static void subAccountUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            // update the details for the first subaccount obtained from the list.


            BenchmarkEmail.AccountStructure accountstruct = new BenchmarkEmail.AccountStructure();
            BenchmarkEmail.AccountStructure[] accountstructs = obj.subAccountGetList();

            if (accountstructs != null)
                if (accountstructs.Length > 0)
                    accountstruct.clientid = accountstructs[0].clientid;

            accountstruct.email = "useremail@userdomain.com";
            accountstruct.firstname = "ufirstname1";
            accountstruct.password = "upassword1";

            int retval = obj.subAccountUpdate(accountstruct);

            Console.WriteLine(retval.ToString());
        }

        public static void subAccountUpdateStatus(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.AccountStructure[] accountstruct = obj.subAccountGetList();
            string subaccountid = "1354";
            string status = "1"; // 0 for inactive && 1 for active
            obj.subAccountUpdateStatus(subaccountid, status);
        }


        public static void subAccountGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.AccountStructure[] accountstruct = obj.subAccountGetList();

            if (accountstruct != null)
            {
                if (accountstruct.Length > 0)
                {
                    for (int i = 0; i < accountstruct.Length; i++)
                    {
                        Console.WriteLine(" clientid         -> " + accountstruct[i].clientid);
                        Console.WriteLine(" login            -> " + accountstruct[i].login);
                        Console.WriteLine(" firstname        -> " + accountstruct[i].firstname);
                        Console.WriteLine(" lastname         -> " + accountstruct[i].lastname);
                        Console.WriteLine(" volume allocated -> " + accountstruct[i].plan_email_limit);
                        Console.WriteLine(" volume used      -> " + accountstruct[i].free_mail_sent);
                        Console.WriteLine(" active      -> " + accountstruct[i].active);

                    };
                };
            };


        }
        public static void pollCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.PollStructure pollstruct = new BenchmarkEmail.PollStructure();
            pollstruct.answer1 = "Never";
            pollstruct.answer2 = "Once a year";
            pollstruct.answer3 = "Every Month";
            pollstruct.answer4 = "Every Week";
            pollstruct.answer5 = "Daily";
            pollstruct.name = "Resturant Poll";
            pollstruct.question = "Do you eat out regularly";
            pollstruct.answercolor = "#0000ff";
            pollstruct.answerfont ="Comic Sans Ms";
            pollstruct.borderbg = "#777700";
            pollstruct.buttontext = "Submit";
            pollstruct.formbg = "#FDF000";
           


            string retval = obj.pollCreate(pollstruct);

            Console.WriteLine(retval.ToString());
        }
        public static void pollDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string pollId;
            pollId = "34";
            string retval = obj.pollDelete(pollId);

            Console.WriteLine(retval.ToString());
        }
        public static void pollUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string PollID = "46";
            obj.CurrentToken = token;
            BenchmarkEmail.PollStructure pollstruct = new BenchmarkEmail.PollStructure();
            pollstruct.id = "46";
            pollstruct.answercolor = "#0000ff";
            pollstruct.answer1 = "yes";
            pollstruct.answer2 = "No";
            
            pollstruct.answer3 = "Maybe";
            pollstruct.answer4 = "can't";
            pollstruct.answer5 = "possible";
            pollstruct.answercolor = "#0000ff";
            pollstruct.answerfont = "Comic Sans Ms";
            pollstruct.borderbg = "#777700";
            pollstruct.buttontext = "Submit";
            pollstruct.formbg = "#FDF000";
            pollstruct.name = "Resturant Poll";
            pollstruct.question = "Do you have trouble sleeping.";


            string retval = obj.pollUpdate(PollID,pollstruct);
            Console.WriteLine(retval.ToString());
        }

        public static void pollCopy(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.PollStructure[] pollStruct = obj.pollGetList("", "", 1, 10, "", "");
            string NewPollID = obj.pollCopy(pollStruct[0].id, "Computer Usege Poll");
            if (NewPollID != "0")
            {
                Console.WriteLine("NewPollID : " + NewPollID);
            }
            else
            {
                Console.WriteLine("Poll Can't be Copied");
            }
        }

        public static void surveyCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyStructure surveyData = new BenchmarkEmail.SurveyStructure();
            surveyData.name = "Sales Survey123";
            surveyData.url = "www.benchmarkemail.com";
            surveyData.title = "Shop Survey";
            string retval = obj.surveyCreate(surveyData);
            Console.WriteLine(retval.ToString());
        }

        public static void surveyQuestionCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string SurveyID = "473";
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyQuestionStructure surveyquestion = new BenchmarkEmail.SurveyQuestionStructure();
            surveyquestion.answer1 = "yes";
            surveyquestion.answer2 = "No";
            surveyquestion.question = "Would u like this Product";
            surveyquestion.questionoptions = "2";
            surveyquestion.questiontype = "2";//For Radio
            surveyquestion.comment = "0";
            surveyquestion.surveyid = "473";
            string retval = obj.surveyQuestionCreate(SurveyID,surveyquestion);
            Console.WriteLine(retval.ToString());
        }

        public static void surveyQuestionUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string SurveyID = "473";
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyQuestionStructure surveyquestion = new BenchmarkEmail.SurveyQuestionStructure();
            surveyquestion.answer1 = "Good";
            surveyquestion.answer2 = "Better";
            surveyquestion.answer3 = "Best";
            surveyquestion.answer4 = "Not Effective";
            surveyquestion.question = "What is your opinion about our product?";
            surveyquestion.questionid = "2311";
            surveyquestion.questionoptions = "4";
            surveyquestion.questiontype = "3";
            surveyquestion.comment = "0";
            surveyquestion.surveyid = "473";
            string retval = obj.surveyQuestionUpdate(SurveyID,surveyquestion);
            Console.WriteLine(retval.ToString());
        }
        public static void surveyUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string SurveyID = "79401";
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyStructure survey = new BenchmarkEmail.SurveyStructure();
            survey.name = "Sales Feedback Survey12";
            survey.url = "www.benchmarkemail.com";
            survey.title = "Shop Survey";
            survey.status = "1";
            survey.intro = "Take this Survey for test";
            survey.logourl = "http://www.benchmarkemail.com/images/editor/apply.gif";
            survey.id = "79401";
            string retval = obj.surveyUpdate(SurveyID,survey);
            Console.WriteLine(retval.ToString());
        }
        public static void surveyDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string SurveyID = "472";
            string retval = obj.surveyDelete(SurveyID);
            Console.WriteLine(retval.ToString());
        }

        public static void surveyQuestionDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string SurveyID = "473";
            string QuestionID = "2311";
            string retval = obj.surveyQuestionDelete(SurveyID,QuestionID);
            Console.WriteLine(retval.ToString());
        }
        public static void surveyColorUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            string SurveyID = "473";
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyColorStructure survey = new BenchmarkEmail.SurveyColorStructure();
            survey.answerfont = "sans-serif";
            survey.answersize = "14px";
            survey.surveyid = "473";
            string retval = obj.surveyColorUpdate(SurveyID,survey);
            Console.WriteLine(retval.ToString());
        }
        public static void surveyGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SurveyStructure[] SurveyStruct = obj.surveyGetList("", "", 1, 10, "date", "desc");

            for (int i = 0; i < SurveyStruct.Length; i++)
            {
                Console.WriteLine(SurveyStruct[i].sequence + " Name" + SurveyStruct[i].name);
                Console.WriteLine(" ID: " + SurveyStruct[i].id);
                Console.WriteLine("Created Date: " + SurveyStruct[i].createdDate);
                Console.WriteLine("Updated Date: " + SurveyStruct[i].modifiedDate);
                Console.WriteLine("Live Date: " + SurveyStruct[i].livedate);
                Console.WriteLine("SurveyUrl:" + SurveyStruct[i].url);
                Console.WriteLine("Title:" + SurveyStruct[i].title);
                Console.WriteLine("IntroText: " + SurveyStruct[i].intro);
                Console.WriteLine("LogoUrl: " + SurveyStruct[i].logourl);
                Console.WriteLine("Post-Survey Url : " + SurveyStruct[i].successurl);
                Console.WriteLine("Description:" + SurveyStruct[i].description);
                Console.WriteLine("Status:" + SurveyStruct[i].status);
            };

        }

        public static void surveyGetColor(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.SurveyStructure[] SurveyStruct = obj.surveyGetList("", "", 1, 10, "date", "desc");
            string SurveyID = SurveyStruct[0].id;
            BenchmarkEmail.SurveyColorStructure surveyColorStruct = obj.surveyGetColor(SurveyID);
            Console.WriteLine(" ID: " + surveyColorStruct.surveyid);    
            Console.WriteLine("Answer Font:- "+surveyColorStruct.answerfont);
                Console.WriteLine("Answer Size: " + surveyColorStruct.answersize);
                Console.WriteLine("Button Alignment: " + surveyColorStruct.buttonalign);
                Console.WriteLine("Button Text: " + surveyColorStruct.buttontext);
                Console.WriteLine("Form Background:" + surveyColorStruct.formbg);
                Console.WriteLine("Form Foreground:" + surveyColorStruct.formfg);
                Console.WriteLine("Header Background: " + surveyColorStruct.headerbg);
                Console.WriteLine("Header Foreground: " + surveyColorStruct.headerfg);
                Console.WriteLine("Header Font : " + surveyColorStruct.headerfont);
                Console.WriteLine("Header Size:" + surveyColorStruct.headersize);
                Console.WriteLine("Intro msg align:" + surveyColorStruct.introalign);


        }
        public static void surveyStatusUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string Status = "1";
            string SurveyID = "474";
            int retval = obj.surveyStatusUpdate(SurveyID,Status);
            Console.WriteLine(retval.ToString());
        }

        public static void surveyGetQuestionList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string SurveyID = "473";
            BenchmarkEmail.SurveyQuestionStructure[] surveyQuestion = obj.surveyGetQuestionList(SurveyID);
            for (int i = 0; i < surveyQuestion.Length; i++)
            {
                Console.WriteLine(surveyQuestion[i].question + " Question");
                Console.WriteLine(" Type: " + surveyQuestion[i].questiontype);
                Console.WriteLine("No of options: " + surveyQuestion[i].questionoptions);
                Console.WriteLine("Answer 1: " + surveyQuestion[i].answer1);
            }
        }
        public static void surveyReportList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ReportSurveyStructure[] surveyReportStructure = obj.surveyReportList("", "", 1, 10, "", "");
            for (int i = 0; i < surveyReportStructure.Length; i++)
            {
                Console.WriteLine(surveyReportStructure[i].name + " Name");
                Console.WriteLine(" Responses: " + surveyReportStructure[i].response);
                Console.WriteLine("No of questions: " + surveyReportStructure[i].questions);
                Console.WriteLine("INtro: " + surveyReportStructure[i].intro);
            }
        }
        public static void surveyResponseReport(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string SurveyID = "473";
            BenchmarkEmail.SurveyQuestionStructure[] surveyQuestion = obj.surveyResponseReport(SurveyID);
            for (int i = 0; i < surveyQuestion.Length; i++)
            {
                Console.WriteLine(surveyQuestion[i].question + " Question");
                Console.WriteLine(" Type: " + surveyQuestion[i].questiontype);
                Console.WriteLine("No of options: " + surveyQuestion[i].questionoptions);
                Console.WriteLine("Option1Response: " + surveyQuestion[i].answer1count);
                Console.WriteLine("Option2Response: " + surveyQuestion[i].answer2count);
                Console.WriteLine("Option3Response: " + surveyQuestion[i].answer3count);
                Console.WriteLine("Option4Response: " + surveyQuestion[i].answer4count);
                Console.WriteLine("Option5Response: " + surveyQuestion[i].answer5count);
                Console.WriteLine("Option6Response: " + surveyQuestion[i].answer6count);
                Console.WriteLine("Option7Response: " + surveyQuestion[i].answer7count);
                Console.WriteLine("Option8Response: " + surveyQuestion[i].answer8count);
                Console.WriteLine("Option9Response: " + surveyQuestion[i].answer9count);
                Console.WriteLine("Option10Response: " + surveyQuestion[i].answer10count);
                Console.WriteLine("Answer 1: " + surveyQuestion[i].answer1);
            }
        }
        public static void emailCategoryGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.EmailTemplateCategoryStructure[] emailCategoryStruct = obj.emailCategoryGetList();
            for (int i = 0; i < emailCategoryStruct.Length; i++)
            {
                Console.WriteLine(emailCategoryStruct[i].sequence + "\n Name:->" + emailCategoryStruct[i].name);
                Console.WriteLine(" ID: " + emailCategoryStruct[i].id);
                Console.WriteLine("\n No. Of Templates : "+emailCategoryStruct[i].count);
                Console.WriteLine("\n IsNew : "+emailCategoryStruct[i].newFlag);
                
            }
        }
        public static void surveyTemplateGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyTemplateStructure[] surveyTemplate = obj.surveyTemplateGetList();
            for (int i = 0; i < surveyTemplate.Length; i++)
            {
                Console.WriteLine(surveyTemplate[i].sequence + "\n Name : " + surveyTemplate[i].name);
                Console.WriteLine("\n ID: " + surveyTemplate[i].id);
                Console.WriteLine("\n Image:" + surveyTemplate[i].image);
                Console.WriteLine("\n description:" + surveyTemplate[i].description);
                Console.WriteLine("\n Question Count:" + surveyTemplate[i].quesCount);

            }
        }
        public static void surveyCopy(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyStructure[] surveyStruct = obj.surveyGetList("", "", 1, 10, "", "");
            string NewSurveyID = obj.surveyCopy(surveyStruct[0].id, "Shoe Survey");
            Console.WriteLine("NewSurveyID : " + NewSurveyID);
        }
        public static void surveyCopyTemplate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.SurveyTemplateStructure[] surveyTemplateStruct = obj.surveyTemplateGetList();
            string NewSurveyID = obj.surveyCopyTemplate(surveyTemplateStruct[0].id, "Deodrant4 Survey");
            Console.WriteLine("NewSurveyID: " + NewSurveyID);

        }
            

        public static void pollGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.PollStructure[] PollStruct = obj.pollGetList("", "", 1, 10, "", "");

            for (int i = 0; i < PollStruct.Length; i++)
            {
                Console.WriteLine(PollStruct[i].sequence + "\nName:->" + PollStruct[i].name);
                Console.WriteLine(" ID: " + PollStruct[i].id);
                Console.WriteLine(" LiveDate:" + PollStruct[i].livedate);
                Console.WriteLine("Created Date: " + PollStruct[i].createdDate);
                Console.WriteLine("Updated Date: " + PollStruct[i].modifiedDate);
                Console.WriteLine("URL: " + PollStruct[i].url);
                Console.WriteLine("Answer Color :" + PollStruct[i].answercolor);
                Console.WriteLine("Answer Font :" + PollStruct[i].answerfont);
                Console.WriteLine("Border BackGround :" + PollStruct[i].borderbg);
                Console.WriteLine("Button Text :" + PollStruct[i].buttontext);
                Console.WriteLine("Form BackGround :" + PollStruct[i].formbg);
                Console.WriteLine("Question Color" + PollStruct[i].questioncolor);
                Console.WriteLine("Question Font" + PollStruct[i].questionfont);
            };

        }
        public static void pollStatusUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string Status = "2";
            string PollID = "46";
            int retval = obj.pollStatusUpdate(PollID,Status);
            Console.WriteLine(retval.ToString());
        }
        public static void pollResponseReport(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string PollID = "41";
            BenchmarkEmail.PollStructure[] pollStruct = obj.pollResponseReport(PollID);
            for (int i = 0; i < pollStruct.Length; i++)
            {
                Console.WriteLine(pollStruct[i].question + " Question");
                Console.WriteLine("Name: " + pollStruct[i].name);
                Console.WriteLine("Option1Response: " + pollStruct[i].answer1count);
                Console.WriteLine("Option2Response: " + pollStruct[i].answer2count);
                Console.WriteLine("Option3Response: " + pollStruct[i].answer3count);
                Console.WriteLine("Option4Response: " + pollStruct[i].answer4count);
                Console.WriteLine("Option5Response: " + pollStruct[i].answer5count);
                Console.WriteLine("TotalResponses " + pollStruct[i].responses);
                Console.WriteLine("Answer 1: " + pollStruct[i].answer1);
                Console.WriteLine("Answer 2: " + pollStruct[i].answer5);
                Console.WriteLine("Answer 3: " + pollStruct[i].answer4);
                Console.WriteLine("Answer 4: " + pollStruct[i].answer3);
                Console.WriteLine("Answer 5: " + pollStruct[i].answer2);
                
            }
        }
        public static void pollReportList(string userName,string password)
        {
            BenchmarkEmail.APIWrapper obj=new BenchmarkEmail.APIWrapper();
            string token=obj.login(userName,password);
            obj.CurrentToken=token;
            BenchmarkEmail.PollStructure[] pollReportStructure=obj.pollReportList("", "", 1, 10, "", "");
            for (int i = 0; i < pollReportStructure.Length; i++)
            {
                Console.WriteLine(" Name:- "+ pollReportStructure[i].name);
                Console.WriteLine(" Responses: " + pollReportStructure[i].responses);
                Console.WriteLine("question: " + pollReportStructure[i].question);
                Console.WriteLine("status: " + pollReportStructure[i].status);
                Console.WriteLine("ModifiedDate: " + pollReportStructure[i].modifiedDate);
            }
        }
        public static void videoCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.VideoGalleryStructure videoGallery = new BenchmarkEmail.VideoGalleryStructure();
            videoGallery.video_embed = "http://www.youtube.com/watch?v=E5e33vondiI";
            Boolean retval = obj.videoCreate(videoGallery);
            Console.WriteLine(retval.ToString());
        }
        public static void videoDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string VideoID = "1060";
            string retval = obj.videoDelete(VideoID);
            Console.WriteLine(retval.ToString());
        }

        public static void videoGetList(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;

            BenchmarkEmail.VideoGalleryStructure[] videoStruct = obj.videoGetList(1, 10);

            for (int i = 0; i < videoStruct.Length; i++)
            {
                Console.WriteLine(videoStruct[i].sequence + "\nName:->" + videoStruct[i].video_embed);
                Console.WriteLine(" ID: " + videoStruct[i].id);
                Console.WriteLine("Created Date: " + videoStruct[i].createddatetime);
            };

        }

        public static void listGetSignupForms(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.SignupFormStructure[] contactList = obj.listGetSignupForms(1, 10, "id","asc");

            for (int i = 0; i < contactList.Length; i++)
            {
                Console.WriteLine(contactList[i].sequence + " Signup Form Name: " + contactList[i].name + "  (" + contactList[i].id + " )");
                Console.WriteLine("List Name: " + contactList[i].listName);
            };

        }


        public static void signupFormCreate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 100, "", "");
            BenchmarkEmail.SignupFormDataStructure signupForm = new BenchmarkEmail.SignupFormDataStructure();
            signupForm.name = "March28 2011SignUpForm1";
            signupForm.title = "Join Our Mailing List";
            signupForm.introduction = "Join our weekly newsletter list. Just enter your email below.";
            if (contactList.Length > 0)
            {
                signupForm.lists = new BenchmarkEmail.ContactListStructure[contactList.Length];
                for (int i = 0; i < contactList.Length; i++)
                {
                    signupForm.lists[i].id = contactList[i].id;
                }
            }
            string retval = obj.signupFormCreate(signupForm);
            Console.Write("New SignUp Form ID : " + retval);
        }
        public static void signupFormUpdateColor(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            bool retVal=false;
            BenchmarkEmail.SignupFormStructure[] signupFormList = obj.listGetSignupForms(1, 100, "id", "0");
            BenchmarkEmail.SignupFormColorStructure signupFomrColor = new BenchmarkEmail.SignupFormColorStructure();
            signupFomrColor.border = "1";
            signupFomrColor.formFont = "Arial";
            signupFomrColor.formSize = "25";
            signupFomrColor.introAlign = "Middle";
            signupFomrColor.formBackground = "#ff0000";
            signupFomrColor.headerFont = "sans-serif";
            signupFomrColor.headerSize = "14px";
            if (signupFormList.Length > 0)
            {
                retVal = obj.signupFormUpdateColor(signupFormList[0].id, signupFomrColor);
            }
            Console.Write(retVal);
        }
        public static void signupFormUpdate(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            bool retVal = false;
            BenchmarkEmail.SignupFormStructure[] signupFormList = obj.listGetSignupForms(1, 100, "id", "0");
            BenchmarkEmail.ContactListStructure[] contactlist = obj.listGet("", 1, 100, "", "");
            BenchmarkEmail.SignupFormDataStructure signForm = new BenchmarkEmail.SignupFormDataStructure();
            signForm.introduction = "Join our email List";
            signForm.name = "BenchmarkEmail";
            signForm.title = "Join our Mailing List";
            if (contactlist.Length > 0)
            {
                signForm.lists = new BenchmarkEmail.ContactListStructure[1];
                signForm.lists[0].id = contactlist[0].id;
            }
            if (signupFormList.Length > 0)
            {
                retVal = obj.signupFormUpdate(signupFormList[0].id, signForm);
            }
            Console.Write(retVal);

        }
        public static void signupFormUpdateMessage(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            bool retVal = false;
            BenchmarkEmail.SignupFormDataStructure signupForm = new BenchmarkEmail.SignupFormDataStructure();
            BenchmarkEmail.SignupFormStructure[] signupFomrList = obj.listGetSignupForms(1, 100, "id", "0");
            signupForm.welcomeEmailConfirmationText = "Thanks For Joining Us";
            signupForm.welcomeEmailFromEmail = "goswamiantriksh@gmail.com";
            signupForm.welcomeEmailFromName = "CybermaxSolutions";
            signupForm.welcomeEmailMessage = "Welcome to our List";
            signupForm.welcomeEmailSubject = "Confirmation Mail";

            if (signupFomrList.Length > 0)
            {
                retVal = obj.signupFormUpdateMessage(signupFomrList[0].id, signupForm);
            }
            Console.Write(retVal);

        }
        public static void signupFormGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string signFormID="";
            BenchmarkEmail.SignupFormStructure[] signupFormList = obj.listGetSignupForms(1, 1, "id", "0");
            if (signupFormList.Length > 0)
            {
                signFormID=signupFormList[0].id;
            }
            BenchmarkEmail.SignupFormDataStructure signFormData = new BenchmarkEmail.SignupFormDataStructure();
                signFormData=obj.signupFormGet(signFormID);
            Console.WriteLine("SignFormID : " + signFormData.id);
            Console.WriteLine("Introduction : " + signFormData.introduction);
            Console.WriteLine("Name : " + signFormData.name);
            Console.WriteLine("SuccessRedirectUrl : " + signFormData.successRedirectURL);
            Console.WriteLine("Title : " + signFormData.title);
            Console.WriteLine("Welcome Email Confirmation Text : " + signFormData.welcomeEmailConfirmationText);
            Console.WriteLine("Welcome Email From Name : " + signFormData.welcomeEmailFromName);
            Console.WriteLine("Welcome Email Message : " + signFormData.welcomeEmailMessage);
            Console.WriteLine("Welcome Email Signature : " + signFormData.welcomeEmailSignature);
            Console.WriteLine("Welcome Email Subject : " + signFormData.welcomeEmailSubject);
            Console.Write("Contact Lists:");
            for (int i = 0, l = signFormData.lists.Length; i < l; i++)
            {
                Console.Write(" ID : " + signFormData.lists[i].id + " Name : " + signFormData.lists[i].listname);
            }
            Console.WriteLine("Fields");
            for (int i = 0, l = signFormData.fields.Length; i < l; i++)
            {
                Console.WriteLine(" Lable : " + signFormData.fields[i].label + " Field : " + signFormData.fields[i].field + " Order : " + signFormData.fields[i].order);
            }
        }
        public static void signupFormGetCode(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string signupFormID = "";
            BenchmarkEmail.SignupFormStructure[] signupFormList = obj.listGetSignupForms(1, 100, "id", "0");
            if (signupFormList.Length > 0)
            {
                signupFormID = signupFormList[0].id;
            }
            string code = obj.signupFormGetCode(signupFormID, "HTML");
            Console.WriteLine(code);

        }
        public static void signupFormDelete(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            string signupFormID = "";
            BenchmarkEmail.SignupFormStructure[] signFormList = obj.listGetSignupForms(1, 100, "id", "0");
            if (signFormList.Length > 0)
            {
                signupFormID = signFormList[0].id;
            }
            bool retVal = obj.signupFormDelete(signupFormID);
            Console.WriteLine(retVal);
        }
        public static void listGetContactFields(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 1, "", "");
            string listID = contactList[0].id;
            XmlRpcStruct contactFields = obj.listGetContactFields(listID);
            System.Collections.IEnumerator en=contactFields.Keys.GetEnumerator();
            while(en.MoveNext())
            {
                Console.WriteLine(en.Current + "=" + contactFields[en.Current]);

            }
            

        }
        public static void listGetContactsCount(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.ContactListStructure[] contactList = obj.listGet("", 1, 3, "", "");
            string listID = contactList[2].id;
            double count = obj.listGetContactsCount(listID, "");
            Console.Write("The count is :" + count);

        }
        public static void listGetCount(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            double count = obj.listGetCount("");
            Console.WriteLine("The number of available contact list are :" + count);

        }
        public static void videoGetCount(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            int count = obj.videoGetCount();
            Console.WriteLine("The number of videos avalilable are :" + count);

        }
        public static void videoGet(string userName, string password)
        {
            BenchmarkEmail.APIWrapper obj = new BenchmarkEmail.APIWrapper();
            string token = obj.login(userName, password);
            obj.CurrentToken = token;
            BenchmarkEmail.VideoGalleryStructure[] videoList = obj.videoGetList(1, 10);
            string videoID = videoList[0].id;
            BenchmarkEmail.VideoGalleryStructure videoData = obj.videoGet(videoID);
            Console.WriteLine(videoData.sequence + ".)" + " ClientID:-" + videoData.client_id);
            Console.WriteLine("Videos :- " + videoData.client_videos);
            Console.WriteLine("VideosDescription :- " + videoData.video_description);
            Console.WriteLine("VideosEmbed :- " + videoData.video_embed);
            Console.WriteLine("VideoHeight :- " + videoData.video_height);
            Console.WriteLine("VideoImage :- " + videoData.video_image);
        }







        static void Main(string[] args)
        {
            string username = "";     // put in your BenchmarkEmail account username
            string password = ""; // put in your BenchmarkEmail account password  

            try
            {
                //signupFormDelete(username, password);
                //signupFormCreate(username, password);
                //signupFormUpdateColor(username, password);
                //signupFormUpdate(username, password);
                //signupFormUpdateMessage(username, password);
                //signupFormGet(username, password);
                //signupFormGetCode(username, password);
                //surveyGetList(username, password);
                //surveyQuestionCreate(username, password);
                //surveyCreate(username, password);
                //surveyGetQuestionList(username, password);
                //surveyReportList(username, password); 
                //pollReportList(username, password);
               //pollGetList(username, password);
                //getContactInfo(username, password);
               //videoCreate(username, password);
                //pollStatusUpdate(username, password);
                //videoDelete(username, password);
               //videoGetList(username, password);
                //listSearchContacts(username, password);
                //surveyDelete(username, password);
               //surveyUpdate(username, password);
                //surveyResponseReport(username, password);
                //surveyTemplateGetList(username, password);
                //surveyCopy(username,password);
                //surveyCopyTemplate(username, password);
                //pollResponseReport(username, password);
                //surveyQuestionDelete(username, password);
                //surveyStatusUpdate(username, password);
                //surveyQuestionUpdate(username, password);
                //surveyColorUpdate(username, password);
                //surveyGetColor(username, password);
                //pollUpdate(username, password);
                //pollDelete(username, password);
                //pollCreate(username, password);
                //pollCopy(username, password);
                // login(username, password);
                // register();
                //GetImageList(username, password);
                // ImageDelete(username, password);
                // getContactInfo(username, password);
                // setContactInfo(username, password);
                // clientGetPlanInfo(username, password);
                // addImage(username, password);
                // subAccountCreate( username, password );
                //  subAccountUpdate(username, password);
                // subAccountGetList(username, password);
                // subAccountUpdateStatus(username, password);
                // tokenAdd(username, password, "mytoken1365675");
                // tokenDelete(username, password, "mytoken1365675");
                // tokenGet( username , password);
                //emailCheckName(username, password);
                // emailCopy(username, password);
                //emailCreate(username, password);
                // emailDelete(username, password);
                // emailGet(username, password);
               // emailGetDetail( username,  password);
                // emailSchedule(username, password);
                //emailSendNow(username, password);
                // emailSendTest (username, password);
                // emailUnSchedule(username, password);
                //emailUpdate(username, password);
                //emailCategoryGetList(username, password);
                // emailAssignList(username, password); 
                // emailReassignList(username, password); 
                // segmentCreate(username, password); 
                // segmentCreateCriteria(username, password);  
                // segmentDelete(username, password); 
                // segmentDeleteCriteria(username, password);   
                //segmentGet(username, password); 
                // segmentGetContacts(username, password); 
                // segmentGetCount(username, password); 
                // segmentGetCriteriaList(username, password); 
                // segmentGetDetail(username, password); 
                // batchAddContacts(username,password );
                // batchGetStatus(username,password, listID, batchID );
                //listAddContacts( username, password);
                // listAddContactsOptin(username, password);
               //   listCreate(username, password );
               //   listDelete(username, password);
                //  listCreate(username, password);
                // listGet(username, password);
                //listGetContactDetails(username, password);
                //listGetContacts( username, password );
                //listGetContactsByType(username, password);
                // listUnsubscribeContacts(username, password);
               //listUpdateContactDetails(username, password);
               //listGetSignupForms(username, password );
                // listAddContactsForm(username,password );
                //listGetContactsAllFields(username, password);
                //reportGet(username, password);
                //reportGetBounces ( username  ,  password );
                //reportGetClicks(username, password);
                //reportGetClickEmails(username, password);
                //reportGetForwards(username, password);
                // reportGetHardBounces(username,password);
                // reportGetSoftBounces(username, password);
               //reportGetOpens(username, password);
                //reportGetUnopens(username, password);
                //reportGetUnsubscribes(username, password);
                //reportGetSummary(username, password);
                //reportCompare(username, password);
                //reportGetOpenCountry(username, password);
                //reportGetOpenForCountry(username, password);
                // confirmEmailList(username,password);
                // confirmEmailAdd(username, password);
                // emailRssGet(username, password); 
                // emailRssGetDetail(username, password);
                // emailRssCreate(username,password);
                // emailRssSchedule(username, password);
                // emailRssUpdate(username, password);
                // emailResend(username, password );
                // emailQuickSend(username, password);
                // autoresponderGetList( username , password );
                // autoresponderGetDetail(username, password);
                // autoresponderGetEmailDetail(username, password);
                // autoresponderCreate(username, password);
                //autoresponderDetailCreate(username, password);
                // autoresponderUpdate(username, password);
                // autoresponderDelete(username, password);
               //autoresponderDetailDelete(username, password);
                //imageGetCount(username, password);
                //imageGet(username, password);
               
                //autoresponderDetailHistoryDelete(username, password);
                //emailTemplateGetList(username, password);
                //emailTemplateGetCount(username, password);
                //emailPreview(username, password);
                //emailPreviewTest(username, password);
                //listGetContactFields(username, password);
                //listGetContactsCount(username, password);
                //listGetCount(username, password);
                //reportGetCount(username, password);
                //videoGetCount(username, password);
                //videoGet(username, password);
                



            }
            catch (System.Exception ex)
            {
                Console.WriteLine("exception found " + ex.Message.ToString());
            };




            Console.ReadKey();
        }
    }
}
