public class Lat_1
{
    public static void main()
    {
        addNums();
    }
    public static void addNums()
    {
        LinkedList<int> listNums = new LinkedList<int>();
        Random rnd = new Random();

        for (int i = 0; i < 10; i++) 
        {
            int num = rnd.Next(i, 100);
            listNums.AddFirst(num);
        }

        var oddNums = from item in listNums
                      where item % 2 == 0
                      orderby item descending
                      select item;

        foreach(var item in oddNums)
        {
            Console.WriteLine(item);
        }
    }
}