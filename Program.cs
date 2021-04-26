using System;
using System.Collections.Generic;
/*
 * Project: Project 2
 * Purpose: Demonstrate design patterns
 * Coder: Sonia Friesen 08136821
 * Date: Due March 30th 2021
 */
namespace Assi2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PostProxy> Posts = new List<PostProxy>();

            PostProxy p1 = new PostProxy();
            Posts.Add(p1);

            PostProxy p2 = new PostProxy();
            Posts.Add(p2);

            PostProxy p3 = new PostProxy();
            Posts.Add(p3);

            Console.WriteLine("Welcome to the Social Network!\nEnter a command to get started, or 'help' to see a list of commands:");
            string command = "";

            while(command != "quit") {
                string[] commandArgs = command.Split(":");
                int postNum = -1;
                if(commandArgs.Length > 1) {
                    try {
                        postNum = int.Parse(commandArgs[1]);
                    } catch(FormatException) {
                        Console.WriteLine("Error: Invalid post number specified!");
                    }

                    if(postNum < 0 || postNum > Posts.Count) {
                        Console.WriteLine("Error: Invalid post number specified!");
                        break;
                    }
                }

                switch(commandArgs[0]) {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("new\t\t\tCreate a new post.");
                        Console.WriteLine("list\t\t\tList all posts.");
                        Console.WriteLine("download:[id]\t\tDownload a post.");
                        Console.WriteLine("settitle:[id]:[title]\tSet a post's title.");
                        Console.WriteLine("setbody:[id]:[body]\tSet a post's body.");
                        Console.WriteLine("view:[id]\t\tView a post.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    case "new":
                        //clone from a default post class object
                        Post p4 = new Post("default title", "default body");
                        PostProxy p5 = new PostProxy();
                        p5.post = p4.Clone() as Post;
                        Posts.Add(p5);
                        Console.WriteLine("Added new post");
                        break;
                    case "list":
                        //viewing the list (should also show updated things,loading... or downloaded (fancypost)).
                        int counter = 0;
                        foreach(PostProxy p in Posts)
                        {
                            Console.WriteLine($"{counter}\t{p.post.Title}");
                            counter++;
                        }
                        break;
                        
                    case "download":
                        //turning the ProxyPost into a fancypost
                        int index = 0;
                        bool number = int.TryParse(commandArgs[1], out index);
                        if (!number)
                            throw new ArgumentException("Not a number");
                        FancyPost fancy = new FancyPost("***Downloaded***", "+***********+\n~Downloaded Body~\n+***********+");
                        Posts[index].post = fancy.Clone() as Post;
                        Console.WriteLine("Done.");
                        break;                        
                    case "settitle":
                        index = 0;
                        number = int.TryParse(commandArgs[1], out index);
                        if (!number)
                            throw new ArgumentException("Not a number");
                        if (Posts[index].post.Title.Contains("loading..."))
                            throw new ArgumentException("Post is loading, cannot set title");
                        else if (Posts[index].post.Title.Contains("downloaded"))
                        {
                            Posts[index].post.Title = $"***{commandArgs[2]}***";
                        }
                        else
                            Posts[index].post.Title = commandArgs[2];                       
                        Console.WriteLine("Done.");
                        break;
                    case "setbody":
                        index = 0;
                        number = int.TryParse(commandArgs[1], out index);
                        if (!number)
                            throw new ArgumentException("Not a number");
                        if (Posts[index].post.Title.Contains("loading..."))
                            throw new ArgumentException("Post is loading, cannot set body");
                        else if (Posts[index].post.Title.Contains("downloaded"))
                        {
                            Posts[index].post.Body = $"+***********+\n~{commandArgs[2]}~\n+***********+";
                        }
                        else
                            Posts[index].post.Body = commandArgs[2];
                        Console.WriteLine("Done.");
                        break;
                    case "view":
                        index = 0;
                        number = int.TryParse(commandArgs[1], out index);
                        if (!number)
                            throw new ArgumentException("Not a number");
                        Posts[index].Print();
                        break;                        
                    default:
                        if(command != "") {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
