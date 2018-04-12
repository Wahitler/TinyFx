using System;
using System.Reflection;

namespace TinyFx.AspNet.WebApi.HelpPage.Microsoft.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}