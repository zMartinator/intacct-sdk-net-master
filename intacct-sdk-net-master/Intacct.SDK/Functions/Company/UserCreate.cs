﻿/*
 * Copyright 2019 Sage Intacct, Inc.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * or in the "LICENSE" file accompanying this file. This file is distributed on 
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either 
 * express or implied. See the License for the specific language governing 
 * permissions and limitations under the License.
 */

using Intacct.SDK.Xml;

namespace Intacct.SDK.Functions.Company
{
    public class UserCreate : AbstractUser
    {

        public string LastName;

        public string FirstName;

        public string PrimaryEmailAddress;

        public string ContactName;

        public UserCreate(string controlId = null) : base(controlId)
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);

            xml.WriteStartElement("create");
            xml.WriteStartElement("USERINFO");

            xml.WriteElement("LOGINID", UserId, true);
            xml.WriteElement("USERTYPE", UserType, true);

            xml.WriteStartElement("CONTACTINFO");
            xml.WriteElement("LASTNAME", LastName);
            xml.WriteElement("FIRSTNAME", FirstName);
            xml.WriteElement("EMAIL1", PrimaryEmailAddress);
            xml.WriteElement("CONTACTNAME", ContactName);
            xml.WriteEndElement(); //CONTACTINFO

            xml.WriteElement("DESCRIPTION", UserName);

            if (Active == true)
            {
                xml.WriteElement("STATUS", "active");
            }
            else if (Active == false)
            {
                xml.WriteElement("STATUS", "inactive");
            }

            xml.WriteElement("LOGINDISABLED", WebServicesOnly);
            xml.WriteElement("SSO_ENABLED", SsoEnabled);
            xml.WriteElement("SSO_FEDERATED_ID", SsoFederatedId);

            if (RestrictedEntities.Count > 0)
            {
                foreach (string restrictedEntity in RestrictedEntities)
                {
                    xml.WriteStartElement("USERLOCATIONS");
                    xml.WriteElement("LOCATIONID", restrictedEntity);
                    xml.WriteEndElement(); //USERLOCATIONS
                }
            }

            if (RestrictedDepartments.Count > 0)
            {
                foreach (string restrictedDepartment in RestrictedDepartments)
                {
                    xml.WriteStartElement("USERDEPARTMENTS");
                    xml.WriteElement("DEPARTMENTID", restrictedDepartment);
                    xml.WriteEndElement(); //USERDEPARTMENTS
                }
            }

            xml.WriteCustomFieldsImplicit(CustomFields);

            xml.WriteEndElement(); //USERINFO
            xml.WriteEndElement(); //create

            xml.WriteEndElement(); //function
        }

    }
}