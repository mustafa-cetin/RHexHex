using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace RHexHex
{
    internal class ContentLoader<T>
    {

        private ContentManager content;
        private Dictionary<string, T> contents;
        public ContentLoader(ContentManager content)
        {
            contents=new Dictionary<string, T>();
            this.content= content;
        }

        public void AddContent(string contentName,string contentPath)
        {
            contents.Add(contentName, content.Load<T>(contentPath));
        }

        public T GetContent(string contentName)
        {
            return contents.GetValueOrDefault(contentName);
        }

    }
}
