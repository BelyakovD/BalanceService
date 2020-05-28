using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QPSolver;
using MathWorks.MATLAB.NET.Arrays;

namespace BalanceLibrary
{
    public class Calculator
    {
        public static MWArray[] solve(double[,] Aeq, double[] beq, double[] x0, double[] tols, byte[] isMeas, double[] lowerBounds, double[] upperBounds)
        {
            MatlabWorker matlab = new MatlabWorker();

            MWArray MWAeq = new MWNumericArray(Aeq);
            MWArray MWBeq = new MWNumericArray(beq.Length, 1, beq);
            MWArray MWX0 = new MWNumericArray(x0.Length, 1, x0);
            MWArray MWTols = new MWNumericArray(tols.Length, 1, tols);
            MWArray MwIsMeas = new MWNumericArray(isMeas.Length, 1, isMeas);
            MWArray MWLowerBounds = new MWNumericArray(lowerBounds.Length, 1, lowerBounds);
            MWArray MWUpperBounds = new MWNumericArray(upperBounds.Length, 1, upperBounds);

            MWArray[] result = matlab.QPSolver(5, MWAeq, MWBeq, MWX0, MWTols, MwIsMeas, MWLowerBounds, MWUpperBounds);
            return result;
        }

        public static double solveErr(MWArray[] result)
        {
            double recErr = ((MWNumericArray)result[3]).ToScalarDouble();
            return recErr;
        }

        public static double[] xBalanced(MWArray[] result)
        {
            double[] x = (double[])((MWNumericArray)result[0]).ToVector(MWArrayComponent.Real);
            return x;
        }
    }
}
