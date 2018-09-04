constructor



namespace MyProj_1
{
    class Circle
    {
        public int radius;
        public const float PI = 3.14F;
        public static int count;

        public Circle()           //建構函式的名稱和類別的名稱相同
        {                         //(雖然沒有傳回值，但無須宣告為void)
            count++;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();     //建立物件時會自動建構函式
            Circle c2 = new Circle();     //建立物件時會自動建構函式
            Console.WriteLine(Circle.count);
        }
    }
}


全是我的研究筆記
