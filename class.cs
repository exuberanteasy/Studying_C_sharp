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


//=====================================================
//宣告方法
namespace TestProj_3
{
    class Circle
    {
        public int radius;                   
        public const float PI = 3.14F;       
        public static int count;             

        // 靜態方法
        public static void showPI()
        {
            Console.WriteLine(PI);
        }

        // 案例方法
        public void showArea(int r)
        {
            radius = r;
            Console.WriteLine(PI * radius * radius);
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(); 
            Circle.showPI();            //透過類別的名稱呼叫靜態方法
            c1.showArea(10);            //透過物件呼叫案例方法

            Console.ReadLine();
        }
    }
}

Q: 既然有 案例方法，為什麼還需要 靜態方法呢?

A: 有些類別可能提供了 一般用途的方法讓使用者呼叫，比方說，System命名空間 內的 Math類別 就提供了許多與數學運算相關的方法，
例如 
ads() → 可以取得絕對值、
pow() → 可以取得次方值、
Sqrt() → 可以取得平方根、
cos() → 指定角度餘弦函數、
sin() → 指定角度的正弦函數、
tan() → 指定角度的正切函數、

為了讓使用者呼叫，這些方法會設計成靜態方法，如此一來，使用者可以透過類別的名稱進行呼叫，而不必建立類別的物件。

Q: 隸屬於相同類別的每個物件也各自擁有一份案例方法嗎?
A: 不是。無論是案例方法或靜態方法，在記憶體內都只有一份拷貝供隸屬於相同類別的每個物件共用，C#有一套特殊的機制能夠加以處理。

Q: 靜態方法內的敘述可以直接存取案例變數嗎?
A: 不可以。雖然相同類別內的敘述可以直接存取案例變數、靜態變數或常數，無須建立類別的物件或指定類別的名稱，但也有例外，就是靜態方法內的敘述
   可以直接存取靜態變數或常數，但不能直接存取案例變數，必須建立類別的物件，理由很簡單，若使用者是透過類別的名稱呼叫靜態方法，
   沒有建立類別的物件，那麼將因為無法存取案例變數而產生編譯錯誤。



















