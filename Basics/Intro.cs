// string firstFriend = "Maria5";
// string secondFriend = "Sage";
// Console.WriteLine($"The name {firstFriend} has {firstFriend.Length} letters.");
// Console.WriteLine($"The name {secondFriend} has {secondFriend.Length} letters.");
// string sayHello = "Hello World!";
// Console.WriteLine(sayHello);
// sayHello = sayHello.Replace("Hello", "Greetings");
// Console.WriteLine(sayHello);
// int a = 7;
// int b = 4;
// int c = 3;
// int d = (a + b) / c;
// int e = (a + b) % c;
// Console.WriteLine($"quotient: {d}");
// Console.WriteLine($"remainder: {e}");
// using System.Text;

// String name = 'a';
// float radius = 2.5;
// float area = MathF.PI * radius * radius;
// Console.WriteLine(area);

// int sum = 0;
// for (int i=0; i<20; i++)
// {
//     if(i%3 == 0)
//     {
//         sum += i;
//         Console.WriteLine(sum);
//     }
// }

// List<string> names = ["<name>", "Ana", "Felipe"];
// foreach (var name in names)
// {
//     Console.WriteLine($"Hello {name}!");
// }

// class Program
// {
//     static void swapping(ref int a,ref int b)
//     {
//         a +=b;
//         b = a-b;
//         a -= b;
//     }
//     static void Main()
//     {
        
//         int a = 4;
//         int b = 5;

//         Console.WriteLine(a);
//         Console.WriteLine(b);


//         swapping(ref a, ref b);
//         Console.WriteLine(a);
//         Console.WriteLine(b);
//     }

// }

// }

// namespace Coding.Exercise
// {
//     public class Exercise
//     {
        
//         static void Main(){
//             int employeeId = 20;
//             string companyName = "UTCLI";
//             Console.WriteLine("Hello, my employee ID is " + employeeId + " and my company name is  " + companyName);
//             Console.WriteLine("Hello, my employee ID is {0} and my company name is  {1}",employeeId,companyName);
//             Console.WriteLine($"Hello, my employee ID is {employeeId} and my company name is  {companyName}");
//         }
        
//     }
// }

// namespace Coding.Exercise
// {
//     public class Exercise
//     {
        
//         static void Main(){
//             Console.Write("Enter number: ");
//             string input = Console.ReadLine();
//             int num = Convert.ToInt32(input);

//             string result = num switch
//             {
//                1 => "One",
//                2 => "Two",
//                _ => "Other"
//             };
//             Console.WriteLine($"{result}");
//         }
        
//     }
// }

// namespace Coding.Exercise
// {
//     public class Exercise
//     {
//         static void Main()
//         {
//             Console.WriteLine("Enter Num");
//             int n = int.Parse(Console.ReadLine());
//             Console.WriteLine("Enter deNum");
//             int den = int.Parse(Console.ReadLine());
//             try
//             {
//                 int result = n/den;
//             }
//             catch
//             {
//                 Console.WriteLine("The denominator is zero");
//             }
//             finally
//             {
//                 Console.WriteLine("Finally block");
//             }
//             //Console.WriteLine($"{result}");
//         }
//     }
// }

// namespace Coding.Exercise
// {
//     public class Exercise
//     {
//         static void Main(string[] args){
//             Run();
//         }
        
//         static void Run(){
//             Console.WriteLine("Enter number of elements you want to enter");
//             int size = int.Parse(Console.ReadLine());
//             int[] arr = new int[size];

//             for(int i=0; i<arr.Length; i++)
//             {
//                 Console.WriteLine($"Enter element {i+1}");
//                 arr[i] = int.Parse(Console.ReadLine());
//             }

//             Console.WriteLine($"Sum of elements {FindSum(arr)}");
//             Console.WriteLine($"Average of elements {FindAverage(arr)}");
//         }
//         static int FindSum(int[] arr){
//             int sum = 0;
//             foreach(int num in arr)
//             {
//                 sum += num;
//             }
//             return sum;
//         }
//         static int FindAverage(int[] arr){
//             int sum = FindSum(arr);
//             int avg = sum/arr.Length;
//             return avg;
//         }
//     }
// }
