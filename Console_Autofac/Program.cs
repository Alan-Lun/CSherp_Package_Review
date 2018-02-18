using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Console_Autofac
{
    class Program
    {
        //ContainerBuilder 作用
        //ContainerBuilder 主要將所有元件的實體通過他來註冊

        //元件
        //實體需要從元件中來獲取, 比如某些類的實體就需要從元件中獲取

        //哪些實體可以當作元件
        //Lambda表達式
        //一個class
        //一個預編譯的實體
        //實體類型在的方法

        //容器
        //ContainerBuilder的Build()方法可以建立，而容器的Resolve()方法能夠獲得對象

        //為了指定元件服務是某一接口
        //As()方法將用於註冊時之指定

        //組件的依賴關係
        //相依關係通過介面實現

        static void Main(string[] args)
        {
            //建立對應中介
            ContainerBuilder builder = new ContainerBuilder();
            //像是自動產生new AutoFacManager();
            builder.RegisterType<AutoFacManager>();
            //碰到IPerson則進行new Worker動作
            builder.RegisterType<Student>().As<IPerson>();
            //執行上述建立動作
            using (IContainer container = builder.Build())
            {
                //產生出此對應方法
                AutoFacManager manager = container.Resolve<AutoFacManager>();
                Console.WriteLine(manager.Say());
                Console.Read();
            }
        }
    }

    public interface IPerson
    {
        string Say();
    }

    public class Worker : IPerson
    {
        public string Say()
        {
            return "Worker";
        }
    }

    public class Student : IPerson
    {
        public string Say()
        {
            return "Student";
        }
    }

    public class AutoFacManager
    {
        private readonly IPerson _person;

        public AutoFacManager(IPerson person)
        {
            this._person = person;
        }

        public string Say()
        {
            return this._person.Say();
        }
    }

}

