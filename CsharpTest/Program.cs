//--------------------學習筆記------------------------
//Visual C# 2017程式設計經典
//----------------------------------------------------

using System; //引用命名空間，以便使用空間內的類別
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; //列舉器，提供GetEnumerator()
using System.IO; //可管理檔案系統

namespace MyNamespace
{
    class Program
    {
        public int Getint()
        {
            return 10;
        }
    }
}

namespace CsharpTest //命名空間：用來定義類別的範圍
{
    delegate void MyDelegate(string a); //委派型別，通常應用於事件(Event)處理上

    class MyClass {
        public int a;

        private int _b;
        public int b
        {
            get
            {
                return _b;
            }
            set
            {
                _b = value > 10 ? 10 : 1;
            }
        }

        public string c { get; set; } = "屬性初始值"; //自動屬性，編譯器會自動新增私有變數 => private string _c;
        public string d { get; } = "此屬性唯讀";
        protected string g { get; set; } = "這是g字串初始值"; //protected允許子類別存取

        public MyClass() { }
        public MyClass(int x) //建構式
        {
            a = x;
        }

        ~MyClass() //解構式
        {
            Console.WriteLine("解構式執行完成");
        }

        private string _e;
        public string e
        {
            get
            {
                return _e;
            }
            set
            {
                _e = value + " 建構式set";
                MyEvent(_e); //呼叫事件
            }
        }

        public event MyDelegate MyEvent; //MyDelegate委派型別下的事件
        public void DelegateFunction(string str)
        {
            Console.WriteLine("事件方法執行完畢");
        }

        public virtual void VirtualFun()
        {
            Console.WriteLine("執行MyClass類別的VirtualFun方法");
        }
    }

    class Myclass2 : MyClass
    {

        public void MyClass2Fun()
        {
            Console.WriteLine($"執行 MyClass2類別的a方法");
            Console.WriteLine($"呼叫MyClass類別的g字串:{g}");
        }

        public static int gg { get; set; }
        public Myclass2() //建構式
        {
            gg++;
        }

        public static void StaticFun()
        {
            Console.WriteLine("執行StaticFun方法");
            Console.WriteLine($"gg的數值累加:{gg}");
        }

        public override void VirtualFun()
        {
            base.VirtualFun(); //base關鍵字，可呼叫父類別的方法或屬性
            Console.WriteLine("上面第一行是MyClass2類別VitrualFun方法，使用base關鍵字呼叫父類別VirtualFun的結果");
        }
    }

    abstract class AbstractClass { //抽象類別
        public abstract void AbStractFun(); //抽象方法，無須實作程式碼
    }

    class MyClass3 : AbstractClass
    {
        public override void AbStractFun() //覆寫抽象方法
        {
            Console.WriteLine("這是 MyClass3類別 覆寫 AbstractClass抽象類別 的AbstractFun()抽象方法 再Console出來");
        }
    }

    interface IMyFace //介面命名開頭一律是"I"，以方便識別
    {
        string StrFun();
        int IntFun();
    }

    class FaceClass : IMyFace //FaceClass類別實作IMyFace介面
    {
        public string StrFun() {
            return ("這是 FaceClass類別 實作 IMyFace介面 的 StrFun方法");
        }

        public int IntFun() {
            return (5);
        }
    }

    delegate void delegatefun();

    class MyException : Exception //繼承Exception類別
    {
        public override string Message //覆寫Message屬性
        {
            get //唯讀屬性
            {
                return "這是MyException類別覆寫Exception類別的Message屬性";
            }
        }
    }

    class Program
    {
        //列舉(Enumeration)資料型別是常數的集合，不可定義在Main()裡面
        enum MyEnum : int
        {
            a = 1,
            b = 2,
        }

        //結構(Structrue)是數個不同資料型別的變數，集合在一個新的結構名稱下所構成的資料型別
        //使用前須先宣告
        struct MyStruct
        {
            public string a;
            public int b;
        }


        public static void MyRefFuntion(ref int a,ref int b)
        {
            a = 3;
            b = 4;
        }

        static void MyRefAraayFuntion(ref int[] a)
        {
            Array.Reverse(a);
            for(int b = 0;b < a.Length; b++)
            {
                Console.WriteLine(a[b]);
            }
        }

        static void MyOutFunction(out string a,out string b)
        {
            a = "C";
            b = "D";
        }

        static void MyOutFunction(out int a)
        {
            a = 5;
        }

        static void Fun()
        {
            Console.WriteLine("123");
        }

        //static：可不用先建立方法的物件實體，就能直接使用
        //void：表示此方法不會回傳任何值
        static void Main(string[] args) //程式執行的起始點
        {
            //const int constant = 1; //const宣告常數

            //---------------------實質型別 and 參考型別---------------------
            //實質型別：存放在堆疊區(Stack)
            //          數值型別、結構struct型別、列舉enum型別

            //參考型別：存放在堆積區(Heap)，屬間接存取資料
            //          字串型別、定義類別、委派、陣列(含陣列元素)、介面的型別
            //---------------------------------------------------------------

            //逸出序列(Escape Sequence) \' => 插入一個單引號

            //---------------------結構陣列---------------------
            //MyStruct[] myStructs = new MyStruct[]0
            //{
            //    new MyStruct(){a = "1",b = 2},
            //    new MyStruct(){a = "2",b = 4}
            //};
            //Console.WriteLine(myStructs[1].a);
            //--------------------------------------------------

            //---------------------引數傳遞---------------------
            //傳值呼叫：占用不同記憶體位址

            //參考呼叫：占用相同記憶體位址
            //int a = 1, b = 2;
            //MyRefFuntion(ref a, ref b);
            //Console.WriteLine($"{a}{b}");

            //傳遞陣列，ref可忽略
            //int[] a = new int[] {1,2,3};
            //MyRefAraayFuntion(ref a);
            //for (int b = 0; b < a.Length; b++)
            //{
            //    Console.WriteLine(a[b]);
            //}

            //傳出參數：占用相同記憶體位址，可不必設定初始值
            //string a,b;
            //MyOutFunction(out a,out b);
            //Console.WriteLine($"{a}{b}");
            //--------------------------------------------------

            //---------------------命名空間(Namespace)---------------------
            //可具有子命名空間
            //MyNamespace.Program program = new MyNamespace.Program();
            //Console.WriteLine(program.Getint());
            //-------------------------------------------------------------

            //---------------------建立屬性(property)---------------------
            //直接在類別中宣告public變數
            //MyClass myClass = new MyClass();
            //myClass.a = 10;
            //Console.WriteLine(myClass.a);

            //使用存取子：可控制屬性的設定
            //使用get及set存取子優點：可隱藏實作和驗證程式碼，達到物件導向資料封裝
            //MyClass myClass = new MyClass();
            //myClass.b = 20;
            //Console.WriteLine($"將數值set為{myClass.b}");
            //Console.WriteLine($"{myClass.c}");
            //Console.WriteLine(myClass.d);
            //-------------------------------------------------------------

            //---------------------方法多載(Overloading)---------------------
            //string a,b;
            //int c;
            //MyOutFunction(out a,out b);
            //MyOutFunction(out c);
            //---------------------------------------------------------------

            //---------------------建構(Constructor)函式與解構(Destructor)函式---------------------
            ////建構式：建立物件時用來做物件初始化的工作。允許多個建構式。
            //MyClass myClass = new MyClass(30); 
            //Console.WriteLine(myClass.a);

            ////解構式：當物件消滅時才會執行。只能有一個解構式。
            //myClass = null;
            //GC.Collect();
            //Console.WriteLine("GC執行完畢");

            //物件初始設定式
            //MyClass myClass = new MyClass {a = 5,c = "123"};
            //Console.WriteLine($"{myClass.a}{myClass.c}");
            //-------------------------------------------------------------------------------------

            //---------------------事件(Event)---------------------
            //delegate型別可以呼叫物體(執行個體)的方法，以傳回特定資訊
            //MyClass myClass = new MyClass();
            //myClass.MyEvent += new MyDelegate(myClass.DelegateFunction); //將事件導向事件方法
            //myClass.e = "GGG";
            //Console.WriteLine(myClass.e);
            //-----------------------------------------------------

            //---------------------繼承---------------------
            //被繼承的類別稱為基底類別(Base Class)、父類別(Parent Class)、超類別(Super Class)
            //繼承的類別稱為衍生類別(Derived Class)、子類別(Child Class)、次類別(Sub Class)
            //Myclass2 myclass2 = new Myclass2();
            //myclass2.MyClass2Fun();
            //----------------------------------------------

            //---------------------靜態成員(static)---------------------
            //不需要透過new敘述來建立物件實體，就可直接透過類別來使用
            //static方法只能存取類別中定義的static成員，不能存取非static成員
            //Myclass2 f1 = new Myclass2(); //觸發Myclass2建構式,gg++
            //Myclass2.StaticFun();
            //Myclass2 f2 = new Myclass2();
            //Myclass2.StaticFun();
            //---------------------靜態成員(static)---------------------

            //---------------------多型(Polymorphism)---------------------
            //「多型」又稱同名異式，透過動態繫結(Dynamic Binding)的方式，讓程式在執行中可動態絕對物件參考所需的方法
            //將方法或屬性宣告為vitrual：讓子類別覆寫
            //將方法或屬性宣告為override：表示要重新定義父類別的方法
            //base關鍵字，可呼叫父類別的方法或屬性
            //Myclass2 myclass2 = new Myclass2();
            //myclass2.VirtualFun();

            //父類別的參考可以動態指向同一類別的物件實體或子類別的物件實體
            //MyClass myClass; //myClass是MyClass類別的物件參考
            //Myclass2 myclass2 = new Myclass2();
            //myClass = myclass2; //myClass參考指向myclass2物件實體，或讓它指向其他的子類別，以達到動態繫結
            //myClass.VirtualFun();
            //------------------------------------------------------------

            //---------------------抽象類別---------------------
            //無法使用new關鍵字建立實體物件，可定義抽象方法或存取子
            //使用abstract修飾詞
            //抽象方法不包含實作程式碼，因此必須在繼承的子類別中以override(覆寫)修飾詞定義新的方法功能
            //MyClass3 myClass3 = new MyClass3();
            //myClass3.AbStractFun();
            //--------------------------------------------------

            //---------------------介面(Interface)---------------------
            //介面焦點是放在操作物件；類別繼承則是著重屬性與方法的重複使用
            //介面只負責宣告，且成員會自動為public
            //FaceClass faceClass = new FaceClass();
            //Console.WriteLine(faceClass.StrFun());
            //Console.WriteLine(faceClass.IntFun());
            //---------------------------------------------------------

            //---------------------delegate委派型別---------------------
            //用來儲存方法位址的資料型別
            //delegatefun d = new delegatefun(Fun); //將委派變數指向Fun()方法
            //d();
            //透過指向不同的方法，可達到動態繫結
            //----------------------------------------------------------

            //---------------------List泛型類別---------------------
            //集合物件是一組相關物件的集合，可將這組物件的集合視為單一物件
            //常用的集合物件：Collection、List、Set、Map
            //常用的泛型類別：List、Queue、Stack
            //List<MyClass> listMyClass = new List<MyClass>();
            //listMyClass.Add(new MyClass() { a = 1, c = "ListAdd1" });
            //listMyClass.Add(new MyClass() { a = 2, c = "ListAdd2" });

            //listMyClass.RemoveAt(0); //刪除索引值0的物件
            //listMyClass.Insert(0,new MyClass() {a = 3,c = "ListInsert"}); //插入物件於索引值0

            //for (int i = 0; i < listMyClass.Count; i++)
            //{
            //    Console.WriteLine($"{listMyClass[i].a}{listMyClass[i].c}");
            //}
            //------------------------------------------------------

            //---------------------列舉器(Enumerator)---------------------
            //IEnumerator介面支援非泛型集合上的簡單反覆運算
            //string[] array1 = new string[] {"零","一","二","三","四","五"};
            //IEnumerator enumerator = array1.GetEnumerator(); //實作列舉器，並透過GetEnumerator()方法來讀取araay1陣列
            //while ((enumerator.MoveNext()) && (enumerator.Current != null))
            //{
            //    Console.WriteLine($"現在指標內容為:{enumerator.Current}");
            //}
            //enumerator.Reset(); //Reset回集合物件第一個元素的前面，此位置並無Current值
            //enumerator.MoveNext();
            //Console.WriteLine($"經過Reset()，和一次的MoveNext()，指標內容為:{enumerator.Current}");
            //------------------------------------------------------------

            //---------------------泛型與非泛型集合類別---------------------
            //泛型類別和方法具有重複使用性、型別安全、高效率
            //非泛型定義於System.Collections命名空間，包括ArrayList、Stack、Hashtable、SortedList...
            //泛型定義於System.Collections.Generic命名空間，包括List<T>、LinkedList<T>、Stack<T>、Queue<T>...
            //--------------------------------------------------------------

            //---------------------ArrayList與List<T>集合類別實作---------------------
            //泛型不須強制轉換
            List<MyClass> listMyClass = new List<MyClass>();
            listMyClass.Add(new MyClass() { a = 1, c = "ListAdd1" });
            listMyClass.Add(new MyClass() { a = 2, c = "ListAdd2" });
            foreach (var item in listMyClass)
            {
                Console.WriteLine($"{item.a}{item.c}");
            }

            //非泛型需強制轉換
            ArrayList arrayList = new ArrayList();
            arrayList.Add(new MyClass() { a = 1, c = "ListAdd1" });
            arrayList.Add(new MyClass() { a = 2, c = "ListAdd2" });

            foreach (var item in arrayList)
            {
                Console.WriteLine(item.ToString()); //可透過在MyClass覆寫ToSstring方法，return回該item的內容
            }
            //-------------------------------------------------------------------------

            //---------------------Stack與Stack<T>集合類別實作---------------------
            //堆疊，後進先出(Last In First:LIFO)
            Stack<MyClass> myClasses = new Stack<MyClass>();
            myClasses.Push(new MyClass() { a = 1, c = "Stack1" });
            myClasses.Push(new MyClass() { a = 2, c = "Stack2" });
            Console.WriteLine(myClasses.Peek().c); //傳回堆疊中最上面的物件
            foreach (var item in myClasses)
            {
                Console.WriteLine($"{item.a}{item.c}");
            }

            Stack stack = new Stack();
            MyClass myClass = new MyClass() { a = 1, c = "Stack1" };
            stack.Push(myClass);
            stack.Push(new MyClass() { a = 2, c = "Stack2" });
            if (stack.Contains(myClass))
                Console.WriteLine("stack堆疊內容有myClass物件");
            else
                Console.WriteLine("stack堆疊內容無myClass物件");
            //----------------------------------------------------------------------

            //---------------------Queue與Queue<T>集合類別實作---------------------
            //佇列，先進先出(First In First Out:FIFO)
            //Queue<MyClass> myClasses = new Queue<MyClass>();
            //myClasses.Enqueue(new MyClass() { a = 1,c = "Queue1"});
            //myClasses.Enqueue(new MyClass() { a = 2, c = "Queue2" });
            //Console.WriteLine("Peek()傳回最先存入之物件" + myClasses.Peek().c);
            //foreach(var item in myClasses)
            //{
            //    Console.WriteLine($"{item.a}{item.c}");
            //}

            //Queue queue = new Queue();
            //queue.Enqueue(new MyClass() { a = 1, c = "Queue1" });
            //queue.Enqueue(new MyClass() { a = 2, c = "Queue2" });
            //queue.Dequeue();
            //Console.WriteLine(queue.Peek());
            //----------------------------------------------------------------------

            //---------------------Hashtable與Dictionary<TKey,TValue>集合類別實作---------------------
            //屬於關聯陣列(Associative Array)
            //Dictionary<string, MyClass> dictionary = new Dictionary<string, MyClass>();
            //dictionary.Add("Key1", new MyClass() { a = 1, c = "Dictionary1" });
            //dictionary.Add("Key2", new MyClass() { a = 2, c = "Dictionary2" });
            //dictionary["Key3"] = new MyClass() { a = 2, c = "Dictionary3" };
            //foreach (KeyValuePair<string,MyClass> item in dictionary) //也可用var
            //{
            //    Console.WriteLine($"{item.Key}:{item.Value.a}{item.Value.c}");
            //}

            //Hashtable hashtable = new Hashtable();
            //hashtable.Add("Key1", new MyClass() { a = 1, c = "hashtable1" });
            //hashtable.Add("Key2", new MyClass() { a = 1, c = "hashtable2" });
            //hashtable["Key3"] = new MyClass() { a = 2, c = "hashtable3" };
            //Console.WriteLine(hashtable["Key1"]);

            //foreach (DictionaryEntry item in hashtable) //也可用 KeyValuePair<string,MyClass>
            //{
            //    Console.WriteLine(item.Key);
            //}
            //---------------------------------------------------------------------------------------

            //---------------------SortedList與SortedList<TKey,TValue>---------------------
            //SortedList<int, MyClass> pairs = new SortedList<int, MyClass>();
            //pairs.Add(2, new MyClass() { a = 1, c = "hashtable1" });
            //pairs.Add(1, new MyClass() { a = 2, c = "hashtable2" });
            //Console.WriteLine(pairs[1].a);
            //foreach(var item in pairs)
            //{
            //    Console.WriteLine($"{item.Key}:{item.Value.a}{item.Value.c}");
            //}


            //SortedList list = new SortedList();
            //list.Add(2, new MyClass() { a = 1, c = "hashtable1" });
            //list.Add(1, new MyClass() { a = 1, c = "hashtable1" });
            //----------------------------------------------------------------------------

            //---------------------try 例外處理(Exception Handle)語法---------------------
            //try
            //{
            //    int a = 5;
            //    int b = a / 0;
            //}
            //catch(Exception ex) //可以捕捉所有例外
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally //不論是否有執行catchStatements都會執行finallyStatements
            //{
            //    Console.WriteLine("執行finally區塊");
            //}
            //-----------------------------------------------------------------------------

            //---------------------例外類別---------------------
            //try
            //{
            //    string[] vs = new string[] { "0", "1", "2" };
            //    Console.WriteLine(vs[3]);
            //}
            //catch (ArgumentOutOfRangeException ex) //當引數值超過呼叫方法所規定的範圍
            //{
            //    Console.WriteLine("ArgumentOutOfRangeException");
            //}
            //catch (DivideByZeroException ex) //當除數為0時所產生的錯誤
            //{
            //    Console.WriteLine("DivideByZeroException");
            //}
            //catch(IndexOutOfRangeException ex) //索引值超出陣列所允許的範圍
            //{
            //    Console.WriteLine("IndexOutOfRangeException");
            //    Console.WriteLine($"例外處理ex的型別:{ex.GetType()}");
            //    Console.WriteLine($"例外ex的錯誤訊息:{ex.Message}");
            //    Console.WriteLine($"發生例外的程式:{ex.Source}");
            //    Console.WriteLine($"發生例外的方法是:{ex.TargetSite.Name}");
            //    Console.WriteLine($"錯誤之處:{ex.StackTrace}");
            //}
            //finally
            //{
            //    Console.WriteLine("執行finally區塊");
            //}
            //-------------------------------------------------

            //---------------------自訂例外處理---------------------
            //使用throw敘述
            //可new一個例外處理類別，或是自己定一個新類別使用
            //try
            //{
            //    int a = 5;
            //    throw new ArgumentOutOfRangeException();
            //}
            //catch (ArgumentOutOfRangeException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //finally //不論是否有執行catchStatements都會執行finallyStatements
            //{
            //    Console.WriteLine("執行finally區塊");
            //}
            //-------------------------------------------------------

            //---------------------例外類別繼承---------------------
            //try
            //{
            //    int a = 5;
            //    throw new MyException();
            //}
            //catch (MyException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally //不論是否有執行catchStatements都會執行finallyStatements
            //{
            //    Console.WriteLine("執行finally區塊");
            //}
            //--------------------------------------------------------

            //---------------------DirectoryInfo類別---------------------
            //using System.IO;
            //目錄相關資訊類別主要用來建立資料夾和搬移資料夾的工作
            //Directory和DirectoryInfo，前者為靜態方式
            //DirectoryInfo info = new DirectoryInfo(@"C:\Users\hankh\Desktop\test");
            //if (info.Exists)
            //    Console.WriteLine("存在");
            //else
            //{
            //    Console.WriteLine("不存在 \n 開始建立資料夾");
            //    info.Create();
            //    info.Refresh();
            //}

            //Console.WriteLine($"資料夾路徑:{info.FullName}");
            //Console.WriteLine($"建立時間:{info.CreationTime}");
            //Console.WriteLine($"最後存取時間:{info.LastAccessTime}");
            //Console.WriteLine($"資料夾名稱:{info.Name}");
            //Console.WriteLine($"根目錄:{info.Parent}");

            //Console.WriteLine("刪除資料夾");
            //try
            //{
            //    info.Delete(true); //參數true，代表刪除其下所有檔案和目錄
            //    Console.WriteLine("刪除成功");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //---------------------DirectoryInfo類別---------------------

            //---------------------FileInfo類別---------------------
            //File、FileInfo，前者為靜態方式
            //DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\hankh\Desktop\CsharpTest");
            //if (directoryInfo.Exists)
            //{
            //    Console.WriteLine("資料夾存在");
            //    FileInfo[] fileInfo = directoryInfo.GetFiles(); //取得資料夾內的檔案，傳回fileInfo陣列
            //    foreach (FileInfo file in fileInfo)
            //    {
            //        Console.WriteLine($"檔案路徑:{file.FullName}");
            //        Console.WriteLine($"最近寫入時間:{file.LastWriteTime}");
            //        Console.WriteLine($"檔案大小:{file.Length} Bytes");
            //    }
            //}
            //---------------------FileInfo類別---------------------

            //---------------------檔案讀寫---------------------
            ////新增
            //if(!File.Exists(@"C:\Users\hankh\Desktop\CsharpTest\test.txt"))
            //{
            //    try
            //    {
            //        File.Create(@"C:\Users\hankh\Desktop\CsharpTest\test.txt").Close();
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //}

            ////寫入
            //FileInfo fileInfo = new FileInfo(@"C:\Users\hankh\Desktop\CsharpTest\test.txt");
            //StreamWriter streamWriter = fileInfo.AppendText(); //可將資料寫入在檔案最後面
            //streamWriter.WriteLine("這是streamWriter物件寫入的1");
            //streamWriter.WriteLine("這是streamWriter物件寫入的2");
            //streamWriter.Flush(); //將存在Buffer緩衝區的資料寫入檔案
            //streamWriter.Close(); //關閉資料流
            //Console.WriteLine("資料寫入完畢");

            ////讀出
            //StreamReader reader = fileInfo.OpenText();
            //while (reader.Peek() >= 0) //回傳-1表示檔案結束
            //{
            //    Console.WriteLine(reader.ReadLine()); //讀取一行
            //    Console.WriteLine("---------");
            //}
            //reader.Close();

            ////刪除
            //fileInfo.Delete();
            //Console.WriteLine("刪除成功"); //讀取一行
            //---------------------------------------------------------

            Console.Read();
        }
    }
}
