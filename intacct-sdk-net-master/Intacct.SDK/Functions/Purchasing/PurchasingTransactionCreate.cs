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

using Intacct.SDK.Functions.InventoryControl;
using Intacct.SDK.Xml;

namespace Intacct.SDK.Functions.Purchasing
{
    public class PurchasingTransactionCreate : AbstractPurchasingTransaction
    {

        public PurchasingTransactionCreate(string controlId = null) : base(controlId)
        {
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);

            xml.WriteStartElement("create_potransaction");

            xml.WriteElement("transactiontype", TransactionDefinition, true);

            xml.WriteStartElement("datecreated");
            xml.WriteDateSplitElements(TransactionDate.Value, true);
            xml.WriteEndElement(); //datecreated

            if (GlPostingDate.HasValue)
            {
                xml.WriteStartElement("dateposted");
                xml.WriteDateSplitElements(GlPostingDate.Value);
                xml.WriteEndElement(); //dateposted
            }

            xml.WriteElement("createdfrom", CreatedFrom);
            xml.WriteElement("vendorid", VendorId, true);
            xml.WriteElement("documentno", DocumentNumber);

            xml.WriteElement("referenceno", ReferenceNumber);
            xml.WriteElement("vendordocno", VendorDocNumber);
            xml.WriteElement("termname", PaymentTerm);

            xml.WriteStartElement("datedue");
            xml.WriteDateSplitElements(DueDate.Value, true);
            xml.WriteEndElement(); //datedue

            xml.WriteElement("message", Message);
            xml.WriteElement("shippingmethod", ShippingMethod);

            xml.WriteStartElement("returnto");
            xml.WriteElement("contactname", ReturnToContactName, true);
            xml.WriteEndElement(); //returnto

            xml.WriteStartElement("payto");
            xml.WriteElement("contactname", PayToContactName, true);
            xml.WriteEndElement(); //payto
            
            if (!string.IsNullOrWhiteSpace(DeliverToContactName))
            {
                xml.WriteStartElement("deliverto");
                xml.WriteElement("contactname", DeliverToContactName, true);
                xml.WriteEndElement(); //deliverto
            }

            xml.WriteElement("supdocid", AttachmentsId);
            xml.WriteElement("externalid", ExternalId);
            
            xml.WriteElement("basecurr", BaseCurrency);
            xml.WriteElement("currency", TransactionCurrency);

            if (ExchangeRateDate.HasValue)
            {
                xml.WriteStartElement("exchratedate");
                xml.WriteDateSplitElements(ExchangeRateDate.Value);
                xml.WriteEndElement(); //exchratedate
            }
            if (!string.IsNullOrWhiteSpace(ExchangeRateType))
            {
                xml.WriteElement("exchratetype", ExchangeRateType);
            }
            else if (ExchangeRateValue.HasValue)
            {
                xml.WriteElement("exchrate", ExchangeRateValue);
            }
            else if (!string.IsNullOrWhiteSpace(BaseCurrency) || !string.IsNullOrWhiteSpace(TransactionCurrency))
            {
                xml.WriteElement("exchratetype", ExchangeRateType, true);
            }
            
            xml.WriteCustomFieldsExplicit(CustomFields);

            xml.WriteElement("state", State);

            xml.WriteStartElement("potransitems");
            if (Lines.Count > 0)
            {
                foreach (PurchasingTransactionLineCreate line in Lines)
                {
                    line.WriteXml(ref xml);
                }
            }
            xml.WriteEndElement(); //potransitems

            if (Subtotals.Count > 0)
            {
                xml.WriteStartElement("subtotals");
                foreach (TransactionSubtotalCreate subtotal in Subtotals)
                {
                    subtotal.WriteXml(ref xml);
                }
                xml.WriteEndElement(); //subtotals
            }

            xml.WriteEndElement(); //create_potransaction

            xml.WriteEndElement(); //function
        }

    }
}