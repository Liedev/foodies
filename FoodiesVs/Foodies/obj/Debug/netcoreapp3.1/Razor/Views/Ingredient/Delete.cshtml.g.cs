#pragma checksum "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3d4550a8a4b0f2eeef714af48bf6cbd3327d2b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ingredient_Delete), @"mvc.1.0.view", @"/Views/Ingredient/Delete.cshtml")]
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
#line 1 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\_ViewImports.cshtml"
using Foodies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\_ViewImports.cshtml"
using Foodies.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3d4550a8a4b0f2eeef714af48bf6cbd3327d2b7", @"/Views/Ingredient/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b24b1ed4600e1281ccba492e93875e8bced9cb9e", @"/Views/_ViewImports.cshtml")]
    public class Views_Ingredient_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Foodies.Models.Ingredient>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mt-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""headerMain"" class=""py-5 bg-image-full"">
    <h1 class=""text-center"">Delete An Ingredient</h1>
    <p class=""text-center""><strong>It will be missed</strong></p>
</div>
<div class=""card col-6 mt-4"">
    <dl class=""row"">
        <dt class=""col-sm-3"">
            ");
#nullable restore
#line 14 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 17 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 20 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EnergyKcal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 23 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EnergyKcal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 26 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EnergyKj));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 29 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EnergyKj));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 32 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Water));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 35 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Water));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 38 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EggWhite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 41 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EggWhite));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 44 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Carbohydrates));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 47 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Carbohydrates));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 50 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Sugar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 53 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Sugar));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 56 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Fat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 59 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Fat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 62 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SaturatedFat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 65 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SaturatedFat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 68 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SingleSaturatedFat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 71 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SingleSaturatedFat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 74 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MultiSaturatedFat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 77 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MultiSaturatedFat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 80 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Cholesterol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 83 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Cholesterol));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 86 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Fiber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-3\">\r\n            ");
#nullable restore
#line 89 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Fiber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3d4550a8a4b0f2eeef714af48bf6cbd3327d2b715453", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b3d4550a8a4b0f2eeef714af48bf6cbd3327d2b715716", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 94 "C:\Users\lieve\OneDrive\Bureaublad\Portfolio\Projects\Foodsies\FoodsiesProjectWeb\FoodiesVs\Foodies\Views\Ingredient\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IngredientId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3d4550a8a4b0f2eeef714af48bf6cbd3327d2b717554", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Foodies.Models.Ingredient> Html { get; private set; }
    }
}
#pragma warning restore 1591
