using System;

namespace Extensions
{
    using NUnit.Framework.Constraints;

    /// <summary>
    /// Generic way of extending by using the inherent constraints
    /// </summary>
    public class DoubleConstraint : Constraint
    {
        private const double DefaultPrecision = 0.0001;

        public DoubleConstraint(double expected) : base(expected)
        {
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            return NUnit.Framework.Is.EqualTo(Arguments[0])
                .Within(DefaultPrecision).ApplyTo(actual);
        }
    }

    /// <summary>
    /// Option 2, which matches this case and similar
    /// </summary>
    public class DoubleVerification2 : EqualConstraint
    {
        private const double DefaultPrecision = 0.0001;

        public DoubleVerification2(double expected) : base(expected)
        {
            Within(DefaultPrecision);
        }
    }


    /// <summary>
    /// This extends the Is functionality
    /// </summary>
    public class Is : NUnit.Framework.Is
    {
        public static DoubleConstraint Approx(double expected)
        {
            return new DoubleConstraint(expected);
        }

        public static DoubleVerification2 Approx2(double expected)
        {
            return new DoubleVerification2(expected);
        }
    }


    /// <summary>
    /// This allows for chaining
    /// </summary>
    public static class Verifications
    {
        public static DoubleConstraint Approx(this ConstraintExpression expression, double expected)
        {
            var constraint = new DoubleConstraint(expected);
            expression.Append(constraint);
            return constraint;
        }


    }
}
