using System;
/*
 * Project: Project 2
 * Purpose: Demonstrate design patterns
 * Coder: Sonia Friesen 08136821
 * Date: Due March 30th 2021
 */
namespace Assi2
{
    class PostProxy : Content
    {
        public Post post;
        public PostProxy()
        {
            post = new Post("loading...", "loading...");
        }
        public override Content Clone()
        {
            Post p = new Post("default title", "default body");
            post.Body = p.Body;
            post.Title = p.Title;
            return post;
        }

        protected override string GetPrintableBody()
        {
            return post.Body;
        }

        protected override string GetPrintableTitle()
        {
            return post.Title;
        }
    }
}
