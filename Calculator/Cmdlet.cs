using System.Management.Automation;

// Import-Module "C:\Users\robin\source\repos\Calculator\Calculator\bin\Debug\Calculator.dll"

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

    [Cmdlet(VerbsCommon.Get, "Sum")]
    public class GetSumCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 + n2;
        }
    }

    [Cmdlet(VerbsCommon.Get, "Difference")]
    public class GetDifferenceCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 - n2;
        }
    }

    [Cmdlet(VerbsCommon.Get, "Product")]
    public class GetProductCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 * n2;
        }
    }

    [Cmdlet(VerbsCommon.Get, "Quotient")]
    public class GetQuotientCmdlet : CalculationCmdlet
    {
        protected override float GetResult(float n1, float n2)
        {
            return n1 / n2;
        }
    }

}
