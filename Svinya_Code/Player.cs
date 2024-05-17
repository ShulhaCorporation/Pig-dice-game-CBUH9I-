using System;
public class Player
{   private static int localPScore = 0;
    public Player(){
        
    }
    
    public static void Choose(){
        Console.WriteLine("Зробіть вибір");
        
        point:
        
        string command = Console.ReadLine();
        
        if (command.Equals("d")){
            Throw();
        }
        else if(command.Equals("pass")){
            Pass();
        }
        else if(command.Equals("me")){
            GameManager.SetMe();
        }
        else if(command.Equals("bot")){
            GameManager.SetBot();
        }
        else{
            Console.WriteLine("Неіснуюча команда. Ознайомтеся з правилами.");
            goto point;
        }
    }
    private static void Throw(){
        var rand = new Random();
        int die = rand.Next(1,7);
        
        if(die==1){
            Console.WriteLine("Випало 1. Очки за даний хід згоріли");
            localPScore = 0;
            Pass();
        }
        else{
            localPScore += die;
            Console.WriteLine("Випало "+die+". Рахунок за хід: "+localPScore);
            Choose();
        }
    }
    private static void Pass(){
        GameManager.CountPlayer(localPScore);
    }
    public static void Reset(){
        localPScore = 0;
        GameManager.Continue();
    }
   
}