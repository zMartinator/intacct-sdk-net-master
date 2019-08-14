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

using Intacct.SDK.Functions.Common.Query.Comparison.LessThanOrEqualTo;
using Xunit;

namespace Intacct.SDK.Tests.Functions.Common.Query.Comparison.LessThanOrEqualTo
{
    public class LessThanOrEqualToStringTest
    {
        [Fact]
        public void ToStringTest()
        {
            LessThanOrEqualToString condition = new LessThanOrEqualToString()
            {
                Field = "VENDORID",
                Value = "V1234",
            };
            
            Assert.Equal("VENDORID <= 'V1234'", condition.ToString());
        }
        
        [Fact]
        public void ToStringNotTest()
        {
            LessThanOrEqualToString condition = new LessThanOrEqualToString()
            {
                Negate = true,
                Field = "VENDORID",
                Value = "V1234",
            };
            
            Assert.Equal("NOT VENDORID <= 'V1234'", condition.ToString());
        }
        
        [Fact]
        public void ToStringEscapeQuotesTest()
        {
            LessThanOrEqualToString condition = new LessThanOrEqualToString()
            {
                Field = "VENDORNAME",
                Value = "Bob's Pizza, Inc.",
            };
            
            Assert.Equal("VENDORNAME <= 'Bob\'s Pizza, Inc.'", condition.ToString());
        }
    }
}