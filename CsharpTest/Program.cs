//--------------------學習筆記------------------------
//Visual C# 2017程式設計經典
//----------------------------------------------------

using System; //引用命名空間，以便使用空間內的類別
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //listMyClass.Add(new MyClass() { a = 1,c = "ListAdd1"});
            //listMyClass.Add(new MyClass() { a = 2, c = "ListAdd2" });

            //listMyClass.RemoveAt(0);

            //for(int i = 0;i < listMyClass.Count; i++)
            //{
            //    Console.WriteLine($"{listMyClass[i].a}{listMyClass[i].c}");
            //}
            //------------------------------------------------------

            //---git test

            Console.Read();
        }
    }
}
