using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;
namespace Task2.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        [TestCase(2, Result = 17d)]
        [TestCase(1, Result = 4)]
        public double Polynomial_Value_getResult(double value)
        {
            double[] num = {1, 0, 2, 1};
            Polynomial polyn = new Polynomial(num);

            num[0] = 25;
            Debug.WriteLine(polyn.ToString());

            return polyn.GetValue(value);
            
        }

        [Test]
        [TestCase(new double[] {1, 2, 3}, new double[] { 1, 2, 3 }, Result = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 3, 2}, Result = false)]
        [TestCase(new double[] { 5, 7, 4 }, new double[] { 4, 7, 5 }, Result = false)]
        [TestCase(new int[] { 1, 2, 3 }, null, ExpectedException = typeof(ArgumentException))]
        public bool Polynominal_Comparing(double[] coefs1, double[] coefs2)
        {
            Polynomial polyn1 = new Polynomial(coefs1);
            Polynomial polyn2 = new Polynomial(coefs2);
            return polyn1.Equals((object)polyn2);
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, Result = true)]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 3, 2 }, Result = false)]
        [TestCase(new double[] { 5, 7, 4 }, new double[] { 4, 7, 5 }, Result = false)]
        [TestCase(new double[] { 5, 7, 4 }, new double[] { 4, 7, 5 }, Result = false)]
        [TestCase(new int[] { 1, 2, 3 }, null, ExpectedException = typeof(ArgumentException))]
        public bool Polynominal_ComparingWithOperators(double[] coefs1, double[] coefs2)
        {
            Polynomial polyn1 = new Polynomial(coefs1);
            Polynomial polyn2 = new Polynomial(coefs2);
            return polyn1 == polyn2;
        }

        [Test]
        public void Polynominal_ComparingNullWithEqualOperator()
        {
            Polynomial polyn1 = null;
            Polynomial polyn2 = new Polynomial(1, 2, 3);
            Assert.AreEqual(false, polyn1 == polyn2); ;
        }

        [Test]
        public void Polynominal_ComparingPolynomialWithNull()
        {
            Polynomial polyn1 = null;
            Polynomial polyn2 = new Polynomial(1, 2, 3);
            Assert.AreEqual(false, polyn1 == polyn2); ;
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 2, 4, 6 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4 }, new double[] { 2, 4, 6 })]
        [TestCase(new double[] { 2, 2, 3, 1, 8 }, new double[] { 1, 2, 3, 4 }, new double[] { 3, 4, 6, 5 })]
        public void Polynominal_Add(double[] coefs1, double[] coefs2, double[] expectedCoefs)
        {
            Polynomial polyn1 = new Polynomial(coefs1);
            Debug.WriteLine(polyn1);
            Polynomial polyn2 = new Polynomial(coefs2);
            Polynomial expected = new Polynomial(expectedCoefs);

            Polynomial res = polyn1 + polyn2;
            Debug.WriteLine(res);
            Assert.AreEqual(expected, res);
        }

        [Test]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 1, 2, 3 }, new double[] { 1, 1, 1 })]
        [TestCase(new double[] { 5, 6, 2 }, new double[] { 1, 2, 3, 4 }, new double[] { 4, 4, -1 })]
        public void Polynominal_Subtract(double[] coefs1, double[] coefs2, double[] expectedCoefs)
        {
            Polynomial polyn1 = new Polynomial(coefs1);
            Debug.WriteLine(polyn1);
            Polynomial polyn2 = new Polynomial(coefs2);
            Polynomial expected = new Polynomial(expectedCoefs);          
            
            Polynomial res = polyn1 - polyn2;
            Debug.WriteLine(res);
            Assert.AreEqual(expected, res);            
        }

        [Test]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3 }, new double[] { 1, 4, 10, 12, 9 })]
        public void Polynominal_Multiply(double[] coefs1, double[] coefs2, double[] expectedCoefs)
        {
            Polynomial polyn1 = new Polynomial(coefs1);
            Debug.WriteLine(polyn1);
            Polynomial polyn2 = new Polynomial(coefs2);
            Polynomial expected = new Polynomial(expectedCoefs);

            Polynomial res = polyn1 * polyn2;
            Debug.WriteLine(res);
            Assert.AreEqual(expected, res);
        }
    }
}
