using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using INTEXII_App.Models.ViewModels;
using INTEXII_App.Models;

namespace INTEXII_App.Infrastructure
{

    [HtmlTargetElement("div", Attributes = "page-model")]

    public class PageLinkTagHelper : TagHelper
    {

        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public Filters Filters { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            TagBuilder tag = new TagBuilder("a");

            // First Page
            if(PageModel.TotalPages > 3)
            {
                if (PageModel.CurrentPage > 2)
                {
                    tag = new TagBuilder("a");

                    PageUrlValues["page"] = 1;
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass("paginationBtn");
                        tag.AddCssClass(1 == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(1.ToString());

                    result.InnerHtml.AppendHtml(tag);
                    result.InnerHtml.AppendHtml(" ... ");
                }
            }
            
            // Determine start and end pages
            int starti = PageModel.CurrentPage > 1 ? PageModel.CurrentPage - 1 : 1;
            int endi = PageModel.CurrentPage < PageModel.TotalPages - 1 ? PageModel.CurrentPage + 1 : PageModel.TotalPages;
            endi = PageModel.CurrentPage == 1 ? 3 : endi;
            starti = PageModel.CurrentPage == PageModel.TotalPages ? starti = PageModel.TotalPages - 2 : starti;

            if(PageModel.TotalPages <= 3)
            {
                starti = 1;
                endi = PageModel.TotalPages;
            }

            // Three pages from current page
            for (int i = starti; i <= endi; i++)
            {
                tag = new TagBuilder("a");

                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction,PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass("paginationBtn");
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            if (PageModel.TotalPages > 3)
            {
                if (PageModel.CurrentPage < PageModel.TotalPages - 2)
                {
                    tag = new TagBuilder("a");

                    PageUrlValues["page"] = PageModel.TotalPages;
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass("paginationBtn");
                        tag.AddCssClass(PageModel.TotalPages == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(PageModel.TotalPages.ToString());

                    result.InnerHtml.AppendHtml(" ... ");
                    result.InnerHtml.AppendHtml(tag); 
                }
            }

            output.Content.AppendHtml(result.InnerHtml);
        }


    }
}
