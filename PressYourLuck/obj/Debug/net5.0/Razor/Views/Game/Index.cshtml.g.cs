#pragma checksum "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a33924f335a1d4d669dd6ef3e6e8e2d048bbfe2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Index), @"mvc.1.0.view", @"/Views/Game/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\_ViewImports.cshtml"
using PressYourLuck;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\_ViewImports.cshtml"
using PressYourLuck.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a33924f335a1d4d669dd6ef3e6e8e2d048bbfe2", @"/Views/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"842051d68800ad210ef9b3389f15811b05c4578d", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tile>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/unknown.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/bust.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/money.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\r\n<h4>Current Bet: $ ");
#nullable restore
#line 3 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
              Write(ViewData["currentBet"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
  
    if (!string.IsNullOrEmpty((string)ViewData["currentBet"]))
    {
        if (double.Parse((string)ViewData["currentBet"]) > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\'", 235, "\'", 274, 1);
#nullable restore
#line 10 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
WriteAttributeValue("", 242, Url.Action("TakeCoins", "Game"), 242, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success rounded\">Take the Coins!</a>\r\n");
#nullable restore
#line 11 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
        }
        else
        {
            if (double.Parse((string)ViewData["coins"]) > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\'", 460, "\'", 495, 1);
#nullable restore
#line 16 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
WriteAttributeValue("", 467, Url.Action("Index", "Home"), 467, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger rounded\">Try Again!</a>\r\n");
#nullable restore
#line 17 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
            }
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n");
#nullable restore
#line 23 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
     foreach (var tile in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-2\">\r\n            <div class=\"card\">\r\n\r\n");
#nullable restore
#line 28 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                 if (tile.Visible == false)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3a33924f335a1d4d669dd6ef3e6e8e2d048bbfe28300", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <a");
            BeginWriteAttribute("href", " href=\'", 876, "\'", 920, 1);
#nullable restore
#line 31 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
WriteAttributeValue("", 883, Url.Action("FlipTile", "Game", tile), 883, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Choose</a>\r\n");
#nullable restore
#line 32 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                }
                else if (tile.Value == "0.00")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3a33924f335a1d4d669dd6ef3e6e8e2d048bbfe210386", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 36 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3a33924f335a1d4d669dd6ef3e6e8e2d048bbfe211928", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 40 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                 if (tile.Visible)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"card-body\">\r\n                        <div>");
#nullable restore
#line 45 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                        Write(tile.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n");
#nullable restore
#line 47 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 51 "C:\Users\aoinoikaz\School\Semester 3\Microsoft Web Technologies\Assignment 3\PROG2230-AS3-DT7321599\PressYourLuck\PressYourLuck\Views\Game\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tile>> Html { get; private set; }
    }
}
#pragma warning restore 1591