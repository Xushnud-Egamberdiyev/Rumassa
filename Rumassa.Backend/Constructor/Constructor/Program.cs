namespace Constructor
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program2 program = new Program2(19, "Xushnud");
            //Bu joyda Program2 Classning  (private Program2()) chaqirganimizda hatolik yuz beradi kompile timeda
            //chunki privete konstruktor Program2 klassi misollarini yaratishga ruxsat bermaydi.

            //Yagona standart konstruktor chaqiradi.

            Console.WriteLine(program.name);
            Console.WriteLine(program.num);
        }
    }

    class Program2
    {
        public int num;
        public string name;

        private Program2()
        {
            Console.WriteLine("Privete constructor");
        }

        public Program2(int a, string b)
        {
            num = a;
            name = b;
        }

    }

   
}
