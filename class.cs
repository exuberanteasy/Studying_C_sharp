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
//存取案例變數
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

//=========================================================================
//存取靜態變數或常數
namespace TestProj_2
{
    class Circle
    {
        public int radius;                   //宣告一個案例變數
        public const float PI = 3.14F;       //宣告一個常數
        public static int count;             //宣告一個靜態變數
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Circle.PI);    //透過類別的名稱顯示常數 PI 的值
            Console.WriteLine(Circle.count); //透過類別的名稱顯示靜態變數 count 的值
            Console.ReadLine();
        }
    }
}

//=============================================================================
唯讀變數 和 常數 有點相似，在指派 唯讀變數 的值後，就不能加以變更，但它和 常數 是不一樣的，主要的差異如下:
=> 常數隱含宣告為 static ，但 唯讀變數 不是。若要宣告 靜態唯讀變數 ，必須加上 static readonly 修飾字，
   靜態唯讀變數 和 常數 相似，不同的是 編譯器只能在執行階段存取 靜態唯讀變數 的值，不能在編譯階段進行存取。
=> 常數 可以當作 區域變數 ，但 唯讀變數 不能。
=> 常數 只能是內建的 實值型別 、 字串 或 列舉 ，不可以是 參考型別 ，而 唯讀變數 則不受此限。
=> 常數 在宣告時就必須指派值，而 唯讀變數 可以在宣告時或在 建構函式內 指派值。
=> 常數 在宣告時就必須明確地初始化，而 唯讀變數 若沒有明確的初始化，則 實值型別 的 唯讀變數 初始化為 0，
   參考型別 的 唯讀變數 初始值為 0，參考型別 的 唯讀變數 初始化值為 null 。






















