using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            #region 類型創建RegisterType
            ////像是自動產生new AutoFacManager();
            //builder.RegisterType<AutoFacManager>();
            ////碰到IPerson則進行new Worker動作
            //builder.RegisterType<Student>().As<IPerson>();
            #endregion

            #region 實體創建
            //builder.RegisterInstance<AutoFacManager>(new AutoFacManager(new Worker()));
            #endregion

            #region 單例 尚未研究
            //透過builder.RegisterInstance(MySingleton.GetInstance()).ExternallyOwned()
            #endregion

            #region Lambda表達式創建
            //builder.Register(c => new AutoFacManager(c.Resolve<IPerson>()));
            //builder.RegisterType<Worker>().As<IPerson>();
            #endregion

            #region 程序集創建 透過目前正在執行中的程式去找
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());//目前正在運行的程式去找
            //builder.RegisterType<Worker>().As<IPerson>();
            #endregion

            #region 泛型註冊
            //builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>)).InstancePerLifetimeScope();
            //using (IContainer container = builder.Build())
            //{
            //    IList<string> ListString = container.Resolve<IList<string>>();
            //}
            #endregion

            #region 註冊多次以最後註冊為主，或者使用設定將他為非默認

            builder.RegisterType<AutoFacManager>();
            builder.RegisterType<Worker>().As<IPerson>();
            builder.RegisterType<Student>().As<IPerson>().PreserveExistingDefaults();//指定為非默認
            #endregion



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

