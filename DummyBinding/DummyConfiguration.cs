using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyBinding
{
    public class DummyConfiguration : IExtensionConfigProvider
    {
        void IExtensionConfigProvider.Initialize(ExtensionConfigContext context)
        {
            // Converting our custom object to a JObject, and back again - used for JavaScript / Java functions using this binding
            context.AddConverter<JObject, DummyMessage>(input => input.ToObject<DummyMessage>());
            context.AddConverter<DummyMessage, JObject>(input => JObject.FromObject(input));

            context.AddBindingRule<DummyAttribute>()
                .BindToCollector<DummyMessage>(attr => new DummyAsyncCollector(this, attr));

            var rule = context.AddBindingRule<DummyAttribute>();
            rule.BindToInput<DummyMessage>(BuildItemFromAttribute);
        }

        private DummyMessage BuildItemFromAttribute(DummyAttribute arg)
        {
            // input binding - this is where we get the 'thing' to hand to the function
            // For now we'll hand a hardcoded object
            return new DummyMessage { Id = "foo", Name = "bar" };
        }
    }
}
