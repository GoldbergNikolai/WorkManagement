#pragma checksum "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d57c5d4e655b3e2fe88e18357eaee08613523a0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_InsertUser), @"mvc.1.0.view", @"/Views/Users/InsertUser.cshtml")]
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
#line 1 "C:\Users\Nik\source\repos\WorkManagement\Views\_ViewImports.cshtml"
using WorkManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nik\source\repos\WorkManagement\Views\_ViewImports.cshtml"
using WorkManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml"
using WorkManagement.Models.Shared;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d57c5d4e655b3e2fe88e18357eaee08613523a0e", @"/Views/Users/InsertUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23b10c7561d56213c33131b7a562a1cb938daa29", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_InsertUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml"
  
    ViewData["Title"] = "הוספת משתמש";
    var sessionUser = SessionHelper.SessionUser;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"position: absolute;\">\r\n");
#nullable restore
#line 8 "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml"
     if (sessionUser.IsAdmin)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>הוספת משתמש</h3>\r\n");
            WriteLiteral(@"        <table>
            <tr>
                <td>
                    <div>
                        <span style=""color: red;"">(*)</span>
                        <span>מספר טלפון: </span>
                        <input id=""phoneNumber"" type=""text"" class=""numbers-only"" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <span style=""color: red;"">(*)</span>
                        <span>שם םרטי: </span>
                        <input id=""firstName"" type=""text"" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                        <span style=""color: red;"">(*)</span>
                        <span>שם משפחה: </span>
                        <input id=""lastName"" type=""text"" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
              ");
            WriteLiteral(@"      <div>
                        <span style=""color: red;"">* - שדה חובה</span>
                    </div>
                </td>
            </tr>
        </table>
        <div>
            <input type=""button"" value=""צור משתמש"" id=""insertUserButton"" class=""btn-primary"" />
            <div id=""insertUserError"" style=""color: red; font-size: 14px; min-height: 10px; visibility: hidden;""></div>
        </div>
        <h4 id=""insertUserSuccessMessage"" style=""color: green; visibility: hidden;"">יצירת משתמש הסתיימה בהצלחה. מזהה משתמש הוא: </h4>
");
#nullable restore
#line 53 "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3 style=\"color: red;\">אין לך הרשאות לעמוד הזה</h3>\r\n");
#nullable restore
#line 57 "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<script type=""text/javascript"">
    $(document).ready(function () {
        $(""#insertUserButton"").on(""click"", function () {
            var phoneNumber = $(""#phoneNumber"").val();
            var firstName = $(""#firstName"").val();
            var lastName = $(""#lastName"").val();
            var insertUserError = $(""#insertUserError"");
            var insertUserSuccessMessage = $(""#insertUserSuccessMessage"");

            $(insertUserError).css(""visibility"", ""hidden"");
            $(insertUserSuccessMessage).css(""visibility"", ""hidden"");

            if (phoneNumber != """" && firstName != """" && lastName != """") {
                $.ajax({
                    url: """);
#nullable restore
#line 74 "C:\Users\Nik\source\repos\WorkManagement\Views\Users\InsertUser.cshtml"
                     Write(string.Format("{0}{1}", DomainHelper.BaseDomainUrl, Url.Action("InsertUser", "Users")));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    type: ""post"",
                    data: {
                        phoneNumber: phoneNumber,
                        firstName: firstName,
                        lastName: lastName
                    },
                    success: function (result) {
                        if (result.data != null) {
                            if (result.errorDesc != null && result.errorDesc != """") {
                                $(insertUserError).text(result.errorDesc);
                                $(insertUserError).css(""visibility"", ""visible"");
                            }
                            else if (result.data > 0) {
                                $(insertUserSuccessMessage).text($(insertUserSuccessMessage).text() + result.data);
                                $(insertUserSuccessMessage).css(""visibility"", ""visible"");
                            }
                        }
                        else if (result.errorDesc != null && result.errorDesc != """") {
 ");
            WriteLiteral(@"                           $(insertUserError).text(result.errorDesc);
                            $(insertUserError).css(""visibility"", ""visible"");
                        }
                    }
                });
            }
        });

        $(""#bringAll"").on(""click"", function () {
            if ($(this).is("":checked"")) {
                $("".to-disable"").prop(""disabled"", true);
            }
            else {
                $("".to-disable"").prop(""disabled"", false);
            }
        });
    });
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
