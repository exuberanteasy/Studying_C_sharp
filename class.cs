field

property

method

constructor

destructor

indexer

operator

delegate

event

nested type


//=============================================

modifiers



//=============================================

instance variable

static variable

constant

//============================================
namespace TestProj_1
{
    class Circle
    {
        public int radius;                 //宣告一個案例變數
        public const float PI = 3.14F;     //宣告一個常數
        public static int count;           //宣告一個靜態變數
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle();      //欲存取案例變數必須建立類別的物件
            c1.radius = 5;                 //透過物件將案例變數 radius 的值 設定為 5
            Console.WriteLine(c1.radius);  //透過物件將案例變數 radius 的值 顯示出來
            Console.ReadLine();
        }
    }
}
