﻿

using ConsoleApp14;

MyList<int> list = new MyList<int>();


list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);
list.Add(6);
list.Add(7);
list.Add(8);
list.Add(9);

Console.WriteLine(list.Find(x => x == 6));


foreach (var item in list.FindAll(x => x % 2 == 0))
{

        Console.WriteLine(item);
}