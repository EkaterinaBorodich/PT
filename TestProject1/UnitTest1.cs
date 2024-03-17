using CalculatorNamespace;
using System;
namespace CalculatorTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        CalculatorNamespace.Calculator calculator = new CalculatorNamespace.Calculator();

        int num1 = calculator.add(3, 5);

        Assert.AreEqual(8, num1);

        int num2=calculator.subtract(6,3); 
        
        Assert.AreEqual(3, num2);

        int num3=calculator.multiply(2,2); 
        
        Assert.AreEqual(4, num3);

        int num4=calculator.divide(4,2); 
        
        Assert.AreEqual(2, num4);

        try
        {
            int num5 = calculator.divide(3, 0);
        }
        catch (DivideByZeroException)
        {
            Console.Error.WriteLine("You can not devide by zero!");
        }
    }
}