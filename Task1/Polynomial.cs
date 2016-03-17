using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.Win32;

namespace Task1
{
    public sealed class Polynomial : IEquatable<Polynomial>
    {
        private readonly double[] Coefficients;
        private readonly int Degree;

        public Polynomial() : this(1, 2) {}

        public Polynomial(params double[] coefficients)
        {
            if(coefficients == null)
                throw new ArgumentException();

            Degree = coefficients.Length - 1;
            this.Coefficients = (double[])coefficients.Clone();
        }

        public double GetValue(double value) => Coefficients.Select((t, i) => Math.Pow(value, i) * t).Sum();
     
        public override string ToString()
            => string.Join(" + ", Coefficients.Select((t, i) => t.ToString() + "*x^" + i.ToString()));

        
        public static Polynomial Add(Polynomial polyn1, Polynomial polyn2)
        {
            if(polyn1 == null || polyn2 == null)
                throw new ArgumentException();
                
            return new Polynomial(polyn1.Coefficients.Zip(polyn2.Coefficients, (x, y) => x + y)
                                                     .ToArray());
        }

        public Polynomial Add(Polynomial polyn2) => Add(this, polyn2);

        public static Polynomial Subtract(Polynomial polyn1, Polynomial polyn2)
        {
            if (polyn1 == null || polyn2 == null)
                throw new ArgumentException();

            return new Polynomial(polyn1.Coefficients.Zip(polyn2.Coefficients, (x, y) => x - y)
                                                     .ToArray());
        }

        public Polynomial Subtract(Polynomial polyn2) => Subtract(this, polyn2);

        public static Polynomial Multiply(Polynomial polyn1, Polynomial polyn2)
        {
            int newDegree = polyn1.Degree + polyn2.Degree;
            double[] resultCoeffs = new double[newDegree + 1];
           
            for (int i = polyn1.Degree; i >= 0; i--)
                for (int j = polyn2.Degree; j >= 0; j--)
                    resultCoeffs[i + j] += polyn1.Coefficients[i] * polyn2.Coefficients[j];

            return new Polynomial(resultCoeffs);          
        }

        public Polynomial Multiply(Polynomial polyn2) => Multiply(this, polyn2);

        public static Polynomial operator +(Polynomial lpolyn, Polynomial rpolyn) => Add(lpolyn, rpolyn);

        public static Polynomial operator -(Polynomial lpolyn, Polynomial rpolyn) => Subtract(lpolyn, rpolyn);

        public static Polynomial operator *(Polynomial lpolyn, Polynomial rpolyn) => Multiply(lpolyn, rpolyn);

        public static bool operator !=(Polynomial lpolyn, Polynomial rpolyn)
        {
            if (object.Equals(null, lpolyn))
                return !object.Equals(null, rpolyn);
            return   !lpolyn.Equals(rpolyn);
        }

        public static bool operator ==(Polynomial lpolyn, Polynomial rpolyn)
        {
            if (object.Equals(null, lpolyn))
                return object.Equals(null, rpolyn);

            return   lpolyn.Equals(rpolyn);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;

            return this.Equals(obj as Polynomial);
        }

        public bool Equals(Polynomial other)
        {
            if (object.Equals(other, null))
                return false;

            return (Degree == other.Degree && Coefficients.SequenceEqual(other.Coefficients));
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
