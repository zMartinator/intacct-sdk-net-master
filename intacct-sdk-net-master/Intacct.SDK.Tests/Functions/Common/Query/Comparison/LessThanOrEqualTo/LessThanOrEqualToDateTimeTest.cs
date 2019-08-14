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
using Intacct.SDK.Functions.Common.Query.Comparison.LessThanOrEqualTo;
using Xunit;

namespace Intacct.SDK.Tests.Functions.Common.Query.Comparison.LessThanOrEqualTo
{
    public class LessThanOrEqualToDateTimeTest
    {
        [Fact]
        public void ToStringTest()
        {
            LessThanOrEqualToDateTime condition = new LessThanOrEqualToDateTime()
            {
                Field = "CUSTOMDATE",
                Value = new DateTime(2016, 12, 31, 23, 59, 59),
            };
            
            Assert.Equal("CUSTOMDATE <= '12/31/2016 23:59:59'", condition.ToString());
        }
        
        [Fact]
        public void ToStringNotTest()
        {
            LessThanOrEqualToDateTime condition = new LessThanOrEqualToDateTime()
            {
                Negate = true,
                Field = "CUSTOMDATE",
                Value = new DateTime(2016, 12, 31, 23, 59, 59),
            };
            
            Assert.Equal("NOT CUSTOMDATE <= '12/31/2016 23:59:59'", condition.ToString());
        }
    }
}