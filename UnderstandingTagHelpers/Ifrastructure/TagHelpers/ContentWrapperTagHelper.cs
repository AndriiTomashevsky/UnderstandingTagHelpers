using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UnderstandingTagHelpers.Ifrastructure.TagHelpers
{

    [HtmlTargetElement("div", Attributes = "title")] // _Layout.cshtml
    public class ContentWrapperTagHelper : TagHelper
    {
        public bool IncludeHeader { get; set; } = true;
        public bool IncludeFooter { get; set; } = true;
        public string Title { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "m-1 p-1");

            TagBuilder title = new TagBuilder("h1"); // <h1></h1>
            title.InnerHtml.Append(Title); // <h1>Cities</h1>

            TagBuilder container = new TagBuilder("div"); // <div></div>
            container.Attributes["class"] = "bg-info m-1 p-1"; // <div class="bg-info m-1 p-1"></div>
            container.InnerHtml.AppendHtml(title); // <div class="bg-info m-1 p-1"><h1>Cities</h1></div>

            if (IncludeHeader)
            {
                output.PreElement.SetHtmlContent(container);
            }
            if (IncludeFooter)
            {
                output.PostElement.SetHtmlContent(container);
            }
        }
    }
}