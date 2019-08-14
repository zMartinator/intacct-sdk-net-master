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

using System.Collections.Generic;

namespace Intacct.SDK.Functions.Common.Query.Comparison.InList
{
    public class InListString : AbstractListString
    {
        public override string ToString()
        {
            string clause = "";
            if (Negate == true)
            {
                clause = "NOT ";
            }
            
            List<string> pieces = new List<string>();
            foreach (string piece in ValuesList)
            {
                pieces.Add("'" + piece.Replace("'", "\'") + "'");
            }
            
            clause = clause + Field + " IN (" + string.Join(",", pieces) + ")";

            return clause;
        }
    }
}