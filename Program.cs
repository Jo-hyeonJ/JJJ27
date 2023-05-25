using static System.Console;
// using : namespace를 포함 시킨다.
// using static : 특정 클래스 내부를 포함시키겠다.
namespace JJJ27
{
    internal class Program
    {
        class Vector
        {
            public float x;
            public float y;
            public Vector(float x, float y)
            {
                this.x = x;
                this.y = y;
            }
        }

        class Vector3 : Vector
        {
            public float z;
            // this는 자신을 가르키지만 base는 상속 받은 부모 클래스를 가르킨다.
            public Vector3(float x, float y, float z) : base(x, y)
            {
                this.z = z;
            }
        }

        #region 모양
        class Shape
        {
            public string name;
            public float width;
            public float height;
        }
        class Circle : Shape
        { }
        class Triangle : Shape
        { }
        class Rect : Shape
        {}
        class Pentagon : Shape
        { }
        #endregion

        static string RemoveDuplicate(string str)
        {
            return string.Concat(str.Distinct());
        }


        static void Main(string[] args)
        {
            // C# 7 기능
            /*
            // 패턴 매칭
            // 어떤 대상의 특정 모양(패턴)을 가지고 테스트하는 것
            object[] data = { 1, 10, null, "ABCD", new Vector(3, 4), new Vector3(1,2,3)};

            // Is키워드
            // => 어떠한 데이터가 특정 자료형을 만족하는지 체크
            if (data[0] is int)
                Console.WriteLine($"data[0]은 int형이 맞다.");

            // 상수 패턴
            // = 특정 상수 값을 패턴으로써 체크하는 방법
            if (data[0] is 1)
                Console.WriteLine("data[0]은 1이 맞다.");

            // 예전에는 int형인지 선 검사 후에 int로 형변환 후 정수형 상수와 비교를 했어야했다.
            if (data[0] is int)
            {
                if ((int)data[0] == 1)
                    Console.WriteLine("data[0]은 1이 맞다.");
            }

            // 타입 패턴
            // => 객체가 해당 타입인지 혹은 파생 클래스인지 검사

            // data[5] 값이 Vector3 형식이라면 v변수가 참조한다.
            // 즉 캐스팅 단계가 생략된다.
            if (data[5] is Vector3 v)
            {
               Console.WriteLine($"{ v.x },{ v.y },{ v.z }");        
            }
            

            // switch 패턴 매칭
            List<Shape> shapelist = new List<Shape>();
            shapelist.Add(new Circle() { width =12, height = 14});
            shapelist.Add(new Triangle() { width =3, height = 9});
            shapelist.Add(new Rect() { width =5, height = 5});
            shapelist.Add(new Pentagon() { width =10, height = 7});

            // var 패턴 매칭
            // = when과 묶어서 유용하게 사용 가능하다.
            List<string> customerlist = new List<string>(new string[] {"고객A", "고객B", "고객C"});
            List<string> vipCustomerlist = new List<string>(new string[] { "고객D", "고객E" });

            string customer = "고객A";
            switch(customer)
            {
                case var target when (customerlist.Contains(target)):
                    Console.WriteLine("일반 고객");
                    break;
                case var target when (vipCustomerlist.Contains(target)):
                    Console.WriteLine("vip고객");
                    break;
                default:
                    Console.WriteLine("신규고객");
                    break;

            }
            */
            // 2교시
            /*
            // 튜플 타입(tuple)
            // => 복수개의 값을 리턴한다.

            // 변수를 선언해서 값을 받는 법
            (bool isSuccess, float share, float remain) = DivideTuple(10, 3);
            Console.WriteLine(isSuccess);
            Console.WriteLine(share);
            Console.WriteLine(remain);


            // var 형식으로 임시 자료형을 만들고 값을 받는 법
            var result = DivideTuple(99, 4);
            Console.WriteLine(result.isSuccess);
            Console.WriteLine(result.share);
            Console.WriteLine(result.remain);


            // 로컬 함수
            // => 함수 안에 함수를 집어넣는 법

            // out 키워드의 편의성
            // out 키워드로 값을 받아 올 때, 값을 받아옴과 동시에 변수 선언까지 겸한다.
            GetNumber(out int number);
            Console.WriteLine(number);

            // 받아오기 싫은 값은 _로 받아오지 않을 수 있다.
            Divide(10, 3, out _, out float re);

            // 자리수 분리자, 이진 리터럴 상수
            // _는 생략된다.
            long big = 1_213_232_122;
            long big2 = 0x_FF_FF;       // 16진수 0x
            long big3 = 0b_0000_0001;   // 2진수 0b

            // 참조 변수를 선언하고 생성자를 이용해 인스턴스
            Player player = new Player("개발자", 999, new Vector (300, -20));

            // 디컨스트럭터를 이용해 데이터를 받아옴
            var (name, level) = player;
*/

            WriteLine("using static을 활용하여 편리하게 사용가능");
            // 다만 명칭의 혼용을 주의해야한다.


            // 문자열을 받고 중복된 문자를 제거 한 후 반환하라
            string str = "AAAA AAAA AAAA AB";
            Console.WriteLine(RemoveDuplicate(str));


            // int 배열 array안에서 num과 가장 가까운 수를 리턴
        }

        // 자릿수 숫자 구해오기
        static int GetDigit(int value, int digit)
        {
            string str = value.ToString();
            char c = str.Reverse().ToArray()[digit - 1];
            return int.Parse(c.ToString());
        }

        // a와 b를 받아 나누고 몫과 나머지를 리턴하는 함수
        static bool Divide(int a, int b, out float share, out float remain)
        {
            if (b == 0)
            {
                share = 0;
                remain = 0;
                return false;
            }

            share = a / b;
            remain = a % b;
            return true;
        }
        // 복수의 값을 리턴하기 위해 (소괄호)에 자료형을 넣는다. 이때 var을 활용하기 편하게 명칭을 명명할 수 있다.
        static (bool isSuccess, float share, float remain) DivideTuple(float a, float b)
        {
            try
            {
                return (true, a / b, a % b);
            }
            catch
            {
                return (false, 0f, 0f);
            }


        }

        static void FuncShape(Shape shape)
        {
            // switch 패턴 매칭
            switch(shape)
            {
                case null:
                    Console.WriteLine("null");
                    break;
                case Circle circle:
                    Console.WriteLine("써클");
                    break;
                case Triangle triangle:
                    Console.WriteLine("삼각형");
                    break;
                // when 추가 조건문으로 정사각형 조건문 작성
                case Rect rect when rect.width == rect.height :
                    break;
                case Rect rect:
                    break;

                default:
                    Console.WriteLine("알수없다.");
                    break;
            }
        }

        static void Calculate()
        {
            float value = 0f;

            Test1();
            Test2();

            // 로컬 함수
            // => 함수 안에 함수를 집어넣는 법

            // Calculate 내부에서만 사용 가능한 로컬 함수
            // 외부에서 이 함수를 사용 할 수 없는 것은 물론이고, 값의 송수신까지 (ref, 매개변수의 활용 없이) 간편하게 가능하다.
            // 함수 내부 요소로 취급 되기 때문에 (로컬)함수 이름 명명의 자유도 또한 넓어진다.
            static void Test1()
            {

            }
            static void Test2()
            {

            }
            // 같은 이름의 함수 부르는 법
            Program.Test1();
        }
        static void Test1()
        {

        }

        static void GetNumber(out int num)
        {
            num = 10;

        }

        // 소멸자 Destructor
        // = 객체가 메모리 해제될 때 호출 되는 함수

        // 해체자 Deconstructor
        // = 생성자와 반대의 개념

        class Player
        {
            string name;
            int level;
            Vector position;
            public Player(string name, int level, Vector position)
            {
                this.name = name;
                this.level = level;
                this.position = position;
            }
            public void Deconstruct(out string name, out int level)
            {
                name = this.name;
                level = this.level;
            
            }


            // 소멸자
            // 메모리가 해제 될 때 호출 되는 함수이다.
            // C#에서는 메모리 해제를 인위적으로 할 수가 없기에 잘 사용되지 않는다.
            ~Player()
            {


            }
        }


    }
}