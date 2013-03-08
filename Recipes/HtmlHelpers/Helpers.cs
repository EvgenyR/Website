using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.Mvc;
using Recipes.ViewModels;
using System.Web.Mvc.Html;

namespace HtmlHelpers
{
    public static class Helpers
    {
        public static IHtmlString BulletedList(this HtmlHelper helper, string data)
        {
            string[] items = data.Split('|');

            var writer = new HtmlTextWriter(new StringWriter());
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            foreach (string s in items)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                writer.Write(helper.Encode(s));
                writer.RenderEndTag();
            }

            writer.RenderEndTag();
            return new HtmlString(writer.InnerWriter.ToString());
        }

        public static IHtmlString MeasureImageDiv(this HtmlHelper helper, int measureID)
        {
            string measure=string.Empty;

            switch (measureID)
            { 
                case 1:
                    measure = "gram.jpg";
                    break;
                case 2:
                    measure = "cup.gif";
                    break;
                case 3:
                    measure = "item.png";
                    break;
                case 4:
                    measure = "teaspoon.jpg";
                    break;
                case 5:
                    measure = "slice.png";
                    break;
            }

            string div = "<div class=\"display-label-nofloat\" style=\"vertical-align:top; width:26px; height:26px; background-image:url(../../Content/images/measures/" + measure + ")\"></div>";
            return new HtmlString(div);
        }

        public static IHtmlString CategoryAction(this HtmlHelper helper, int id)
        {
            return new HtmlString("../Category/Details/" + id);
        }

        public static IHtmlString SubCategoryAction(this HtmlHelper helper, int id)
        {
            return new HtmlString("../SubCategory/Details/" + id);
        }

        public static IHtmlString Paragraph(this HtmlHelper helper, string text)
        {
            return new HtmlString("<p>" + text + "</p>");
        }

        public static IHtmlString BodyTagUpdate(this HtmlHelper helper, string text)
        {
            return new HtmlString(@"<script type=""text/javascript"">
                        document.body.id ='" + text + "';" +
                  "</script>");
        }

        public static IHtmlString GameOfLifeTable(this HtmlHelper helper, string text)
        {
            string table = @"<table border=1 bordercolor=""black"" cellspacing=0 cellpadding=0>";

            for(int i = 0; i<50; i++)
            {
                table = table + "<tr>";

                for(int j=0; j<50; j++)
                {
                    table = table + "<td>" + (i + j).ToString() + "</td>";
                }

                table = table + "</tr>";
            }
            
            table = table + @"</table>";

            return  new HtmlString(table);
        }

        public static MvcHtmlString IngredientCaloricContent<TModel>(this HtmlHelper<TModel> helper)
        {
            TModel model = helper.ViewData.Model;
            IngredientViewModel viewModel = model as IngredientViewModel;


            return CaloricScript(viewModel.Ingredient.Protein, viewModel.Ingredient.Fat, viewModel.Ingredient.Carb, "Ingredient Caloric Content");
        }

        public static MvcHtmlString RecipeCaloricContent<TModel>(this HtmlHelper<TModel> helper)
        {
            TModel model = helper.ViewData.Model;
            RecipeViewModel viewModel = model as RecipeViewModel;

            return CaloricScript((int)viewModel.Recipe.TotalProteinCalories, (int)viewModel.Recipe.TotalFatCalories, (int)viewModel.Recipe.TotalCarbCalories, "Recipe Caloric Content");
        }

        public static MvcHtmlString CaloricScript(decimal protein, decimal fat, decimal carb, string title)
        {
            return new MvcHtmlString(@"
            <script type=""text/javascript"" src=""https://www.google.com/jsapi""></script>
            <script type=""text/javascript"">      
            google.load(""visualization"", ""1"", {packages:[""corechart""]});      
            google.setOnLoadCallback(drawChart);      
            function drawChart() {        
            var data = google.visualization.arrayToDataTable([          
            ['Task', 'Hours per Day'],          
            ['Protein', " + protein + @"],          
            ['Fat', " + fat + @"],          
            ['Carbohydrate', " + carb + @"]
            ]);        
            var options = {          
            title: '" + title + @"'        };        
            var chart = new google.visualization.PieChart(document.getElementById('chart_div'));        
            chart.draw(data, options);      }    
            </script>");
        }

        public static string ToSeoUrl(this string url)
        {
            // make the url lowercase
            string encodedUrl = (url ?? "").ToLower();

            // replace & with and
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");

            // remove characters
            encodedUrl = encodedUrl.Replace("'", "");

            // remove invalid characters
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

            // remove duplicates
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

            // trim leading & trailing characters
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }

        public static string ToLink(this string text, string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return "<a>" + text + "</a>";
            }
            else
            {
                return "<a href=\"" + url + "\">" + text + "</a>";
            }
        }
    }
}