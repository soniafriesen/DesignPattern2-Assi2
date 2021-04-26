using System;
/*
 * Project: Project 2
 * Purpose: Demonstrate design patterns
 * Coder: Sonia Friesen 08136821
 * Date: Due March 30th 2021
 */
namespace Assi2
{
    class Post : Content
    {
        public string Title;
        public string Body;

        public Post(string t, string b) {
            this.Title = t;
            this.Body = b;
        }
        public override Content Clone()
        {
            Post p = new Post("Default Title", "Default Body");
            p.Title = Title;
            p.Body = Body;
            return p;
        }

        //template method
        protected override string GetPrintableBody()
        {
            return Title;
        }

        protected override string GetPrintableTitle()
        {
            return Body;
        }

        

    }
}
