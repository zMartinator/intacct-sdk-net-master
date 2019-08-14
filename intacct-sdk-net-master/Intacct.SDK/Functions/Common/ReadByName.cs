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
using System.Collections.ObjectModel;
using Intacct.SDK.Xml;

namespace Intacct.SDK.Functions.Common
{
    public class ReadByName : AbstractFunction
    {
        private const int MaxNameCount = 100;

        public string ObjectName { get; set; }

        public List<string> Fields = new List<string>(
            new List<string>
            {
            }
        );

        private List<string> _names;
        public List<string> Names
        {
            get { return _names; }
            set
            {
                if (value.Count > MaxNameCount)
                {
                    throw new ArgumentException("Names count cannot exceed " + MaxNameCount.ToString());
                }
                _names = value;
            }
        }
        
        private string _docParId;
        public string DocParId
        {
            get { return _docParId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    value = "";
                }
                _docParId = value;
            }
        }

        public ReadByName(string controlId = null) : base(controlId)
        {
            Names = new List<string>();
        }

        public override void WriteXml(ref IaXmlWriter xml)
        {
            xml.WriteStartElement("function");
            xml.WriteAttribute("controlid", ControlId, true);

            xml.WriteStartElement("readByName");

            xml.WriteElement("object", ObjectName, true);
            xml.WriteElement("keys", Names.Count > 0 ? string.Join(",", Names) : "", true);
            xml.WriteElement("fields", Fields.Count > 0 ? string.Join(",", Fields) : "*", true);
            xml.WriteElement("returnFormat", "xml");
            xml.WriteElement("docparid", DocParId);

            xml.WriteEndElement(); //readByName

            xml.WriteEndElement(); //function
        }

    }
}