using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplicationForChallenge.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string Texto { get; set; }
        public string Class { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "alert alert-success" : Class);
                output.Content.SetHtmlContent($"{Texto} <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden = 'true'>&times;</span></button>");
            }
        }
    }
}
