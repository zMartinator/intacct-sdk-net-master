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
using Intacct.SDK.Functions.Projects;
using Intacct.SDK.Functions;
using Intacct.SDK.Tests.Xml;
using Intacct.SDK.Xml;
using Xunit;

namespace Intacct.SDK.Tests.Functions.Projects
{
    public class TaskObservedPercentCompletedUpdateTest : XmlObjectTestHelper
    {
        [Fact]
        public void GetXmlTest()
        {
            string expected = @"<?xml version=""1.0"" encoding=""utf-8""?>
<function controlid=""unittest"">
    <update>
        <OBSPCTCOMPLETED>
            <RECORDNO>1</RECORDNO>
            <PERCENT>22.00</PERCENT>
        </OBSPCTCOMPLETED>
    </update>
</function>";

            TaskObservedPercentCompletedUpdate record = new TaskObservedPercentCompletedUpdate("unittest")
            {
                RecordNo = 1,
                ObservedPercentComplete = 22.00M,
            };
            this.CompareXml(expected, record);
        }
    }
}