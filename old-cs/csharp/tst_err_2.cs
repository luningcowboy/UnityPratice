using System;
namespace UserDefineException{
    class TestTemperature{
        static void Main(){
            Temperature temp = new Temperature();
            try{
                temp.showTemp();
            }
            catch(TempIsZeroExcepiton e){
                Console.WriteLine("TempIsZeroExcepiton:{0}", e.Message);
            }
            
        }
    }
}
public class TempIsZeroExcepiton : ApplicationException{
    public TempIsZeroExcepiton(string message):base(message){
        
    }
}
public class Temperature{
    int temperature = 0;
    public void showTemp(){
        if(temperature == 0){
            throw (new TempIsZeroExcepiton("Zero Temperature found"));
        }
        else{
            Console.WriteLine("Temperature:{0}", temperature);
        }
    }
}
