using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
    public class ItemCard
    {
        public ItemCard(Label label, HtmlImage image, HtmlAnchor link)
        {
            Label = label;
            Image = image;
            Link = link;
        }
        public Label Label { get; set; }
        public HtmlImage Image { get; set; }
        public HtmlAnchor Link { get; set; }
    }
}