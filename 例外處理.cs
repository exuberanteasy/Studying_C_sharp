debugging

※ 語法錯誤

※ 執行期間錯誤

※ 邏輯錯誤
   邏輯錯誤是最難修正的錯誤類型

當程式發生錯誤時，系統會根據不同的錯誤丟出不同的 exception(例外)，
Visual C#的例外均繼承自 System.Exception 類別，同時 System 命名空間提供了其他例外類別，

=> OverflowException ，表示數學運算導致溢位
=> DivideByZeroException ，表示除數為 0
=> UnauthorizeAcessException ，表示未經授權存取
=> 


//=======================================================
結構化例外處理


namespace MyProj6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamWriter file = null;
            try
            {
                file = new System.IO.StreamWriter(@"C:\file1.txt");
                file.WriteLine("Hello, world!");
            }
            catch(UnauthorizedAccessException e1)
            {
                System.Console.WriteLine("捕捉到UnauthorizeAccessException例外，錯誤訊息為 " + e1.Message);
            }
            catch
            {

            }
            finally
            {

            }
        }
    }
}
