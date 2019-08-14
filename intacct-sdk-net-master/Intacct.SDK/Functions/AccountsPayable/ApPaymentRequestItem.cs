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

namespace Intacct.SDK.Functions.AccountsPayable
{
    public class ApPaymentRequestItem : IXmlObject
    {
       
        public int? ApplyToRecordId;

        public decimal? AmountToApply;

        public decimal? CreditToApply;

        public decimal? DiscountToApply;

        public ApPaymentRequestItem()
        {
        }

        public void WriteXml(ref IaXmlWriter xml)
        {

            xml.WriteStartElement("paymentrequestitem");

            xml.WriteElement("key", ApplyToRecordId, true);
            xml.WriteElement("paymentamount", AmountToApply, true);
            xml.WriteElement("credittoapply", CreditToApply);
            xml.WriteElement("discounttoapply", DiscountToApply);

            xml.WriteEndElement(); //paymentrequestitem
        }

    }
}