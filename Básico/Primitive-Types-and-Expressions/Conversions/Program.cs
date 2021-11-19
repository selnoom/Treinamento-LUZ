namespace TypeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1000;
            byte b = (byte)i;

            var number = "1234";
            int z = Convert.ToInt32(number);

            try
            {
                var numberTwo = "1234";
                byte bTwo = Convert.ToByte(numberTwo);
            }
            catch (Exception)
            {
                Console.WriteLine("Erro de conversão");
            }


            Console.WriteLine(b);
        }
    }
}