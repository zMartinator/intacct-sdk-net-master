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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Intacct.SDK.Functions.Company;
using Intacct.SDK.Functions.GeneralLedger;
using Intacct.SDK.Functions;
using Intacct.SDK.Tests.Xml;
using Intacct.SDK.Xml;
using Xunit;

namespace Intacct.SDK.Tests.Functions.GeneralLedger
{
    public class StatisticalJournalEntryLineCreateTest : XmlObjectTestHelper
    {
        [Fact]
        public void GetXmlTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GLENTRY>
    <ACCOUNTNO />
    <TR_TYPE>1</TR_TYPE>
    <TRX_AMOUNT />
</GLENTRY>";

            StatisticalJournalEntryLineCreate record = new StatisticalJournalEntryLineCreate();
            
            this.CompareXml(expected, record);
        }
        
        [Fact]
        public void CreditAmountTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GLENTRY>
    <ACCOUNTNO />
    <TR_TYPE>-1</TR_TYPE>
    <TRX_AMOUNT>100.01</TRX_AMOUNT>
</GLENTRY>";

            StatisticalJournalEntryLineCreate record = new StatisticalJournalEntryLineCreate
            {
                Amount = -100.01M
            };

            this.CompareXml(expected, record);
        }
        
        [Fact]
        public void GetAllXmlTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GLENTRY>
    <DOCUMENT>212</DOCUMENT>
    <ACCOUNTNO>9000</ACCOUNTNO>
    <TR_TYPE>1</TR_TYPE>
    <TRX_AMOUNT>1456.54</TRX_AMOUNT>
    <LOCATION>100</LOCATION>
    <DEPARTMENT>ADM</DEPARTMENT>
    <PROJECTID>P100</PROJECTID>
    <CUSTOMERID>C100</CUSTOMERID>
    <VENDORID>V100</VENDORID>
    <EMPLOYEEID>E100</EMPLOYEEID>
    <ITEMID>I100</ITEMID>
    <CLASSID>C200</CLASSID>
    <CONTRACTID>C300</CONTRACTID>
    <WAREHOUSEID>W100</WAREHOUSEID>
    <DESCRIPTION>my memo</DESCRIPTION>
    <CUSTOM01>123</CUSTOM01>
</GLENTRY>";

            StatisticalJournalEntryLineCreate record = new StatisticalJournalEntryLineCreate() {
                DocumentNumber = "212",
                StatAccountNumber = "9000",
                Amount = 1456.54M,
                Memo = "my memo",
                LocationId = "100",
                DepartmentId = "ADM",
                ProjectId = "P100",
                CustomerId = "C100",
                VendorId = "V100",
                EmployeeId = "E100",
                ItemId = "I100",
                ClassId = "C200",
                ContractId = "C300",
                WarehouseId = "W100",
                CustomFields = new Dictionary<string, dynamic>
                {
                    { "CUSTOM01", "123" }
                }
            };

            this.CompareXml(expected, record);
        }
        
        [Fact]
        public void AllocationTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GLENTRY>
    <ACCOUNTNO>9000</ACCOUNTNO>
    <TR_TYPE>1</TR_TYPE>
    <TRX_AMOUNT>1456.54</TRX_AMOUNT>
    <ALLOCATION>60-40</ALLOCATION>
</GLENTRY>";

            StatisticalJournalEntryLineCreate record = new StatisticalJournalEntryLineCreate()
            {
                StatAccountNumber = "9000",
                Amount = 1456.54M,
                AllocationId = "60-40",
            };

            this.CompareXml(expected, record);
        }
        
        [Fact]
        public void CustomAllocationTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<GLENTRY>
    <ACCOUNTNO>9000</ACCOUNTNO>
    <TR_TYPE>1</TR_TYPE>
    <TRX_AMOUNT>1000.00</TRX_AMOUNT>
    <ALLOCATION>Custom</ALLOCATION>
    <SPLIT>
        <AMOUNT>600.00</AMOUNT>
    </SPLIT>
    <SPLIT>
        <AMOUNT>400.00</AMOUNT>
    </SPLIT>
</GLENTRY>";

            StatisticalJournalEntryLineCreate record = new StatisticalJournalEntryLineCreate()
            {
                StatAccountNumber = "9000",
                Amount = 1000.00M,
                AllocationId = "Custom",
            };

            CustomAllocationSplit split1 = new CustomAllocationSplit()
            {
                Amount = 600.00M,
            };

            CustomAllocationSplit split2 = new CustomAllocationSplit()
            {
                Amount = 400.00M,
            };

            record.CustomAllocationSplits.Add(split1);
            record.CustomAllocationSplits.Add(split2);

            this.CompareXml(expected, record);
        }
    }
}