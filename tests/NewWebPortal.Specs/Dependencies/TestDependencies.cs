using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NewWebPortal.Specs.Steps.Infrastructure;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace NewWebPortal.Specs.Dependencies
{
    public static class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder() {
            var builder = new ContainerBuilder();
            builder.RegisterType<SeleniumDriver>().As<ISeleniumDriver>().SingleInstance();
            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();
            return builder;
        }

    }
}