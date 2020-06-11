using System;
namespace ErrorHandlingApplication{
    class DivNumbers{
        int result;
        DivNumbers(){
            result = 0;
        }
        public void division(int n1, int n2){
            try{
                result = n1 / n2;
            }
            catch(DivideByZeroException e){
                Console.WriteLine("Exception caught:{0}", e);
            }
            finally{
                Console.WriteLine("Result:{0}", result);
            }
        }
        static void Main(string[] args){
            DivNumbers d = new DivNumbers();
            d.division(25, 0);
        }
    }
}
