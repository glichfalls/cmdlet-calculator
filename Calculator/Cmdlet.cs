using System.Management.Automation;

// Import-Module "C:\Users\robin\source\repos\Calculator\Calculator\bin\Debug\Calculator.dll"
// Import-Module "Z:\5. Semester\Skriptingtechnologien\glichfalls\cmdlet-calculator\Calculator\bin\Debug\Calculator.dll" -verbose

namespace Calculator
{
    public abstract class CalculationCmdlet : Cmdlet
    {
        [Parameter(ValueFromPipeline = true)]
        public float NumberPiped { get; set; }
        [Parameter(Position = 0, Mandatory = true)]
        public float NumberOne { get; set; }
        [Parameter(Position = 1)]
        public float NumberTwo { get; set; }

        protected abstract float GetResult(float n1, float n2);

        protected override void ProcessRecord()
        {
            WriteObject(
                NumberPiped != 0 
                    ? GetResult(NumberPiped, NumberOne) 
                    : GetResult(NumberOne, NumberTwo)
            );
        }

    }

    /// <summary>
    /// <para type="synopsis">This is a function from the Calculator library.</para>
    /// <para type="description">This cmdlet lets you add two numbers together.</para>
    /// <para type="description">It is possible to use multiple commands with pipelines.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Sum")]
    public class GetSumCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 + n2;
        }
    }

    /// <summary>
    /// <para type="synopsis">This is a function from the Calculator library.</para>
    /// <para type="description">This cmdlet lets you subtract two numbers.</para>
    /// <para type="description">It is possible to use multiple commands with pipelines.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Difference")]
    public class GetDifferenceCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 - n2;
        }
    }

    /// <summary>
    /// <para type="synopsis">This is a function from the Calculator library.</para>
    /// <para type="description">This cmdlet lets you multiply two numbers.</para>
    /// <para type="description">It is possible to use multiple commands with pipelines.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Product")]
    public class GetProductCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 * n2;
        }
    }

    /// <summary>
    /// <para type="synopsis">This is a function from the Calculator library.</para>
    /// <para type="description">This cmdlet lets you divide two numbers.</para>
    /// <para type="description">It is possible to use multiple commands with pipelines.</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "Quotient")]
    public class GetQuotientCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 / n2;
        }
    }
}
