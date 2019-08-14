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

namespace Intacct.SDK.Functions.CashManagement
{
    public class ChargeCardTransactionLineCreate : AbstractChargeCardTransactionLine
    {

        public ChargeCardTransactionLineCreate()
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("ccpayitem");

            if (!string.IsNullOrWhiteSpace(AccountLabel))
            {
                xml.WriteElement("accountlabel", AccountLabel, true);
            } else
            {
                xml.WriteElement("glaccountno", GlAccountNumber, true);
            }

            xml.WriteElement("description", Memo);
            xml.WriteElement("paymentamount", TransactionAmount, true);
            xml.WriteElement("departmentid", DepartmentId);
            xml.WriteElement("locationid", LocationId);
            xml.WriteElement("customerid", CustomerId);
            xml.WriteElement("vendorid", VendorId);
            xml.WriteElement("employeeid", EmployeeId);
            xml.WriteElement("projectid", ProjectId);
            xml.WriteElement("itemid", ItemId);
            xml.WriteElement("classid", ClassId);
            xml.WriteElement("contractid", ContractId);
            xml.WriteElement("warehouseid", WarehouseId);
            
            xml.WriteCustomFieldsExplicit(CustomFields);
            
            xml.WriteEndElement(); //ccpayitem
        }

    }
}