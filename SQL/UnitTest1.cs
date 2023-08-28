
namespace L2Task4
{  
    public class Tests
    {
         
        [Test]
        public void Test1()
        {  
            DataUtils.ConnectToDataBase(DataUtils.FirstQuery);
        }


        [Test]
        public void Test2()
        {
            DataUtils.ConnectToDataBase(DataUtils.SecondQuery);
        }

        [Test]
        public void Test3()
        {
            DataUtils.ConnectToDataBase(DataUtils.ThirdQuery);
        }

        [Test]
        public void Test4()
        {
            DataUtils.ConnectToDataBase(DataUtils.FourthQuery);
        }

    }
}

