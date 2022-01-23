﻿namespace SeeSharpHistory;

class Program
{
    static void Main()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");
    }
}

// interfaces  vs abstract class
// delegates

// -> method


public class RunDelegateSample
{
    public void Run()
    {
        var d = new Delegates();
        d.Choose(Delegates.Choice.One);
        Console.WriteLine(d.DoSomething("Nathan"));

        d.Choose(Delegates.Choice.Two);
        Console.WriteLine(d.DoSomething("Nathan"));


    }
}

class Delegates
{
    public event EventHandler Choosing;

    public enum Choice
    {
        One,
        Two
    }

    public delegate string DoSomethingInteresting(string arg);

    private DoSomethingInteresting MyDelegateChoice;

    public void Choose(Choice choice)
    {
        if (choice == Choice.One)
            MyDelegateChoice = DoSomething1;
        else if (choice == Choice.Two)
            MyDelegateChoice = DoSomething2;
        else
            throw new NotSupportedException();
    }


    public string DoSomething(string arg)
    {
        return MyDelegateChoice(arg);
    }

    private string DoSomething1(string arg)
    {
        return new string(arg.Reverse().ToArray());
    }


    private string DoSomething2(string arg)
    {
        return arg.ToUpper();
    }
}


class FuncActionDelegates
{
    public void Run()
    {

        //public delegate TResult Func<in T, out TResult>(T arg);
        //public delegate string DoSomethingInteresting(string arg);

        Func<string, string> MyFunction;

        MyFunction = delegate (string arg)
        {
            return new string(arg.Reverse().ToArray());
        };

        DoSomething(MyFunction, "Joel");

        var newValue = MyFunction("Joel");

        // lambda expression.

        MyFunction = (string arg) =>
        {
            return arg.ToUpper();
        };

        MyFunction = (string arg) => arg.ToUpper();

        MyFunction = arg => arg.ToUpper();


        DoSomething(MyFunction, "Confused yet?");

        DoSomething(arg => arg.ToLower(), "Now Ain't That nifty?");


        List<string> names = new List<string>
        {
            "Joel",
            "Nathan",
            "Amanda",
            "Crystal"
        };

        var findAmanda = names.Find(name => name.StartsWith("A"));

        var findCrystal = GenericFind(names, n => n.StartsWith("Cr"));

        //LINQ
        var firstInitials = names.Select(n => n[0]).ToList();

        var dunno = names
            .Where(n => n[0] < 'M')
            .Select(n => n.ToUpper())
            .Select(n => new string(n.Reverse().ToArray()))
            .ToList();


        var reversed1 = StringExtensions.ReverseString("Joel Killam");

        var reversed2 = "Joel Killam".ReverseString().ToLower();



    }

    string GenericFind(List<string> names, Func<string, bool> criteria)
    {
        foreach (var name in names)
        {
            if (criteria(name) == true)
                return name;
        }
        return null!;
    }


    string FindPerson(List<string> names, string startsWithText)
    {
        return GenericFind(names, n => n.StartsWith(startsWithText));
    }

    public string DoSomething(Func<string, string> yourSelfDefinedSomething, string arg)
    {
        var result = yourSelfDefinedSomething(arg);
        // log the result
        return result;
    }

}
static class StringExtensions
{
    public static string ReverseString(this string input)
    {
        return new string(input.Reverse().ToArray());
    }
}
