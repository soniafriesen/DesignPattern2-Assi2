using System;
/*
 * Project: Project 2
 * Purpose: Demonstrate design patterns
 * Coder: Sonia Friesen 08136821
 * Date: Due March 30th 2021
 */
namespace Assi2
{
    abstract class Content
    {
        protected abstract string GetPrintableTitle();
        protected abstract string GetPrintableBody();
        public abstract Content Clone(); //prototype
       public void Print()
        {
            Console.WriteLine(GetPrintableTitle());
            Console.WriteLine("-----------------");
            Console.WriteLine(GetPrintableBody());
        }

    }
}
