namespace Strings
{
    class program
    {
        static void Main(string[] args)
        {
            string firstName = "Nicholas";
            string lastName = "Peçanha";

            string fullName = firstName + " " +  lastName;
            string myFullName = string.Format("My name is {0} {1}", firstName, lastName );

            string[] names = new string[3] { "John", "Jack", "Mary" };
            var formattedNames = string.Join(",", names);

            var text = "Hi John\nLook here at \\folderName";


            Console.WriteLine(formattedNames);
            Console.WriteLine( fullName);
            Console.WriteLine( text);
            Console.WriteLine(myFullName);
        }
    }
}
