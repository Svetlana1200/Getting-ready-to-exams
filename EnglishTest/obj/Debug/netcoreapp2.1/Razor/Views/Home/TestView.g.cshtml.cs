#pragma checksum "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a66387745b212c3473f15d62f3c0fb4aa6a19a52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TestView), @"mvc.1.0.view", @"/Views/Home/TestView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TestView.cshtml", typeof(AspNetCore.Views_Home_TestView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a66387745b212c3473f15d62f3c0fb4aa6a19a52", @"/Views/Home/TestView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a378ae84643e2852e7b9a41659f9c2de2cadb65", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TestView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ITask>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/ShowNextTask"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(14, 11, true);
            WriteLiteral("\r\n<h4>Task ");
            EndContext();
            BeginContext(26, 18, false);
#line 3 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
    Write(ViewBag.TaskNumber);

#line default
#line hidden
            EndContext();
            BeginContext(44, 1, true);
            WriteLiteral("/");
            EndContext();
            BeginContext(46, 19, false);
#line 3 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
                        Write(ViewBag.TotalNumber);

#line default
#line hidden
            EndContext();
            BeginContext(65, 9, true);
            WriteLiteral("</h4>\r\n\r\n");
            EndContext();
            BeginContext(75, 42, false);
#line 5 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
Write(await Html.PartialAsync(Model.View, Model));

#line default
#line hidden
            EndContext();
            BeginContext(117, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 7 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
  
    if (ViewBag.UserAnswerIsRight != null)
    {
        if (ViewBag.UserAnswerIsRight)
        {

#line default
#line hidden
            BeginContext(227, 56, true);
            WriteLiteral("            <span style=\"color:green;\">Correct!</span>\r\n");
            EndContext();
#line 13 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(319, 56, true);
            WriteLiteral("            <span style=\"color:red;\">Incorrect!</span>\r\n");
            EndContext();
#line 29 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
               
        }
    }

#line default
#line hidden
#line 33 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
  
    if (ViewBag.TaskNumber < ViewBag.TotalNumber)
    {

#line default
#line hidden
            BeginContext(885, 11, true);
            WriteLiteral("        <p>");
            EndContext();
            BeginContext(896, 43, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a754e4566f4d417f90c505e2489216b3", async() => {
                BeginContext(926, 9, true);
                WriteLiteral("Next task");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(939, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 37 "C:\Users\111\Documents\EnglishTest\Getting-ready-to-exams\EnglishTest\Views\Home\TestView.cshtml"
    }

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ITask> Html { get; private set; }
    }
}
#pragma warning restore 1591
