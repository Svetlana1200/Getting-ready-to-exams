#pragma checksum "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TextTaskView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7990020d2426c316ebe478a5a1b7e35bfc96496a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TextTaskView), @"mvc.1.0.view", @"/Views/Home/TextTaskView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TextTaskView.cshtml", typeof(AspNetCore.Views_Home_TextTaskView))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\_ViewImports.cshtml"
using EnglishTest;

#line default
#line hidden
#line 2 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\_ViewImports.cshtml"
using EnglishTest.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7990020d2426c316ebe478a5a1b7e35bfc96496a", @"/Views/Home/TextTaskView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"117f11283dcf03ded7c34fbfb7e733245ff3e951", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TextTaskView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TextTask>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(17, 72, true);
            WriteLiteral("\r\n<h4>Click in the gaps and type one word in each gap.</h4>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(90, 10, false);
#line 5 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TextTaskView.cshtml"
Write(Model.Text);

#line default
#line hidden
            EndContext();
            BeginContext(100, 51, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    <button>Check</button>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TextTask> Html { get; private set; }
    }
}
#pragma warning restore 1591