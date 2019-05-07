using Microsoft.Azure.WebJobs.Description;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyBinding
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public class DummyAttribute : Attribute
    {
        [AppSetting]
        public string ConStr { get; set; }
    }
}
