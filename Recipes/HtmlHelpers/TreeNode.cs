using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using WebGrease.Css.Extensions;

namespace HtmlHelpers
{
    public interface ITreeNode<T>
    {
        T Parent { get; }
        List<T> Children { get; }
    }

    public class BlogEntry : ITreeNode<BlogEntry>
    {
        public BlogEntry()
        {
            Children = new List<BlogEntry>();
        }

        public string Name { get; set; }
        public BlogEntry Parent { get; set; }
        public List<BlogEntry> Children { get; set; }
    }

    public static class TreeRenderHtmlHelper
    {
        public static string RenderTree<T>(
            this HtmlHelper htmlHelper,
            IEnumerable<T> rootLocations,
            Func<T, string> locationRenderer)
            where T : ITreeNode<T>
        {
            return new TreeRenderer<T>(rootLocations, locationRenderer).Render();
        }
    }
    public class TreeRenderer<T> where T : ITreeNode<T>
    {
        private readonly Func<T, string> locationRenderer;
        private readonly IEnumerable<T> rootLocations;
        private HtmlTextWriter writer;
        public TreeRenderer(
            IEnumerable<T> rootLocations,
            Func<T, string> locationRenderer)
        {
            this.rootLocations = rootLocations;
            this.locationRenderer = locationRenderer;
        }
        public string Render()
        {
            writer = new HtmlTextWriter(new StringWriter());
            RenderLocations(rootLocations);
            return writer.InnerWriter.ToString();
        }
        /// <summary>
        /// Recursively walks the location tree outputting it as hierarchical UL/LI elements
        /// </summary>
        /// <param name="locations"></param>
        private void RenderLocations(IEnumerable<T> locations)
        {
            if (locations == null) return;
            if (locations.Count() == 0) return;
            InUl(() => locations.ForEach(location => InLi(() =>
            {
                writer.Write(locationRenderer(location));
                RenderLocations(location.Children);
            })));
        }
        private void InUl(Action action)
        {
            writer.WriteLine();
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);
            action();
            writer.RenderEndTag();
            writer.WriteLine();
        }
        private void InLi(Action action)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Li);
            action();
            writer.RenderEndTag();
            writer.WriteLine();
        }
    }
}