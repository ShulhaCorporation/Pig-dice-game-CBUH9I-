using System;
using System.Threading;
public class Bot
{   //Бот завжди кидає 2 рази, третій раз із шансом 66%, четвертий - 25%. Далі він обов'язково зупиняється.
    private static int localBScore = 0;
    private static int bugfix;
    private static int limitt;
    
    public Bot(){
        
    }
    
    public static void Run(){
        int dice = 0;
        var rnd = new Random();
        limitt = GameManager.GetLimit;
        
        for(int i=0; i<4; i++){
            
            int checkScore = GameManager.GetBot + localBScore;
            
            if(checkScore >= limitt){                         //Коли бот розуміє, що вже виграв, він зупиняється і записує очки.
                Console.WriteLine("Бот вирішив зупинитися.");
             Pass();
             break;
            }
            
            Thread.Sleep(1000);
            
            if(rnd.Next(1,4) == 1 && i == 2){
             Console.WriteLine("Бот вирішив зупинитися");
             Pass();
             break;
            }
               if(rnd.Next(1,5) != 1 && i == 3){
             Console.WriteLine("Бот вирішив зупинитися");
             Pass();
             break;
            }
            
          dice = rnd.Next(1,7);
          
        if(dice==1){
            Console.WriteLine("Бот викинув 1");
            localBScore = 0;
            Pass();
            break;
        }
        else{
            bugfix = dice;
            localBScore += dice;
            Console.WriteLine("Бот викинув " + bugfix + ". Рахунок за хід: "+localBScore);
        }
        
        }
         Console.WriteLine("Бот вирішив зупинитися");
         Pass();
    }
    private static void Pass(){
        GameManager.CountBot(localBScore);
    } 
    public static void Reset(){
        localBScore = 0;
        GameManager.Continue();
    }
}
