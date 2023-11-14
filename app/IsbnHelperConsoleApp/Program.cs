// See https://aka.ms/new-console-template for more information
string ISBN = null;
do
{
    var isbnHelper = new IsbnExtensions.IsbnSearch.IsbnSearch();
   
    Console.WriteLine("Please enter a 10 digit ISBN:");
    ISBN = Console.ReadLine();

    if (string.IsNullOrEmpty(ISBN))
    {
        break;
    }
    
    var result = await isbnHelper.GetIsbnResults(ISBN);
    Console.WriteLine($"For ISBN {ISBN}:");
    Console.WriteLine($"NumPages:\t{result.NumberOfPages})");
    Console.WriteLine($"PubDate:\t{result.PublishDate}");
    Console.WriteLine($"Publishers:");
    result.Publishers.ForEach(Console.WriteLine);

} while (true);
Console.Write("Bye!!");