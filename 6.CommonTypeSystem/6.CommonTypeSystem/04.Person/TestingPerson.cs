﻿/*Create a class Person with two fields – name and age. Age can be left unspecified
(may contain null value. Override ToString() to display the information of a person
and if age is not specified – to say so. Write a program to test this functionality.*/
namespace PersonActions
{
    using System;

    class TestingPerson
    {
        static void Main()
        {
            Person man = new Person("Pesho", 34);
            Console.WriteLine(man);

            Person woman = new Person("Maria");
            Console.WriteLine(woman);
        }
    }
}
