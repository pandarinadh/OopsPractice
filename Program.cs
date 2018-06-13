using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace OopsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassLibraryA objClassLibraryA = new ClassLibraryA();
            objClassLibraryA.MethodBinLibrary();


            A objectA = new A();
            //objectA.x error
            objectA.methodA();
            objectA.methodE();

            A objectB = new B();
            objectB.methodA();
            objectB.methodC();
            //objectB.methodD(); //error because protected status
            objectB.methodE();

            B objectB2 = new B(10);

            EventHandler mainHandler = new EventHandler();
            EventSubscriber eventSubscriber = new EventSubscriber();
            eventSubscriber.Subscribe(mainHandler);
            mainHandler.Start();

            LamdaClass lamdaClass = new LamdaClass();
            lamdaClass.LamdaMehtod(lamdaClass.myMethod);

            A objA = new A();
            objA.someNumber = 20;
            objA.SetToNull(ref objA);
            Console.WriteLine(objA == null);

            SingleTon.GetSingleTon();

            Console.WriteLine("singleton first {0}", SingleTon.GetSingleTon().GetHashCode());

            SingleTon.GetSingleTon();

            Console.WriteLine("singleton second {0}", SingleTon.GetSingleTon().GetHashCode());

            Car objCar = new Car();
            objCar.SetTires();
            Console.WriteLine("Car tires : {0}", objCar.NumberofTires);

            Truck objTruck = new Truck();
            objTruck.SetTires();
            Console.WriteLine("Truck tires : {0}", objTruck.NumberofTires);

            Console.ReadLine();
        }
    }

    abstract class classA
    {
        public abstract void methodE();

    }
    class A : classA
    {
        protected int x;
        public int someNumber = 10;
        public virtual void methodA()
        {
            Console.WriteLine("in virtual methodA in A");
        }

        public virtual void methodC()
        {
            Console.WriteLine("in virtual methodC in A");
        }

        protected virtual void methodD()
        {
            Console.WriteLine("in virtual methodD in A");
        }

        public override void methodE()
        {
            Console.WriteLine("in override methodE in A");
        }
        
        public void SetToNull(ref A a)
        {
            Console.WriteLine("in SetToNull in A "); 
            Console.WriteLine(a.someNumber);
            a = null;
        }

    }

    class B : A
    {
        readonly int intVar = 10;
        public B()
        {

        }
        public B(int myInt)
        {
            intVar = myInt;
        }
      
        public override void methodA()
        {
            Console.WriteLine(intVar);

            base.x = 10;
            Console.WriteLine("in override methodA in B");
        }

        public new void methodC()
        {
            Console.WriteLine("in override methodC in B");
           
        }

       protected override void methodD()
        {
            Console.WriteLine("in override methodD in B");
        }

        public override void methodE()
        {
            
            Console.WriteLine("in override methodE in B");
        }
    }

    public class EventHandler
    {
        public event MyEventHandler onRaiseEvent;

        public delegate void MyEventHandler(string s);

        public void Start()
        {
            if(onRaiseEvent != null)
            {
                onRaiseEvent("MyEvent");
            }
        }
    }

    public class EventSubscriber
    {
        public void Subscribe(EventHandler m)
        {
            m.onRaiseEvent += this.displayEvent;
        }

        private void displayEvent(string s)
        {
            Console.WriteLine(s);
        }
    }

    public class LamdaClass
    {
        public string myMethod()
        {
            Console.WriteLine("my method");
            return "";
        }
        public void LamdaMehtod(Func<string> method)
        {
            method();
        }

    }


    public class SingleTon
    {
        public static SingleTon singleTon = null;

        public static SingleTon GetSingleTon()
        {
            if (singleTon == null)
            {

                singleTon = new SingleTon();
            }

            return singleTon;
        }
    }

    public abstract class Vechicle
    {
        private int numberofTires;

        public abstract int SetTires();
       

        public int NumberofTires
        {
            get
            {
                return numberofTires;
            }

            set
            {
                numberofTires = value;
            }
        }
     }

    public class Car : Vechicle
    {
        public override int SetTires()
        {
            NumberofTires = 4;
            return NumberofTires;
        }
    }

    public class Truck : Vechicle
    {
        public override int SetTires()
        {
            NumberofTires = 10;
            return NumberofTires;
        }
    }

}
